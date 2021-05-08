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
    public class AboutModel
    {
        public string HtmlContent { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            AboutModel model = new AboutModel();
            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult About(AboutModel model)
        {

            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public FileResult Export()
        {
            string HtmlContent = Server.HtmlDecode(@"
                    &lt;h3 style=&quot;text-transform:uppercase;text-align:center;font-weight:bold;&quot;&gt;Invoice&lt;/h3&gt;
    &lt;table style=&quot;width:100%;font-size:10pt;&quot; border=&quot;0&quot;&gt;
        &lt;tr&gt;
            &lt;td style=&quot;text-align:right;width:20%;padding:5px;&quot;&gt;Customer Account No :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;width:35%;padding:5px;&quot;&gt;YGNFX0070234&lt;/td&gt;
            &lt;td style=&quot;text-align:right;width:20%;padding:5px;&quot;&gt;Invoice No. :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;width:20%;padding:5px;&quot;&gt;INV0000000860957&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td style=&quot;text-align:right;padding:5px;&quot;&gt;Customer Name :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;Ngwe Soe Lin&lt;/td&gt;
            &lt;td style=&quot;text-align:right;padding: 5px;&quot;&gt;Invoice Date :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;01-05-2021&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td style=&quot;text-align:right;padding:5px;&quot;&gt;Address : &lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;No.(14/D), (7) ward, Maykha street,Mayangon, Yangon, Myanmar&lt;/td&gt;
            &lt;td style=&quot;text-align:right;padding:5px;&quot;&gt;Due Date :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;11-05-2021&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;/td&gt;
            &lt;td&gt;&lt;/td&gt;
            &lt;td style=&quot;text-align:right;padding:5px;&quot;&gt;Email Address :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;ngwesoelin@gmail.com&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td&gt;&lt;/td&gt;
            &lt;td&gt;&lt;/td&gt;
            &lt;td style=&quot;text-align:right;padding:5px;&quot;&gt;Activation Date :&amp;nbsp;&lt;/td&gt;
            &lt;td style=&quot;padding: 5px;&quot;&gt;19-11-2019&lt;/td&gt;
        &lt;/tr&gt;
    &lt;/table&gt;
    &lt;br /&gt;

    &lt;table id=&quot;tbl2&quot; style=&quot;width:100%;border-collapse:collapse;font-size:10pt;&quot;&gt;
        &lt;tr style=&quot;border:0px solid black;&quot;&gt;
            &lt;th style=&quot;padding:8px;text-align:center;border:1px solid black;border-right:0;border-bottom:0;&quot;&gt;Bill Month&lt;/th&gt;
            &lt;th style=&quot;padding:8px;text-align:center;border:1px solid black;border-right:0;border-bottom:0;&quot;&gt;Description&lt;/th&gt;
            &lt;th style=&quot;padding:8px;text-align:center;border:1px solid black;border-right:0;border-bottom:0;&quot;&gt;Service Plan&lt;/th&gt;
            &lt;th style=&quot;padding:8px;text-align:center;border:1px solid black;border-bottom:0;&quot;&gt;Amount (MMK)&lt;/th&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:0px solid black;&quot;&gt;
            &lt;td style=&quot;padding:8px;text-align:center;border:1px solid black;border-right:0;&quot;&gt;Apr-2021&lt;/td&gt;
            &lt;td style=&quot;padding:8px;text-align:left;border:1px solid black;border-right:0;&quot;&gt;Monthly Fee&lt;/td&gt;
            &lt;td style=&quot;padding:8px;text-align:left;border:1px solid black;border-right:0;&quot;&gt;XXSPlus_Special : 01/04/2021 - 30/04/2021&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;&quot;&gt;20000&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Charges :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;border-top:0;&quot;&gt;20000&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Discount :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;&quot;&gt;20000&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Deposit :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;&quot;&gt;-2000&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Adjustment :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;&quot;&gt;0&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Current Charges :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;font-weight:bold;border:1px solid black;border-bottom:0;&quot;&gt;80001&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Previous Due Amount :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;&quot;&gt;98001&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Paid Amount :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;border:1px solid black;border-bottom:0;&quot;&gt;-96001&lt;/td&gt;
        &lt;/tr&gt;
        &lt;tr style=&quot;border:1px solid black;&quot;&gt;
            &lt;td colspan=&quot;3&quot; style=&quot;padding:8px;text-align:right;border-left:1px solid white;border-top:1px solid white;border-bottom:1px solid white;&quot;&gt;Total Payable Amount :&lt;/td&gt;
            &lt;td style=&quot;padding:8px 2px 8px 8px;text-align:right;font-weight:bold;border:1px solid black;&quot;&gt;18000&lt;/td&gt;
        &lt;/tr&gt;
    &lt;/table&gt;

    &lt;div style=&quot;height:220px;&quot;&gt;&lt;/div&gt;

    &lt;footer&gt;
        &lt;p style=&quot;font-weight:bold;bottom:0px;&quot;&gt;* This is a computer-generated letter, and does not require a signature&lt;/p&gt;

&lt;pre style=&quot;border:0;background:white;font-family:serif;font-size:8.5pt;&quot;&gt;
No.471, Pyay Road, Kamayut Township,
Yangon, Myanmar.
Tel: 01 524978, 09 422686977, 09 422686988
Billing Phone: 09 426060260,09 403438511
Webiste : www.5bb.com.mm
&lt;/pre&gt;
    &lt;/footer&gt;");



            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                string imageURL = Server.MapPath("~/Images/" + "5BBLogo.png");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                //Resize image depend upon your need
                jpg.ScaleToFit(200f, 142f);
                //Give space before image
                //jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                //jpg.Alignment = Element.ALIGN_LEFT;
                jpg.SetAbsolutePosition(50, 720);


                StringReader sr = new StringReader(HtmlContent);
                Document pdfDoc = new Document(PageSize.A4, 25f, 25f, 110f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(jpg);
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