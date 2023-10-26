using controlValeMercaderia.Models;
using HtmlAgilityPack;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using System;
using System.Drawing;
using System.IO;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
using System.Collections.Generic;

namespace controlValeMercaderia.Controller
{
    internal class PDFCreator
    {
        DateTime date;
        private SMTP smtp;
        private MailMessage mCorreo;
        private Empresa dimak;
        private Connection_Empresa con_emp;
        private List<TipoVale> tipoValeList;
        private TipoValeConnectionDataBase tvCon;
        Trabajador worker;
        ValeMercaderia valeMercaderia;

        public PDFCreator()
        {
            prepareEnviroment();
        }
        private void prepareEnviroment()
        {
            date = DateTime.Now;
            llenarListTipoVale();
            getDataEmpresa();
        }
        private void getDataEmpresa()
        {
            con_emp = new Connection_Empresa();
            dimak = con_emp.getDatosDimak();
        }
        private void llenarListTipoVale()
        {
            tvCon = new TipoValeConnectionDataBase();
            tipoValeList = tvCon.getAllTipoVale();
        }
        public void createPDFWithHTML(Trabajador w,ValeMercaderia vM,bool save)
        {
            try
            {
                worker = w;
                valeMercaderia = vM;
                //DESIGN INPUT
                string BASEURI_INPUT = "./PDFDesign/input";
                string SRC = String.Format($"{BASEURI_INPUT}/design.html");

                ConverterProperties properties = new ConverterProperties();
                properties.SetBaseUri($"{BASEURI_INPUT}");

                string html = insertObjectInHTML(SRC); 

                //PDF OUTPUT
                string dateNow = getDateNowClean();
                string BASEURI_OUTPUT = "./PDFDesign/output";
                string fileName = $"{worker.rut}-{dateNow}.pdf";
                string DEST = Path.Combine(BASEURI_OUTPUT, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(DEST));

                PdfWriter writer;
                if(save)
                {
                    writer = new PdfWriter(DEST, new WriterProperties()
                        .SetFullCompressionMode(true)
                        );
                }
                else
                {
                    byte[] userPass = Encoding.ASCII.GetBytes(worker.rut);
                    byte[] adminPass = Encoding.ASCII.GetBytes("admin123");//ADMIN PASSWORD

                    writer = new PdfWriter(DEST, new WriterProperties()
                        .SetStandardEncryption(userPass,adminPass,EncryptionConstants.ALLOW_PRINTING,EncryptionConstants.ENCRYPTION_AES_256)
                        );
                }

                PdfDocument pdf = new PdfDocument(writer);
                pdf.SetTagged();
                
                HtmlConverter.ConvertToPdf(html,pdf, properties);
                
                if(save)
                {
                    //Open PDF
                    Process.Start(DEST);
                }
                else
                {
                    sendValeToEmail(DEST);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al convertir "+ex);
            }
        }
        private string insertObjectInHTML(string src)
        {
            HtmlDocument doc = new HtmlDocument();   
            doc.Load(src);

            CalcularDigitoVerificador cdv = new CalcularDigitoVerificador(worker.rut);
            string nameCompleteWorker = $"{worker.nombre} {worker.apellido_paterno} {worker.apellido_materno}";
            doc.DocumentNode.SelectSingleNode("//section/article/h3").InnerHtml = nameCompleteWorker;
            doc.DocumentNode.SelectSingleNode("//body/section/article/p").InnerHtml = cdv.getRutFormateado();
            
            //Fecha
            string fecha = $"{valeMercaderia.fecha_emision.Day}-{valeMercaderia.fecha_emision.Month}-{valeMercaderia.fecha_emision.Year}";
            doc.DocumentNode.SelectSingleNode("//body/header/div/div/p").InnerHtml = fecha;

            //Tramo
            doc.DocumentNode.SelectSingleNode("//body/header/div/article/div/p").InnerHtml = worker.tramo;

            //TipoVale
            doc.DocumentNode.SelectSingleNode("//body/section/div/h2").InnerHtml = getTipoVale(valeMercaderia.tipo_vale);

            //Monto
            doc.DocumentNode.SelectSingleNode("//body/section/div/h3").InnerHtml = valeMercaderia.getMontoFormateado();

            //Monto Letras
            doc.DocumentNode.SelectSingleNode("//body/section/div/p").InnerHtml = $"{valeMercaderia.getMontoEnLetras()} pesos";

            //Barcdode
            string codebarBase64 = convertBitmapToBase64(valeMercaderia.barcode);
            HtmlNode imgBarCode = doc.DocumentNode.SelectSingleNode("//footer/div/article/img");
            imgBarCode.SetAttributeValue("src", $"data:image/png;base64,{codebarBase64}");

            //QRCode
            string imgBase64 = convertBitmapToBase64(worker.QRCode);
            HtmlNode imgQRCode = doc.DocumentNode.SelectSingleNode("//footer/div/div/img");
            imgQRCode.SetAttributeValue("src", $"data:image/png;base64,{imgBase64}");

            //Datos Dimak
            CalcularDigitoVerificador cdv_emp = new CalcularDigitoVerificador(dimak.rut);
            doc.DocumentNode.SelectSingleNode("//footer/article/div").InnerHtml = dimak.nombre;
            doc.DocumentNode.SelectSingleNode("//footer/article/article").InnerHtml = cdv_emp.getRutFormateado();

            //Asign Fecha_End
            string fechaEnd = $"{valeMercaderia.fecha_vencimiento.Day}-{valeMercaderia.fecha_vencimiento.Month}-{valeMercaderia.fecha_vencimiento.Year}";
            doc.DocumentNode.SelectSingleNode("//footer/div/p").InnerHtml = $"VENCE: {fechaEnd}";

            return doc.DocumentNode.InnerHtml;
        }
        private void sendValeToEmail(string DEST)
        {
            try
            {
                asignEmailDataSettings();
                using(mCorreo = new MailMessage())
                {
                    mCorreo.From = new MailAddress(smtp.email,smtp.alias,System.Text.Encoding.UTF8);
                    mCorreo.To.Add(worker.email);
                    mCorreo.Subject = "VALE MERCADERIA DIMAK";
                    mCorreo.Priority = MailPriority.High;
                    mCorreo.Body = getBodyHtml();
                    mCorreo.IsBodyHtml = true;
                    mCorreo.Headers.Add("Message-ID",Guid.NewGuid().ToString());
                    mCorreo.Attachments.Add(new Attachment(DEST));
                    sendMail();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("sendValeToEmail() => " + ex.ToString());
            }
        }
        private string getBodyHtml()
        {
            HtmlDocument doc = new HtmlDocument();

            doc.DetectEncodingAndLoad("./PDFDesign/input/bodyCorreo.html");

            doc.DocumentNode.SelectSingleNode("//div/p").InnerHtml = $"Estimado(a): {worker.nombre} {worker.apellido_paterno} {worker.apellido_materno}";
            
            string html = doc.DocumentNode.InnerHtml;

            return html;
            
        }
        public bool sendTestMail()
        {
            try
            {
                asignEmailDataSettings();
                using(mCorreo = new MailMessage())
                {
                    mCorreo.From = new MailAddress(smtp.email,smtp.alias,System.Text.Encoding.UTF8);
                    mCorreo.To.Add(smtp.email);
                    mCorreo.Subject = "Email de prueba";
                    mCorreo.Body = "Este es un mail de prueba, enviado desde aplicación Csharp";
                    sendMail();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("sendTestMail() => "+ex.ToString());
                return false;
            }
        }
        private void sendMail()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = smtp.smtp_port;
                smtpClient.Host = smtp.smtp_host;
                smtpClient.Credentials = new System.Net.NetworkCredential(smtp.email, smtp.password);
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
                smtpClient.EnableSsl = true;

                smtpClient.Send(mCorreo);
            }
            catch (Exception smtEx)
            {
                Console.WriteLine($"smtpEx => {smtEx.ToString()}");
            }  
        }
        private void asignEmailDataSettings()
        {
            try
            {
                Connection_SMTP con_smtp = new Connection_SMTP();
                smtp = con_smtp.getDataConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error => "+ex.ToString());
            }
        }
        private string convertBitmapToBase64(Bitmap btmp)
        {
            string imgBase64;
            using (MemoryStream ms = new MemoryStream())
            {
                btmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageByte = ms.ToArray();
                imgBase64 = Convert.ToBase64String(imageByte);
            }
            return imgBase64;
        }
        private string getTipoVale(int id_tipoVale)
        {
            if(tipoValeList != null)
            {
                foreach(TipoVale tv in tipoValeList)
                {
                    if(tv.id == id_tipoVale)
                    {
                        return tv.nombre.Trim().ToUpper();
                    }
                }
            }
            return string.Empty;
        }
        private string getDateNowClean()
        {
            return date.ToString().Replace(" ", "").Replace(":", "").Replace("-", "");
        }
    }
}
