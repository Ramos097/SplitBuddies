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
        // Usuario que actualmente está logeado en el sistema
        private readonly Usuario _usuario;

        // Controlador encargado de manejar operaciones de gastos
        private readonly IGastosController _gastosController;

        // Controlador encargado de manejar operaciones relacionadas con invitaciones
        private readonly IInvitacionesController _invitacionesController;

        // Controlador encargado de manejar operaciones de usuarios
        private readonly IUsuarioController _usuarioController;

        // Constructor que recibe al usuario logeado
        public FrmInfoGrupos(Usuario UsuarioLogeado)
        {
            InitializeComponent(); // Inicializa los componentes gráficos
            _usuario = UsuarioLogeado; // Se guarda el usuario que inició sesión

            // Se instancian los controladores necesarios
            _gastosController = new GastosController();
            _invitacionesController = new InvitacionesController();
            _usuarioController = new UsuarioController();

            // Se cargan los grupos donde el usuario tiene deudas
            CargarGruposQueDebo();
        }

        // Método para cargar los grupos en los que el usuario debe dinero
        private void CargarGruposQueDebo()
        {
            var grupos = new List<Grupo>();

            // Se obtienen los grupos donde el usuario tiene deudas
            grupos = _gastosController.ctr_ObtenerGruposQueDebo(_usuario.Identificacion);

            // Se limpia el ComboBox antes de cargar nuevos datos
            cbGrupos.Items.Clear();

            // Si no existen deudas pendientes, muestra un mensaje
            if (grupos.Count == 0)
            {
                MessageBox.Show("NO TIENE DEUDAS PENDIENTES", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se cargan los grupos obtenidos al ComboBox en formato "Id-Nombre"
            foreach (var grupo in grupos)
            {
                cbGrupos.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }
        }

        // Evento que se ejecuta cuando se selecciona un grupo del ComboBox
        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se obtiene el ID del grupo seleccionado
            string[] partes = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);

            // Se obtienen los gastos del grupo seleccionado
            var gastos = _gastosController.ctr_ObtenerGastosPorGrupo(idGrupo);

            // Se limpia el DataGridView antes de cargar nuevos datos
            dgvGastos.Rows.Clear();

            // Se recorren los gastos y se agregan al DataGridView
            foreach (var gasto in gastos)
            {
                dgvGastos.Rows.Add(
                    gasto.id,                              // ID del gasto
                    gasto.idUsuarioRegistraGasto,          // Usuario que registró el gasto
                    gasto.Nombre,                          // Nombre del gasto
                    gasto.Descripcion,                     // Descripción
                    gasto.Fecha.ToString("dd/MM/yyyy"),    // Fecha en formato día/mes/año
                    gasto.Monto,                           // Monto total del gasto
                    gasto.MiembrosQueDeben.Count           // Cantidad de miembros que deben
                );
            }
        }

        // Evento que se ejecuta al presionar el botón "Detalles"
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            // Se obtiene la fila seleccionada en el DataGridView
            DataGridViewRow filaseleccionada = dgvGastos.SelectedRows[0];

            // Se obtiene el ID del usuario que registró el gasto
            string idUsuarioRegistraGasto = filaseleccionada.Cells[1].Value.ToString();

            // Se busca la información del usuario que registró el gasto
            var usuarioDebo = _usuarioController.ctr_ObtenerUsuarioId(idUsuarioRegistraGasto);

            // Se muestra el nombre completo del usuario en el TextBox correspondiente
            txt_NombreCompleto.Text = usuarioDebo.NombreCompleto;

            // Se obtiene el total del gasto
            var total = Convert.ToDecimal(filaseleccionada.Cells[5].Value.ToString());

            // Se obtiene la cantidad de miembros que deben el gasto
            var miembrosQueDeben = Convert.ToInt32(filaseleccionada.Cells[6].Value.ToString());

            // Se calcula cuánto debe pagar el usuario logeado
            // (se suma 1 porque el que registró también forma parte del gasto)
            var calculo = total / (miembrosQueDeben + 1);

            // Se muestran los valores en los TextBox
            txtTotal.Text = total.ToString("C2");   // Total en formato moneda
            txtDebo.Text = calculo.ToString("C2"); // Lo que debe el usuario en formato moneda
        }
    }
}

}
