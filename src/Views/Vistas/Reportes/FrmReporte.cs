using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Controladores;
using Controllers.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Interfaces;

namespace Views.Vistas.Reportes
{
    public partial class FrmReporte : UserControl
    {
        // Usuario logueado en el sistema
        private readonly Usuario _usuario;

        // Controladores para manejar la lógica de reportes, grupos y usuarios
        private readonly IReporteController _reportesController;
        private readonly IGrupoUsuariosController _gruposUsuarioController;
        private readonly IGrupoController _grupoController;

        // Reportes cargados en la última consulta (para exportar después a PDF)
        private Reporte _ultimoReporteDebo;
        private Reporte _ultimoReporteMeDeben;

        public FrmReporte(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;

            // Ocultar campos de fecha al inicio
            dtpFechaInicio.Visible = false;
            txtFecha1.Visible = false;
            dtpFechaFinal.Visible = false;
            txtFecha2.Visible = false;

            // Inicializar controladores
            _reportesController = new ReportesController();
            _gruposUsuarioController = new GruposUsuariosController();
            _grupoController = new GrupoController();

            // Cargar los grupos del usuario
            CargarGruposUsuario();

            // Ocultar selección de grupos hasta que se elija un tipo de reporte "grupo"
            txtGrupo.Visible = false;
            cbGrupo.Visible = false;
        }

        /// <summary>
        /// Carga los grupos asociados al usuario logueado
        /// </summary>
        private void CargarGruposUsuario()
        {
            var grupos = _gruposUsuarioController.crt_ObtenerGruposPorUsuario(_usuario.Identificacion);
            cbGrupo.Items.Clear();

            if (grupos.Count == 0)
            {
                MessageBox.Show("NO TIENE GRUPOS ASOCIADOS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se agregan al combo los grupos donde el usuario pertenece
            foreach (var grupoUsuario in grupos)
            {
                var grupo = _grupoController.ctr_ObtenerPorId(grupoUsuario.IdGrupo);
                if (grupo != null)
                {
                    cbGrupo.Items.Add(grupo.Id + "-" + grupo.Nombre);
                }
            }
        }

        /// <summary>
        /// Configuración de los selectores de fecha según el tipo seleccionado (mensual, anual o personalizado)
        /// </summary>
        private void cbFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFecha.SelectedIndex == 0) // Mensual
            {
                dtpFechaInicio.Visible = true;
                txtFecha1.Visible = true;
                dtpFechaInicio.ShowUpDown = true; // selector tipo spinner
                dtpFechaInicio.Format = DateTimePickerFormat.Custom;
                dtpFechaInicio.CustomFormat = "MMMM yyyy";

                dtpFechaFinal.Visible = false;
                txtFecha2.Visible = false;
            }
            if (cbFecha.SelectedIndex == 1) // Anual
            {
                dtpFechaInicio.Visible = true;
                txtFecha1.Visible = true;
                dtpFechaInicio.ShowUpDown = true;
                dtpFechaInicio.Format = DateTimePickerFormat.Custom;
                dtpFechaInicio.CustomFormat = "yyyy";

                dtpFechaFinal.Visible = false;
                txtFecha2.Visible = false;
            }
            if (cbFecha.SelectedIndex == 2) // Personalizado (rango de fechas)
            {
                dtpFechaInicio.Visible = true;
                txtFecha1.Visible = true;
                dtpFechaInicio.Format = DateTimePickerFormat.Custom;
                dtpFechaInicio.CustomFormat = " dd MMMM yyyy";

                dtpFechaFinal.Visible = true;
                txtFecha2.Visible = true;
                dtpFechaFinal.Format = DateTimePickerFormat.Custom;
                dtpFechaFinal.CustomFormat = "dd MM yyyy";

                dtpFechaInicio.ShowUpDown = false;
                dtpFechaFinal.ShowUpDown = false;
            }
        }

        /// <summary>
        /// Evento del botón "Consultar": obtiene los reportes según tipo y rango de fechas
        /// </summary>
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string[] partes = new string[2];
            int idGrupo = 0;

            // Validaciones básicas
            if (cbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbFecha.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbFecha.SelectedIndex == 2 && (dtpFechaInicio.Value > dtpFechaFinal.Value))
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si el reporte es de tipo "grupo", validar selección de grupo
            if (cbTipo.SelectedIndex == 1)
            {
                if (cbGrupo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    partes = cbGrupo.SelectedItem.ToString().Split('-');
                    idGrupo = Convert.ToInt32(partes[0]);
                }
            }

            // Variables de fechas
            DateTime anio = new DateTime();
            DateTime anioMes = new DateTime();
            DateTime fechaInicio = new DateTime();
            DateTime fechaFinal = new DateTime();

            // Dependiendo del filtro, asignar valores
            if (cbFecha.SelectedIndex == 0) // mensual
                anioMes = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, 1);

            if (cbFecha.SelectedIndex == 1) // anual
                anio = new DateTime(dtpFechaInicio.Value.Year, 1, 1);

            if (cbFecha.SelectedIndex == 2) // personalizado
            {
                fechaInicio = dtpFechaInicio.Value;
                fechaFinal = dtpFechaFinal.Value;
            }

            // Objetos de reportes
            Reporte reporteDebo = new Reporte();
            Reporte reporteMeDeben = new Reporte();

