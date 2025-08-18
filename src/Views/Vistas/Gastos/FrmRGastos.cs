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
        // Usuario actualmente logeado
        private readonly Usuario _usuario;

        // Controlador para manejar operaciones de gastos
        private readonly IGastosController _gastosController;

        // Controlador para manejar operaciones de invitaciones (miembros de grupos)
        private readonly IInvitacionesController _invitacionesController;

        // Constructor para registrar un gasto nuevo
        public FrmRGastos(Usuario UsuarioLogeado)
        {
            InitializeComponent(); // Inicializa componentes gráficos
            _usuario = UsuarioLogeado; // Guarda el usuario actual
            _gastosController = new GastosController(); // Instancia controlador de gastos
            _invitacionesController = new InvitacionesController(); // Instancia controlador de invitaciones
            CargarGruposActivos(); // Carga grupos en los que participa el usuario

            // Habilita o deshabilita botones según la acción
            btnActualizar.Enabled = false; // No se puede actualizar en un gasto nuevo
            btnPagar.Enabled = true; // Se habilita registrar un nuevo gasto
        }

        // Campo para guardar el ID del gasto cuando se está editando
        private int Idgasto;

        // Campo para almacenar el gasto en edición
        private readonly Gasto gastoEditar;

        // Constructor para editar un gasto existente
        public FrmRGastos(int idGasto, Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            Idgasto = idGasto; // Se guarda el ID del gasto que se va a editar
            _gastosController = new GastosController();
            _invitacionesController = new InvitacionesController();

            // Se obtiene el gasto que se va a editar
            gastoEditar = _gastosController.ctr_ObtenerGastoporID(Idgasto);

            CargarGruposActivos(); // Se cargan los grupos
            CargarDatosGasto();    // Se cargan los datos en los controles

            // Configuración de botones
            btnActualizar.Enabled = true; // Ahora se permite actualizar
            btnPagar.Enabled = false;     // No se permite registrar uno nuevo
        }

        // Método que carga la información de un gasto existente en los campos
        private void CargarDatosGasto()
        {
            txtNombreGasto.Text = gastoEditar.Nombre;
            txtDescripcion.Text = gastoEditar.Descripcion;
            txtMonto.Text = gastoEditar.Monto.ToString();
            dtpFecha.Value = gastoEditar.Fecha;

            // Selecciona el grupo correcto en el ComboBox
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

        // Método que carga los grupos activos del usuario en el ComboBox
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

            // Agrega los grupos al ComboBox en formato "Id-Nombre"
            foreach (var grupo in grupos)
            {
                cbGrupos.Items.Add(grupo.Id + "-" + grupo.Nombre);
            }
        }

        // Evento del botón Pagar → registra un gasto nuevo
        private void btnPagar_Click(object sender, EventArgs e)
        {
            var miembrosQueDeben = new List<string>();

            // Obtiene los usuarios seleccionados en la lista
            foreach (var usuario in clbMiembros.CheckedItems)
            {
                string[] partes = usuario.ToString().Split('-');
                string identificacionDeben = partes[0].Trim();

                // Se excluye al usuario que registra el gasto
                if (identificacionDeben != _usuario.Identificacion)
                {
                    miembrosQueDeben.Add(identificacionDeben);
                }
            }

            // Se obtiene el grupo seleccionado
            string[] parteGrupoCb = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupoCb = Convert.ToInt32(parteGrupoCb[0]);

            // Se crea un nuevo objeto gasto con los datos ingresados
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

            // Se registra el gasto en el controlador
            _gastosController.ctr_RegistrarGasto(gasto);
            MessageBox.Show("Gasto registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento cuando se selecciona un grupo en el ComboBox
        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se obtiene el ID del grupo seleccionado
            string[] partes = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupo = Convert.ToInt32(partes[0]);

            // Se obtienen los usuarios del grupo
            var usuarios = _invitacionesController.crt_ObtenerUsuariosGrupo(idGrupo);

            // Limpia la lista de miembros antes de cargar los nuevos
            clbMiembros.Items.Clear();

            // Se agregan los usuarios al CheckedListBox
            foreach (var usuario in usuarios)
            {
                // Marca automáticamente al usuario logeado
                if (usuario.Identificacion == _usuario.Identificacion)
                {
                    clbMiembros.SetItemChecked(clbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto), true);
                }
                else
                {
                    clbMiembros.SetItemChecked(clbMiembros.Items.Add(usuario.Identificacion + " - " + usuario.NombreCompleto), false);
                }
            }

            // Si es edición, marcar los usuarios que deben o que registraron el gasto
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

        // Evento del botón Actualizar → actualiza un gasto existente
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var miembrosQueDeben = new List<string>();

            // Obtiene los usuarios seleccionados en la lista
            foreach (var usuario in clbMiembros.CheckedItems)
            {
                string[] partes = usuario.ToString().Split('-');
                string identificacionDeben = partes[0].Trim();

                if (identificacionDeben != _usuario.Identificacion)
                {
                    miembrosQueDeben.Add(identificacionDeben);
                }
            }

            // Se obtiene el grupo seleccionado
            string[] parteGrupoCb = cbGrupos.SelectedItem.ToString().Split('-');
            int idGrupoCb = Convert.ToInt32(parteGrupoCb[0]);

            // Se crea un objeto gasto con los datos modificados
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

            // Se actualiza el gasto
            _gastosController.ctr_ActualizarGasto(gasto);
            MessageBox.Show("Gasto Actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
