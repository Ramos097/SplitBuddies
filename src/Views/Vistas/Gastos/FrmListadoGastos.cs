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

namespace Views.Vistas.Gastos
{
    public partial class FrmListadoGastos : UserControl
    {
        private readonly Usuario _usuario;
        private readonly IGastosController _gastosController;

        private readonly IGrupoController _grupoController;

        public event Action<int, Usuario> CambiarVista;






        public FrmListadoGastos(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            _gastosController = new GastosController();

            _grupoController = new GrupoController();
            CargarListadoGastos();
        }
        private void CargarListadoGastos()
        {
            dgvGastos.Rows.Clear();
            var gastos = _gastosController.ctr_ObtenerGastosPorUsuario(_usuario.Identificacion);
            foreach (var gasto in gastos)
            {
                var grupo = _grupoController.ctr_ObtenerPorId(gasto.idGrupo);
                dgvGastos.Rows.Add(gasto.id, gasto.Nombre, grupo.Nombre, gasto.Descripcion, gasto.Monto, gasto.Fecha.ToString("dd/MM/yyyy"), gasto.MiembrosQueDeben.Count);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //obtener fila seleccionada
            if (dgvGastos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un gasto para editar.");
                return;
            }
            var filaSeleccionada = dgvGastos.SelectedRows[0];
            int idGasto = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

            CambiarVista?.Invoke(idGasto, _usuario);
        }
    }

}