            // Si es reporte personal
            if (cbTipo.SelectedIndex == 0)
            {
                switch (cbFecha.SelectedIndex)
                {
                    case 0: // Mensual
                        reporteDebo = _reportesController.ctr_ReportePersonalMensual(_usuario.Identificacion, anioMes, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalMensual(_usuario.Identificacion, anioMes, "ME_DEBEN");
                        break;
                    case 1: // Anual
                        reporteDebo = _reportesController.ctr_ReportePersonalAnual(_usuario.Identificacion, anio, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalAnual(_usuario.Identificacion, anio, "ME_DEBEN");
                        break;
                    case 2: // Personalizado
                        reporteDebo = _reportesController.ctr_ReportePersonalRango(_usuario.Identificacion, fechaInicio, fechaFinal, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalRango(_usuario.Identificacion, fechaInicio, fechaFinal, "ME_DEBEN");
                        break;
                }
                CargarReportes(reporteDebo, reporteMeDeben);
            }

            // Si es reporte de grupo
            if (cbTipo.SelectedIndex == 1)
            {
                switch (cbFecha.SelectedIndex)
                {
                    case 0: // Mensual
                        reporteDebo = _reportesController.ctr_ReporteGrupoMensual(_usuario.Identificacion, idGrupo, anioMes, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoMensual(_usuario.Identificacion, idGrupo, anioMes, "ME_DEBEN");
                        break;
                    case 1: // Anual
                        reporteDebo = _reportesController.ctr_ReporteGrupoAnual(_usuario.Identificacion, idGrupo, anio, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoAnual(_usuario.Identificacion, idGrupo, anio, "ME_DEBEN");
                        break;
                    case 2: // Personalizado
                        reporteDebo = _reportesController.ctr_ReporteGrupoRango(_usuario.Identificacion, idGrupo, fechaInicio, fechaFinal, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoRango(_usuario.Identificacion, idGrupo, fechaInicio, fechaFinal, "ME_DEBEN");
                        break;
                }
                CargarReportes(reporteDebo, reporteMeDeben);
            }
        }

        /// <summary>
        /// Carga los datos de los reportes en las tablas y totales
        /// </summary>
        private void CargarReportes(Reporte reportesDebo, Reporte reportesMeDeben)
        {
            dgvDebo.Rows.Clear();
            dgvMeDeben.Rows.Clear();
            _ultimoReporteDebo = reportesDebo;
            _ultimoReporteMeDeben = reportesMeDeben;

            // Llenar tabla "Me deben"
            foreach (var reporte in reportesMeDeben.DatosGastos)
            {
                dgvMeDeben.Rows.Add(reporte.Grupo, reporte.Fecha.ToString("dd/MM/yyyy"), reportesMeDeben.Tipo, reporte.Registro, reporte.Gasto, reporte.Descripcion, reporte.TotalGasto, reporte.MeDeben, reporte.Deudores);
            }

            // Llenar tabla "Debo"
            foreach (var reporte in reportesDebo.DatosGastos)
            {
                dgvDebo.Rows.Add(reporte.Grupo, reporte.Fecha.ToString("dd/MM/yyyy"), reportesDebo.Tipo, reporte.Registro, reporte.Gasto, reporte.Descripcion, reporte.TotalGasto, reporte.Debo, reporte.Deudores);
            }

            // Mostrar totales en etiquetas
            txtdebo.Text = reportesDebo.TotalDebo.ToString("C2");
            txtMedeben.Text = reportesMeDeben.TotalMeDeben.ToString("C2");
        }

        /// <summary>
        /// Cambia la visibilidad de campos según el tipo de reporte (personal o grupo)
        /// </summary>
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex == 0) // personal
            {
                txtGrupo.Visible = false;
                cbGrupo.Visible = false;
            }
            if (cbTipo.SelectedIndex == 1) // grupo
            {
                txtGrupo.Visible = true;
                cbGrupo.Visible = true;
            }
        }

        /// <summary>
        /// Exporta el último reporte generado a PDF
        /// </summary>
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            // Validar que existan reportes consultados
            if ((_ultimoReporteDebo?.DatosGastos == null || !_ultimoReporteDebo.DatosGastos.Any()) &&
                (_ultimoReporteMeDeben?.DatosGastos == null || !_ultimoReporteMeDeben.DatosGastos.Any()))
            {
                MessageBox.Show("Primero consulte un reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Title = "Guardar reporte en PDF",
                Filter = "Archivo PDF|*.pdf",
                FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ExportarService.Export(
                        sfd.FileName,
                        _usuario,
                        cbTipo.SelectedIndex == 0 ? "Personal" : "Grupo",
                        GetFechaDescripcion(),
                        cbTipo.SelectedIndex == 1 ? (cbGrupo.SelectedItem?.ToString() ?? "") : "",
                        _ultimoReporteDebo,
                        _ultimoReporteMeDeben
                    );

                    MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Obtiene la descripción legible del filtro de fechas aplicado
        /// </summary>
        private string GetFechaDescripcion()
        {
            if (cbFecha.SelectedIndex == 0) // mensual
                return dtpFechaInicio.Value.ToString("MMMM yyyy", new CultureInfo("es-CR"));
            if (cbFecha.SelectedIndex == 1) // anual
                return dtpFechaInicio.Value.ToString("yyyy", CultureInfo.InvariantCulture);
            if (cbFecha.SelectedIndex == 2) // personalizado
                return $"{dtpFechaInicio.Value:dd/MM/yyyy} - {dtpFechaFinal.Value:dd/MM/yyyy}";
            return "";
        }
    }
}
