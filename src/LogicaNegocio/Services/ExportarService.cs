using System;
using System.Globalization;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Models;  // <- donde están Usuario y Reporte

// Alias para evitar conflictos de nombres
using MdOrientation = MigraDoc.DocumentObjectModel.Orientation;
using MdVAlign = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment;

namespace LogicaNegocio.Services
{
    public class ExportarService
    {
        public static void Export(
        string filePath,
        Usuario usuario,
        string tipoReporte,       // "Personal" o "Grupo"
        string descriptorFecha,   // "agosto 2025" / "2025" / "01/08/2025 - 17/08/2025"
        string descriptorGrupo,   // "12-MiGrupo" o ""
        Reporte reporteDebo,
        Reporte reporteMeDeben)
        {
            var doc = BuildDocument(usuario, tipoReporte, descriptorFecha, descriptorGrupo, reporteDebo, reporteMeDeben);

            var renderer = new PdfDocumentRenderer(unicode: true) { Document = doc };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filePath);
        }

        private static Document BuildDocument(
            Usuario usuario,
            string tipoReporte,
            string descriptorFecha,
            string descriptorGrupo,
            Reporte reporteDebo,
            Reporte reporteMeDeben)
        {
            var doc = new Document();
            doc.Info.Title = "Reporte de gastos";
            doc.Info.Author = "Tu app";

            var style = doc.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 9; // tamaño legible

            var section = doc.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.Orientation = MdOrientation.Landscape;
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1.5);

            var titulo = section.AddParagraph("Reporte de gastos");
            titulo.Format.Font.Size = 15;
            titulo.Format.Font.Bold = true;
            titulo.Format.SpaceAfter = Unit.FromPoint(6);

            var pInfo = section.AddParagraph(
                $"Usuario: {usuario?.NombreCompleto} ({usuario?.Identificacion})\n" +
                $"Tipo: {tipoReporte}{(string.IsNullOrWhiteSpace(descriptorGrupo) ? "" : $" | Grupo: {descriptorGrupo}")}\n" +
                $"Período: {descriptorFecha}\n" +
                $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}");
            pInfo.Format.SpaceAfter = Unit.FromPoint(8);

            if (reporteMeDeben?.DatosGastos?.Any() == true)
                AddReportBlock(section, "ME DEBEN", reporteMeDeben, "Total que me deben", isMeDeben: true);
            else
                section.AddParagraph("ME DEBEN: sin datos").Format.SpaceAfter = Unit.FromPoint(8);

            section.AddParagraph().AddLineBreak();

            if (reporteDebo?.DatosGastos?.Any() == true)
                AddReportBlock(section, "DEBO", reporteDebo, "Total que debo", isMeDeben: false);
            else
                section.AddParagraph("DEBO: sin datos").Format.SpaceAfter = Unit.FromPoint(8);

            section.Footers.Primary.AddParagraph("Documento generado automáticamente").Format.Font.Size = 7.5;

            return doc;
        }

        private static void AddReportBlock(Section section, string titulo, Reporte reporte, string totalEtiqueta, bool isMeDeben)
        {
            var head = section.AddParagraph(titulo);
            head.Format.Font.Size = 12;
            head.Format.Font.Bold = true;
            head.Format.SpaceBefore = Unit.FromPoint(4);
            head.Format.SpaceAfter = Unit.FromPoint(6);

            var table = section.AddTable();
            table.Borders.Width = 0.5;
            table.KeepTogether = false;                            // permite romper entre páginas
            table.Format.Font.Size = 9;

            // ===== Anchos fijos que caben en A4 Landscape con márgenes de 1.5 cm (total ≈ 26.0 cm) =====
            table.AddColumn(Unit.FromCentimeter(2.2)); // Grupo
            table.AddColumn(Unit.FromCentimeter(2.0)); // Fecha
            table.AddColumn(Unit.FromCentimeter(1.8)); // Tipo
            table.AddColumn(Unit.FromCentimeter(2.4)); // Registro
            table.AddColumn(Unit.FromCentimeter(2.4)); // Gasto
            table.AddColumn(Unit.FromCentimeter(7.0)); // Descripción
            table.AddColumn(Unit.FromCentimeter(2.2)); // Monto
            table.AddColumn(Unit.FromCentimeter(2.2)); // Debo/Me deben
            table.AddColumn(Unit.FromCentimeter(3.8)); // Deudores

            var header = table.AddRow();
            header.HeadingFormat = true;               // repetir encabezado en cada página
            header.Shading.Color = Colors.LightGray;
            header.Format.Font.Bold = true;

            header.Cells[0].AddParagraph("Grupo");
            header.Cells[1].AddParagraph("Fecha");
            header.Cells[2].AddParagraph("Tipo");
            header.Cells[3].AddParagraph("Registro");
            header.Cells[4].AddParagraph("Gasto");
            header.Cells[5].AddParagraph("Descripción");
            header.Cells[6].AddParagraph("Monto");
            header.Cells[7].AddParagraph(isMeDeben ? "Me deben" : "Debo");
            header.Cells[8].AddParagraph("Deudores");

            // Alineaciones horizontales
            for (int c = 0; c < table.Columns.Count; c++)
                table.Columns[c].Format.Alignment = ParagraphAlignment.Left;
            table.Columns[6].Format.Alignment = ParagraphAlignment.Right; // Monto
            table.Columns[7].Format.Alignment = ParagraphAlignment.Right; // Debo/Me deben

            var cultura = new CultureInfo("es-CR");

            foreach (var r in reporte.DatosGastos)
            {
                var row = table.AddRow();
                // Alineación vertical por celda (arriba)
                for (int i = 0; i < row.Cells.Count; i++)
                    row.Cells[i].VerticalAlignment = MdVAlign.Top;

                row.Cells[0].AddParagraph(r.Grupo ?? "");
                row.Cells[1].AddParagraph(r.Fecha.ToString("dd/MM/yyyy"));
                row.Cells[2].AddParagraph(reporte.Tipo ?? "");
                row.Cells[3].AddParagraph(r.Registro?.ToString() ?? "");
                row.Cells[4].AddParagraph(r.Gasto?.ToString() ?? "");
                row.Cells[5].AddParagraph(r.Descripcion ?? ""); // envuelve
                row.Cells[6].AddParagraph((r.TotalGasto).ToString("C2", cultura));
                row.Cells[7].AddParagraph(((isMeDeben ? r.MeDeben : r.Debo)).ToString("C2", cultura));
                row.Cells[8].AddParagraph(r.Deudores ?? "");
            }

            var total = section.AddParagraph();
            total.Format.SpaceBefore = Unit.FromPoint(4);
            total.Format.Font.Bold = true;
            total.AddText(isMeDeben
                ? $"{totalEtiqueta}: {reporte.TotalMeDeben.ToString("C2", cultura)}"
                : $"{totalEtiqueta}: {reporte.TotalDebo.ToString("C2", cultura)}");

            section.AddParagraph().AddLineBreak();
        }
    }
}
