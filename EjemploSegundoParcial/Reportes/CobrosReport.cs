using EjemploSegundoParcial.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.Reportes
{
    public class CobrosReport
    {
        int columnas = 4;
        Document document;
        PdfPTable pdfPTable;
        PdfPCell pdfCell = new PdfPCell();
        Font fontStyle, fontFecha, Titulo;
        MemoryStream Memory = new MemoryStream();
        List<Cobros> listaCobros = new List<Cobros>() {
                new Cobros(1, DateTime.Now, "Oliver", 5000),
                new Cobros(2, DateTime.Now, "Juan", 4000),
                new Cobros(3, DateTime.Now, "Pedro", 6000),
                new Cobros(4, DateTime.Now, "Martin", 7000)
            };



        public byte[] Reporte()
        {
            document = new Document(PageSize.Letter, 25f, 25f, 20f, 20f);
            pdfPTable = new PdfPTable(columnas);



            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);
            PdfWriter.GetInstance(document, Memory);
            document.Open();



            float[] anchoColumnas = new float[columnas];



            anchoColumnas[0] = 50; //Esta sera la fila 1 cobroid
            anchoColumnas[1] = 60; //Esta sera la fila 2 fecha
            anchoColumnas[2] = 50; //Esta sera la fila 3 nombre
            anchoColumnas[3] = 50; //Esta sera la fila 4 monto



            pdfPTable.SetWidths(anchoColumnas);



            this.ReportHeader();
            this.ReportBody();



            pdfPTable.HeaderRows = 1;
            document.Add(pdfPTable);
            document.Close();



            return Memory.ToArray();
        }

        private void ReportHeader()
        {
            //pdfCell = new PdfPCell(this.AddLogo());
            pdfCell.Colspan = 1;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);




            pdfCell = new PdfPCell(this.setPageTitle());
            pdfCell.Colspan = columnas;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();
        }

        private PdfPTable setPageTitle()
        {
            int maxColumn = 2;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);



            fontStyle = FontFactory.GetFont("Calibri", 18f, 1);
            fontFecha = FontFactory.GetFont("Calibri", 10f, 1);
            Titulo = FontFactory.GetFont("Calibri", 25f, 1);



            pdfCell = new PdfPCell(new Phrase("Nombre de la empresa", Titulo));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();



            pdfCell = new PdfPCell(new Phrase("Reporte de Cobros", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();



            pdfCell = new PdfPCell(new Phrase(DateTime.Now.ToString("MM/dd/yyyy H:mm tt"), fontFecha));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();



            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();



            return pdfPTable;
        }

        private void ReportBody()
        {
            fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            var _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);



            #region Table Header
            pdfCell = new PdfPCell(new Phrase("ID", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);



            pdfCell = new PdfPCell(new Phrase("Cliente", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);




            pdfCell = new PdfPCell(new Phrase("Fecha", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);




            pdfCell = new PdfPCell(new Phrase("Monto", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfPTable.AddCell(pdfCell);



            pdfPTable.CompleteRow();
            #endregion



            #region Table Body
            int num = 0;




            foreach (var item in listaCobros)
            {
                num++;
                pdfCell = new PdfPCell(new Phrase(item.CobroId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);



                //pdfCell = new PdfPCell(new Phrase(ClientesBLL.Buscar(item.ClienteId).Nombre + " " + ClientesBLL.Buscar(item.ClienteId).Apellido, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);




                pdfCell = new PdfPCell(new Phrase(item.Fecha.ToString("MM/dd/yyyy H:mm tt"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);




                pdfCell = new PdfPCell(new Phrase(item.Monto.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell.BackgroundColor = BaseColor.White;
                pdfPTable.AddCell(pdfCell);




                pdfPTable.CompleteRow();



            }



            pdfCell = new PdfPCell(new Phrase(num++.ToString(), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);



            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);



            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);



            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfPTable.AddCell(pdfCell);




            pdfPTable.CompleteRow();
            #endregion
        }
    }
}
