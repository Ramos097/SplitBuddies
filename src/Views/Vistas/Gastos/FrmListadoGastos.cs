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
        // Usuario que está logeado en el sistema
        private readonly Usuario _usuario;

        // Controlador que maneja la lógica relacionada con los gastos
        private readonly IGastosController _gastosController;

        // Controlador que maneja la lógica relacionada con los grupos
        private readonly IGrupoController _grupoController;

        // Evento para notificar que se debe cambiar la vista
        // Pasa el id del gasto y el usuario logeado
        public event Action<int, Usuario> CambiarVista;


        // Constructor que recibe el usuario que inició sesión
        public FrmListadoGastos(Usuario UsuarioLogeado)
        {
            InitializeComponent(); // Inicializa los componentes visuales del UserControl

            // Guarda el usuario logeado en la variable privada
            _usuario = UsuarioLogeado;

            // Instancia el controlador de gastos
            _gastosController = new GastosController();

            // Instancia el controlador de grupos
            _grupoController = new GrupoController();

            // Carga los gastos del usuario en la tabla
            CargarListadoGastos();
        }

        // Método que carga en el DataGridView todos los gastos del usuario
        private void CargarListadoGastos()
        {
            // Limpia las filas actuales del DataGridView
            dgvGastos.Rows.Clear();

            // Obtiene los gastos del usuario logeado
            var gastos = _gastosController.ctr_ObtenerGastosPorUsuario(_usuario.Identificacion);

            // Recorre cada gasto y lo agrega como fila en el DataGridView
            foreach (var gasto in gastos)
            {
                // Busca el grupo al que pertenece el gasto
                var grupo = _grupoController.ctr_ObtenerPorId(gasto.idGrupo);

                // Agrega la información del gasto en una fila
                dgvGastos.Rows.Add(
                    gasto.id,                           // Id del gasto
                    gasto.Nombre,                       // Nombre del gasto
                    grupo.Nombre,                       // Nombre del grupo al que pertenece
                    gasto.Descripcion,                  // Descripción del gasto
                    gasto.Monto,                        // Monto del gasto
                    gasto.Fecha.ToString("dd/MM/yyyy"), // Fecha en formato dd/MM/yyyy
                    gasto.MiembrosQueDeben.Count        // Cantidad de miembros que deben ese gasto
                );
            }
        }

        // Evento del botón Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada
            if (dgvGastos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un gasto para editar.");
                return;
            }

            // Obtiene la primera fila seleccionada
            var filaSeleccionada = dgvGastos.SelectedRows[0];

            // Extrae el id del gasto desde la celda correspondiente
            int idGasto = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

            // Lanza el evento para cambiar la vista y pasar el gasto seleccionado junto con el usuario logeado
            CambiarVista?.Invoke(idGasto, _usuario);
        }
    }
}

