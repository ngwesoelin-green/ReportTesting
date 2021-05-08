using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ReportTesting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public FileResult Export_iTextSharp(string GridHtml)
        {
            GridHtml = "<b>Test</b>";
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }

        public byte[] createPDFSample()
        {
            MemoryStream memStream = new MemoryStream();
            byte[] pdfBytes;

            Document doc = new Document(iTextSharp.text.PageSize.LETTER);
            PdfWriter wri = PdfWriter.GetInstance(doc, memStream);
            doc.AddTitle("test");
            doc.AddCreator("I am");

            doc.Open();//Open Document to write
            Paragraph paragraph = new Paragraph("This is my first line using Paragraph.");
            Phrase pharse = new Phrase("This is my second line using Pharse.");
            Chunk chunk = new Chunk(" This is my third line using Chunk.");
            doc.Add(paragraph);
            doc.Add(pharse);
            doc.Add(chunk);
            pdfBytes = memStream.ToArray();
            doc.Close(); //Close 
            return pdfBytes;
        }
        public string GetGood1()
        {
            byte[] b = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/" + "Untitled2.png"));
            var base64img = "data:image/jpg;base64," + Convert.ToBase64String(b);
            return base64img;
        }
        public ActionResult GetGood2()
        {
            Byte[] b = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/" + "Untitled2.png"));
            return File(b, "image/jpeg");
        }
        public HttpResponseMessage GetJustMediaTypeHeaderRef()
        {
            using (FileStream fs = new FileStream(Server.MapPath("~/PDF/" + "INDO RAKHINE.pdf"), FileMode.Open))
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StreamContent(fs);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                return response;
            }
        }

        
    }
}