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
using LogicaNegocio.Interfaces;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

namespace Views.Gastos
{
    public partial class FrmRGastos : UserControl
    {
        private readonly Usuario _usuario;
        private readonly IGastosController _gastosController;
        private readonly IInvitacionesController _invitacionesController;
        public FrmRGastos(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            _gastosController = new GastosController();
            _invitacionesController = new InvitacionesController();
            CargarGruposActivos();
            btnActualizar.Enabled = false;
            btnPagar.Enabled = true;
        }

        private int Idgasto;
        private readonly Gasto gastoEditar;
        public FrmRGastos(int idGasto, Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            Idgasto = idGasto;
            _gastosController = new GastosController();
            _invitacionesController = new InvitacionesController();
            gastoEditar = _gastosController.ctr_ObtenerGastoporID(Idgasto);
            CargarGruposActivos();
            CargarDatosGasto();
            btnActualizar.Enabled = true;
            btnPagar.Enabled = false;

        }



        private void CargarDatosGasto()
        {

            txtNombreGasto.Text = gastoEditar.Nombre;
            txtDescripcion.Text = gastoEditar.Descripcion;
            txtMonto.Text = gastoEditar.Monto.ToString();
            dtpFecha.Value = gastoEditar.Fecha;


            foreach (var item in cbGrupos.Items)
            {
                string[] partes = item.ToString().Split('-');
                int idGrupo = Convert.ToInt32(partes[0]);
                if (gastoEditar.idGrupo == idGrupo)
                {
                    cbGrupos.SelectedItem = item;
                    break;
                }
            }





        }








        private void CargarGruposActivos()
        {
            var grupos = new List<Grupo>();
            grupos = _gastosController.crt_obtenerGruposActivos(_usuario.Identificacion);
            cbGrupos.Items.Clear();

            if (grupos.Count == 0)
            {

                MessageBox.Show("NO TIENE GRUPOS REGISTRADOS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var grupo in grupos)
            {

                cbGrupos.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }





        }


        private void btnPagar_Click(object sender, EventArgs e)
        {

            var miembrosQueDeben = new List<string>();
            foreach (var usuario in clbMiembros.CheckedItems)
            {
                string[] partes = usuario.ToString().Split('-');
                string identificacionDeben = partes[0].Trim();
                if (identificacionDeben != _usuario.Identificacion)
                {
                    miembrosQueDeben.Add(identificacionDeben);
                }
            }

            string[] parteGrupoCb = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupoCb = Convert.ToInt32(parteGrupoCb[0]);

            Gasto gasto = new Gasto
            {
                id = _gastosController.ctr_ObtenerUltimoIdGasto(),
                idGrupo = idGrupoCb,
                Nombre = txtNombreGasto.Text,
                idUsuarioRegistraGasto = _usuario.Identificacion,
                Descripcion = txtDescripcion.Text,
                Monto = Convert.ToDecimal(txtMonto.Text),
                Fecha = dtpFecha.Value,
                MiembrosQueDeben = miembrosQueDeben
            };

            _gastosController.ctr_RegistrarGasto(gasto);
            MessageBox.Show("Gasto registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);





        }

        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] partes = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);
            var usuarios = _invitacionesController.crt_ObtenerUsuariosGrupo(idGrupo);
            //limpiar listbox lbmiembros
            clbMiembros.Items.Clear();

            foreach (var usuario in usuarios)
            {
                //marcar al usuario logeado y desmarcar los demás
                if (usuario.Identificacion == _usuario.Identificacion)
                {
                    clbMiembros.SetItemChecked(clbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto), true);
                }
                else
                {
                    clbMiembros.SetItemChecked(clbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto), false);
                }


            }

            if (gastoEditar != null)
            {
                for (int i = 0; i < clbMiembros.Items.Count; i++)
                {
                    clbMiembros.SetItemChecked(i, false);

                    var itemUsuario = clbMiembros.Items[i];
                    string[] partes2 = itemUsuario.ToString().Split('-');
                    string identificacionUsuario = partes2[0].Trim();

                    if (gastoEditar.MiembrosQueDeben.Contains(identificacionUsuario)
                        || gastoEditar.idUsuarioRegistraGasto.Equals(identificacionUsuario))
                    {
                        clbMiembros.SetItemChecked(i, true);
                    }
                }
            }



        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var miembrosQueDeben = new List<string>();
            foreach (var usuario in clbMiembros.CheckedItems)
            {
                string[] partes = usuario.ToString().Split('-');
                string identificacionDeben = partes[0].Trim();
                if (identificacionDeben != _usuario.Identificacion)
                {
                    miembrosQueDeben.Add(identificacionDeben);
                }
            }

            string[] parteGrupoCb = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupoCb = Convert.ToInt32(parteGrupoCb[0]);

            Gasto gasto = new Gasto
            {
                id = gastoEditar.id,
                idGrupo = idGrupoCb,
                Nombre = txtNombreGasto.Text,
                idUsuarioRegistraGasto = gastoEditar.idUsuarioRegistraGasto,
                Descripcion = txtDescripcion.Text,
                Monto = Convert.ToDecimal(txtMonto.Text),
                Fecha = dtpFecha.Value,
                MiembrosQueDeben = miembrosQueDeben
            };

            _gastosController.ctr_ActualizarGasto(gasto);
            MessageBox.Show("Gasto Actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
