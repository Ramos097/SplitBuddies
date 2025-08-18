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

namespace Views.Vistas.Invitaciones
{
    public partial class FrmInvitaciones : UserControl
    {
        // Usuario actualmente logueado en el sistema
        private readonly Usuario _usuario;

        // Controlador encargado de manejar la lógica de invitaciones
        private readonly IInvitacionesController _invitacionesController;

        // Controlador encargado de manejar la relación entre grupos y usuarios
        private readonly IGrupoUsuariosController _grupoUsuariosController;

        // Delegado para actualizar el botón de invitaciones en otra parte de la UI
        public delegate void ActualizarBotonInvitacionesDelegate(bool estado);

        // Evento que se dispara cuando cambian las invitaciones (aceptar/rechazar)
        public event ActualizarBotonInvitacionesDelegate ActualizarBotonInvitacionesEvent;

        // Constructor que recibe al usuario logueado
        public FrmInvitaciones(Usuario usuarioLogeado)
        {
            InitializeComponent(); // Inicializa los componentes visuales

            _usuario = usuarioLogeado; // Se guarda el usuario que inició sesión

            // Se inicializan los controladores
            _invitacionesController = new InvitacionesController();
            _grupoUsuariosController = new GruposUsuariosController();

            // Se cargan las invitaciones pendientes al iniciar
            CargarGruposInvitados();
        }

        // Método que carga los grupos a los que el usuario ha sido invitado
        private void CargarGruposInvitados()
        {
            var grupos = new List<Grupo>();

            // Se obtienen los grupos desde el controlador
            grupos = _invitacionesController.crt_ObtenerGruposInvitados(_usuario.Identificacion);

            // Limpia el comboBox antes de cargar
            cbGrupoInvitado.Items.Clear();

            // Validación: si no hay invitaciones
            if (grupos.Count == 0)
            {
                cbGrupoInvitado.Enabled = false; // Se deshabilita el combo
                lbMiembros.Items.Clear();        // Se limpia la lista de miembros
                btnAceptar.Enabled = false;      // Se deshabilita el botón Aceptar
                btnRechazar.Enabled = false;     // Se deshabilita el botón Rechazar

                // Mensaje de notificación al usuario
                MessageBox.Show("NO HAY INVITACIONES PENDIENTES", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Se lanza el evento para actualizar el estado del botón de invitaciones
                ActualizarBotonInvitacionesEvent?.Invoke(false);
                return;
            }

            // Se recorren los grupos y se agregan al combo
            foreach (var grupo in grupos)
            {
                cbGrupoInvitado.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }
        }

        // Evento que se ejecuta cuando se selecciona un grupo en el ComboBox
        private void cbGrupoInvitado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se separa el id del grupo y su nombre (ejemplo: "1-GrupoAmigos")
            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);

            // Se obtienen los usuarios del grupo seleccionado
            var usuarios = _invitacionesController.crt_ObtenerUsuariosGrupo(idGrupo);

            // Se limpia la lista antes de cargar nuevos usuarios
            lbMiembros.Items.Clear();

            // Se recorren los usuarios y se agregan a la lista
            foreach (var usuario in usuarios)
            {
                // Se agrega en formato "Identificacion - NombreCompleto"
                lbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto);
            }
        }

        // Evento que se ejecuta al dar clic en "Aceptar Invitación"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string estado = "ACTIVO"; // Estado que se aplicará al aceptar

            // Se obtiene el id del grupo seleccionado
            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);

            // Se actualiza el estado de la invitación
            var resultado = _grupoUsuariosController.ActualizarEstadoInvitacion(_usuario.Identificacion, idGrupo, estado);

            // Validación del resultado
            if (resultado)
            {
                MessageBox.Show("Invitación aceptada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al aceptar la invitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Se recargan las invitaciones para reflejar el cambio
            CargarGruposInvitados();
        }

        // Evento que se ejecuta al dar clic en "Rechazar Invitación"
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            string estado = "RECHAZADA"; // Estado que se aplicará al rechazar

            // Se obtiene el id del grupo seleccionado
            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);

            // Se actualiza el estado de la invitación
            var resultado = _grupoUsuariosController.ActualizarEstadoInvitacion(_usuario.Identificacion, idGrupo, estado);

            // Validación del resultado
            if (resultado)
            {
                MessageBox.Show("Invitación rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al rechazar la invitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Se recargan las invitaciones para reflejar el cambio
            CargarGruposInvitados();
        }
    }
}
