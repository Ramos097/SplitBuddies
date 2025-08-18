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
        private readonly Usuario _usuario;
        private readonly IReporteController _reportesController;
        private readonly IGrupoUsuariosController _gruposUsuarioController;
        private readonly IGrupoController _grupoController;
        private Reporte _ultimoReporteDebo;
        private Reporte _ultimoReporteMeDeben;
        public FrmReporte(Usuario UsuarioLogeado)
        {
            InitializeComponent();
            _usuario = UsuarioLogeado;
            dtpFechaInicio.Visible = false;
            txtFecha1.Visible = false;

            dtpFechaFinal.Visible = false;
            txtFecha2.Visible = false;


            _reportesController = new ReportesController();
            _gruposUsuarioController = new GruposUsuariosController();
            _grupoController = new GrupoController();
            CargarGruposUsuario();
            txtGrupo.Visible = false;
            cbGrupo.Visible = false;

        }

        private void CargarGruposUsuario()
        {
            var grupos = new List<GrupoUsuarios>();
            grupos = _gruposUsuarioController.crt_ObtenerGruposPorUsuario(_usuario.Identificacion);
            cbGrupo.Items.Clear();

            if (grupos.Count == 0)
            {

                MessageBox.Show("NO TIENE GRUPOS ASOCIADOS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var grupoUsuario in grupos)
            {
                var grupo = _grupoController.ctr_ObtenerPorId(grupoUsuario.IdGrupo);
                if (grupo != null)
                {
                    cbGrupo.Items.Add(grupo.Id + "-" + grupo.Nombre);
                }
            }



        }



        private void cbFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFecha.SelectedIndex == 0) //mensual
            {
                dtpFechaInicio.Visible = true;
                txtFecha1.Visible = true;
                dtpFechaInicio.ShowUpDown = true;
                dtpFechaInicio.Format = DateTimePickerFormat.Custom;
                dtpFechaInicio.CustomFormat = "MMMM yyyy";
                dtpFechaFinal.Visible = false;
                txtFecha2.Visible = false;
            }
            if (cbFecha.SelectedIndex == 1) //anual
            {
                dtpFechaInicio.Visible = true;
                txtFecha1.Visible = true;
                dtpFechaInicio.ShowUpDown = true;
                dtpFechaInicio.Format = DateTimePickerFormat.Custom;
                dtpFechaInicio.CustomFormat = "yyyy";
                
                
                dtpFechaFinal.Visible = false;
                txtFecha2.Visible = false;
            }
            if (cbFecha.SelectedIndex == 2) // personalizado
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            string[] partes = new string[2];
            int idGrupo = 0;

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




            DateTime anio = new DateTime();
            DateTime anioMes = new DateTime();
            DateTime fechaInicio = new DateTime();
            DateTime fechaFinal = new DateTime();
            if (cbFecha.SelectedIndex == 0) //mensual
            {
                anioMes = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, 1);

            }
            if (cbFecha.SelectedIndex == 1) //anual
            {
                anio = new DateTime(dtpFechaInicio.Value.Year, 1, 1);
            }
            if (cbFecha.SelectedIndex == 2) //personalizado
            {
                fechaInicio = dtpFechaInicio.Value;
                fechaFinal = dtpFechaFinal.Value;
            }




            Reporte reporteDebo = new Reporte();
            Reporte reporteMeDeben = new Reporte();

            if (cbTipo.SelectedIndex == 0)//Personal
            {

                switch (cbFecha.SelectedIndex)
                {
                    case 0: //Mensual
                        reporteDebo = _reportesController.ctr_ReportePersonalMensual(_usuario.Identificacion, anioMes, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalMensual(_usuario.Identificacion, anioMes, "ME_DEBEN");

                        break;
                    case 1: //Anual
                        reporteDebo = _reportesController.ctr_ReportePersonalAnual(_usuario.Identificacion, anio, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalAnual(_usuario.Identificacion, anio, "ME_DEBEN");

                        break;
                    case 2: //Personalizado
                        reporteDebo = _reportesController.ctr_ReportePersonalRango(_usuario.Identificacion, fechaInicio, fechaFinal, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReportePersonalRango(_usuario.Identificacion, fechaInicio, fechaFinal, "ME_DEBEN");

                        break;
                }
                CargarReportes(reporteDebo, reporteMeDeben);

            }

            if (cbTipo.SelectedIndex == 1)//grupo
            {

                switch (cbFecha.SelectedIndex)
                {
                    case 0: //Mensual
                        reporteDebo = _reportesController.ctr_ReporteGrupoMensual(_usuario.Identificacion, idGrupo, anioMes, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoMensual(_usuario.Identificacion, idGrupo, anioMes, "ME_DEBEN");

                        break;
                    case 1: //Anual
                        reporteDebo = _reportesController.ctr_ReporteGrupoAnual(_usuario.Identificacion, idGrupo, anio, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoAnual(_usuario.Identificacion, idGrupo, anio, "ME_DEBEN");

                        break;
                    case 2: //Personalizado
                        reporteDebo = _reportesController.ctr_ReporteGrupoRango(_usuario.Identificacion, idGrupo, fechaInicio, fechaFinal, "DEBO");
                        reporteMeDeben = _reportesController.ctr_ReporteGrupoRango(_usuario.Identificacion, idGrupo, fechaInicio, fechaFinal, "ME_DEBEN");

                        break;
                }
                CargarReportes(reporteDebo, reporteMeDeben);


            }


        }


        private void CargarReportes(Reporte reportesDebo, Reporte reportesMeDeben)
        {
            dgvDebo.Rows.Clear();
            dgvMeDeben.Rows.Clear();
            _ultimoReporteDebo = reportesDebo;
            _ultimoReporteMeDeben = reportesMeDeben;

            foreach (var reporte in reportesMeDeben.DatosGastos)
            {
                dgvMeDeben.Rows.Add(reporte.Grupo, reporte.Fecha.ToString("dd/MM/yyyy"), reportesMeDeben.Tipo, reporte.Registro, reporte.Gasto, reporte.Descripcion, reporte.TotalGasto, reporte.MeDeben, reporte.Deudores);
            }
            //Grupo,fecha, tipo, registro, gasto, descripcion, monto,debo, deudores
            foreach (var reporte in reportesDebo.DatosGastos)
            {
                dgvDebo.Rows.Add(reporte.Grupo, reporte.Fecha.ToString("dd/MM/yyyy"), reportesDebo.Tipo, reporte.Registro, reporte.Gasto, reporte.Descripcion, reporte.TotalGasto, reporte.Debo, reporte.Deudores);
            }



            txtdebo.Text = reportesDebo.TotalDebo.ToString("C2");
            txtMedeben.Text = reportesMeDeben.TotalMeDeben.ToString("C2");

        }




        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex == 0) //personal
            {
                txtGrupo.Visible = false;
                cbGrupo.Visible = false;
            }

            if (cbTipo.SelectedIndex == 1) //grupo
            {
                txtGrupo.Visible = true;
                cbGrupo.Visible = true;
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
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
        private string GetFechaDescripcion()
        {
            // Describe el filtro de fechas seleccionado (para mostrarlo en el encabezado del PDF)
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
