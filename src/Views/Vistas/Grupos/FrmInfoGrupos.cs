using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Controladores;
using Controllers.Interfaces;
using Models;
using Proyecto_1.Interfaces;

namespace Views.Vistas.Grupos
{
    public partial class FrmInfoGrupos : UserControl
    {


        private readonly Usuario _usuario;
        private readonly IGastosController _gastosController;
        private readonly IInvitacionesController _invitacionesController;
        private readonly IUsuarioController _usuarioController;
        public FrmInfoGrupos(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            _gastosController = new GastosController();
            _invitacionesController = new InvitacionesController();
            _usuarioController = new UsuarioController();
            CargarGruposQueDebo();
        }



        private void CargarGruposQueDebo()
        {
            var grupos = new List<Grupo>();
            grupos = _gastosController.ctr_ObtenerGruposQueDebo(_usuario.Identificacion);
            cbGrupos.Items.Clear();

            if (grupos.Count == 0)
            {

                MessageBox.Show("NO TIENE DEUDAS PENDIENTES", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var grupo in grupos) 
            {
                //No cargar grupos que ya esten en el combo
                cbGrupos.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }



        }

        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] partes = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);
            var gastos = _gastosController.ctr_ObtenerGastosPorGrupo(idGrupo);
            //limpiar el DataGridView
            dgvGastos.Rows.Clear();

            foreach (var gasto in gastos)
            {
                dgvGastos.Rows.Add(gasto.id, gasto.idUsuarioRegistraGasto,gasto.Nombre, gasto.Descripcion, gasto.Fecha.ToString("dd/MM/yyyy"), gasto.Monto, gasto.MiembrosQueDeben.Count);
            }


        }

   

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaseleccionada = dgvGastos.SelectedRows[0];
            string idUsuarioRegistraGasto = filaseleccionada.Cells[1].Value.ToString();
            var usuarioDebo = _usuarioController.ctr_ObtenerUsuarioId(idUsuarioRegistraGasto);
            txt_NombreCompleto.Text = usuarioDebo.NombreCompleto;
             
            var total = Convert.ToDecimal(filaseleccionada.Cells[5].Value.ToString());
            var miembrosQueDeben = Convert.ToInt32(filaseleccionada.Cells[6].Value.ToString());
            var calculo = total / (miembrosQueDeben + 1); // se le suma 1 porque el usuario que registra tambien forma parte del gasto
            txtTotal.Text = total.ToString("C2");
            txtDebo.Text = calculo.ToString("C2");
        }
    }
}
