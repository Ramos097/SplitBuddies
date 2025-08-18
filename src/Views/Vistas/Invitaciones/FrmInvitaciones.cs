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
        private readonly Usuario _usuario;
        private readonly IInvitacionesController _invitacionesController;
        private readonly IGrupoUsuariosController _grupoUsuariosController;
        public delegate void ActualizarBotonInvitacionesDelegate(bool estado);
        public event ActualizarBotonInvitacionesDelegate ActualizarBotonInvitacionesEvent;
        public FrmInvitaciones(Usuario usuarioLogeado)
        {
            InitializeComponent();
            _usuario = usuarioLogeado;
            _invitacionesController = new InvitacionesController();
            _grupoUsuariosController = new GruposUsuariosController();
            CargarGruposInvitados();
        }




        private void CargarGruposInvitados()
        {
            var grupos = new List<Grupo>();
            grupos = _invitacionesController.crt_ObtenerGruposInvitados(_usuario.Identificacion);
            cbGrupoInvitado.Items.Clear();

            if (grupos.Count == 0)
            {
                cbGrupoInvitado.Enabled = false;
                lbMiembros.Items.Clear();
                btnAceptar.Enabled = false;
                btnRechazar.Enabled = false;
                MessageBox.Show("NO HAY INVITACIONES PENDIENTES", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActualizarBotonInvitacionesEvent?.Invoke(false);
                return;
            }

            foreach (var grupo in grupos)
            {
                cbGrupoInvitado.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }
            


        }

        private void cbGrupoInvitado_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);
            var usuarios = _invitacionesController.crt_ObtenerUsuariosGrupo(idGrupo);
            //limpiar listbox lbmiembros
            lbMiembros.Items.Clear();



            foreach (var usuario in usuarios)
            {
                //desactivarle el checkbox y que no sea editable el checkbox
                lbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string estado = "ACTIVO"; 
            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);
            var resultado = _grupoUsuariosController.ActualizarEstadoInvitacion(_usuario.Identificacion, idGrupo, estado);
            
            if (resultado)
            {
                MessageBox.Show("Invitación aceptada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Error al aceptar la invitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarGruposInvitados();

        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            string estado = "RECHAZADA";
            string[] partes = cbGrupoInvitado.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);
            var resultado = _grupoUsuariosController.ActualizarEstadoInvitacion(_usuario.Identificacion, idGrupo, estado);
            
            if (resultado)
            {
                MessageBox.Show("Invitación rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Error al rechazar la invitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarGruposInvitados();
        }
    }
}
