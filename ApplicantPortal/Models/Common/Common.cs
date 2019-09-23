
using ApplicantPortal.Models;


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ApplicantPortal
{
    public class Common
    {
        dalc odal = new dalc();
        public string fileupload(HttpPostedFileBase fu, string foldername, int width, int height)
        {
            string filename = "";
            if (fu.FileName != "")
            {
                //string filename1 = Path.GetFileNameWithoutExtension(fu.FileName);
                string ext = Path.GetExtension(fu.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG" || ext == ".GIF")
                {
                    Stream strm = fu.InputStream;
                    // fu.SaveAs(HttpContext.Current.Server.MapPath("~/ProductImages" + filename)); 
                    filename = Guid.NewGuid() + Path.GetExtension(fu.FileName);
                    string filenamewithpath = "~/" + foldername + "/" + filename;
                    GenerateThumbnails(strm, filenamewithpath, width, height);
                }

            }
            return filename;
        }
        public string fileDocupload(HttpPostedFileBase fu, int Filename, string foldername)
        {
            string filename = "";
            if (fu.FileName != "")
            {

                //string filename1 = Path.GetFileNameWithoutExtension(fu.FileName);
                string ext = Path.GetExtension(fu.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG" || ext == ".GIF" || ext == ".pdf" || ext == ".doc" || ext == ".PDF" || ext == ".DOC")
                {
                    Stream strm = fu.InputStream;
                    // fu.SaveAs(HttpContext.Current.Server.MapPath("~/ProductImages" + filename)); 

                    if (ext != ".pdf" && ext != ".doc" && ext != ".PDF" && ext != ".DOC")
                    {
                        filename = Convert.ToString(Filename) + ".jpg";
                        string filenamewithpath = "~/" + foldername + "/" + filename;
                        string filenamewith = "~/" + foldername + "/" + Filename + ".pdf";
                        var image = System.Drawing.Image.FromStream(strm);
                        var thumbnailImg = new Bitmap(image);
                        var thumbGraph = Graphics.FromImage(thumbnailImg);
                        if (File.Exists(HttpContext.Current.Server.MapPath(Convert.ToString(filenamewithpath))) || File.Exists(HttpContext.Current.Server.MapPath(Convert.ToString(filenamewith))))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath(filenamewithpath));
                        }
                        thumbnailImg.Save(HttpContext.Current.Server.MapPath(filenamewithpath), image.RawFormat);
                    }
                    else
                    {
                        filename = Convert.ToString(Filename) + ".pdf";
                        string filenamewithpath = "~/" + foldername + "/" + filename;
                        var thumbnailDoc = filenamewithpath;
                        if (File.Exists(HttpContext.Current.Server.MapPath(filenamewithpath)))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath(filenamewithpath));
                        }

                        fu.SaveAs(HttpContext.Current.Server.MapPath(thumbnailDoc));
                        //thumbnailDoc.(HttpContext.Current.Server.MapPath(filenamewithpath));
                    }


                    //GenerateThumbnails(strm, filenamewithpath, width, height);
                }

            }
            return filename;
        }
        public static void GenerateThumbnails(Stream sourcePath, string targetPath, int width, int height)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = width;
                var newHeight = height;
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(HttpContext.Current.Server.MapPath(targetPath), image.RawFormat);
            }
        }
        //public DataTable GetAutoNumber(string type, string code = "", int codeId = 0)
        //{
        //    try
        //    {
        //        return odal.selectbyquerydt("select [gurjari_MySmartPickUpuser].[GetAutoNumber]('" + type + "','" + code + "','" + codeId + "')");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }
        //}
        public void sendmail(string toEmail, string strbody, string subject,bool IsBodyHtml = false,bool IsMultiple = false,string replyTo = null)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())

                {

                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SMTPEmail"]);

                    mailMessage.Subject = subject;

                    mailMessage.Body = strbody;

                    mailMessage.IsBodyHtml = IsBodyHtml;

                    if(!string.IsNullOrEmpty(replyTo))
                        mailMessage.ReplyToList.Add(new MailAddress(replyTo,"reply-to"));
                    
                    mailMessage.To.Add(new MailAddress(toEmail));

                    mailMessage.Priority = MailPriority.High;
                    SmtpClient smtp = new SmtpClient();

                    //smtp.Host = "smtp.gmail.com";
                    smtp.Host = ConfigurationManager.AppSettings["host"];


                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"]); ;

                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                    NetworkCred.UserName = ConfigurationManager.AppSettings["SMTPEmail"];//reading from web.config  

                    NetworkCred.Password = ConfigurationManager.AppSettings["SMTPPassword"]; //reading from web.config  

                    smtp.UseDefaultCredentials = true;

                    smtp.Credentials = NetworkCred;

                    /*smtp.Port = 587;*/ //reading from web.config  
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

                    smtp.Send(mailMessage);

                }
            }
            catch (Exception ex)
            {
                ex.SetLog("Email Sending Esception");

            }
            


            //try
            //{
            //    MailMessage objeto_mail = new MailMessage();
            //    objeto_mail.Subject = subject;
            //    objeto_mail.Body = strbody;
            //    objeto_mail.From = new MailAddress(fromEmail);
            //    if (IsMultiple)
            //    {
            //        string[] multi = toEmail.Split(',');
            //        foreach(var item in multi)
            //        {
            //            objeto_mail.To.Add(new MailAddress(item));
            //        }
            //    }
            //    else
            //    {
            //        objeto_mail.To.Add(new MailAddress(toEmail));
            //    }
            //    SmtpClient client = new SmtpClient();
            //    client.Host = "smtp.gmail.com";
            //    client.Port = 587;
            //    client.UseDefaultCredentials = true;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    //client.EnableSsl = true;
            //    objeto_mail.IsBodyHtml = IsBodyHtml;
            //    client.Credentials = new NetworkCredential(fromEmail,password);
            //    client.Send(objeto_mail);


            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("{0} Exception caught.", ex);
            //}
        }
        public void sendsms(string mobileno, string msg)
        {
            string createdURL = "http://sms.raininfotech.in/AppSendSMS?Username=GURJARI&Password=gurjari&SenderId=GURLTD&MobileNo=" + mobileno + "&Message=" + msg;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
            }
            catch (Exception generatedExceptionName)
            {
                Console.WriteLine("{0} Exception caught.", generatedExceptionName);
            }
        }

        public string createEmailBody(string PersonName, string HeaderDesc, string Information)
        {
            string body = string.Empty;
            //using streamreader for reading HtmlTemplate   
            using (StreamReader reader = new StreamReader(System.IO.Path.GetFileName("~/Content/Templates/ContactUserTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{PersonName}", PersonName); //replacing the required things  
            body = body.Replace("{HeaderDesc}", HeaderDesc); //replacing the required things  
                                                             //body = body.Replace("{Title}", title);
            body = body.Replace("{Information}", Information.Replace("\n", "<br />"));

            return body;
        }

        public string VCardFile(VCardData obj)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-disposition", string.Format("attachment; filename=\"{0}\";", "MyContact.VCF"));
                var str = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/ReportFormat/MyContact.VCF"));
                str = str.Replace("@@Name@@", obj.Name);
                str = str.Replace("@@number@@", obj.Mobileno);
                str = str.Replace("@@Email@@", obj.Email);
                str = str.Replace("@@Address@@", obj.Address);
                str = str.Replace("@@Company@@", obj.Company);
                str = str.Replace("@@ComPhone@@", obj.ComPhone);
                str = str.Replace("@@Website@@", obj.Website);
                str = str.Replace("@@ComAddress@@", obj.ComAddress);
                str = str.Replace("@@city@@", obj.city);
                str = str.Replace("@@state@@", obj.state);
                str = str.Replace("@@country@@", obj.country);
                str = str.Replace("@@Pincode@@", obj.Pincode);
                str = str.Replace("@@Telephone@@", obj.Telephone);

                return str;
            }
            catch (Exception generatedExceptionName)
            {
                Console.WriteLine("{0} Exception caught.", generatedExceptionName);
            }
            return null;
        }
        
        //public void sendmail(string email, string strbody, string subject)
        //{
        //    try
        //    {

        //        strbody += "<br /><br />If You Dont want any email / Unsubscribe from pipcoin than click on ";
        //        strbody = HttpContext.Current.Server.HtmlEncode(strbody);
        //        var request = (HttpWebRequest)WebRequest.Create("http://trans.mailingservice.in/Email/API/SendEmailXml.aspx");

        //        var postData = @"<apiinfo><api_user>7405249551</api_user><api_key>CBCDE</api_key><from>noreply@mypipcoins.com</from><fromname>My MySmartPickUp</fromname><replyto>noreply@mypipcoins.com</replyto><to>" + email + "</to><subject>" + subject + "</subject><body><html><body>" + strbody + "</body></html></body><spamlinkrequired>false</spamlinkrequired><unsubscribelinkrequired>false</unsubscribelinkrequired><scheduletime></scheduletime></apiinfo>";
        //        var data = System.Text.Encoding.ASCII.GetBytes(postData);

        //        request.Method = "POST";
        //        request.ContentType = "text/xml; charset=utf-8";
        //        request.ContentLength = data.Length;

        //        using (var stream = request.GetRequestStream())
        //        {
        //            stream.Write(data, 0, data.Length);
        //        }

        //        var response = (HttpWebResponse)request.GetResponse();

        //        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        //    }
        //    catch (Exception ex)
        //    {
        //        // lblmesg.Text = ex.ToString();
        //    }
        //}
    }

}
public class VCardData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Mobileno { get; set; }
    public string Company { get; set; }
    public string Website { get; set; }
    public string ComPhone { get; set; }
    public string ComAddress { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public string Pincode { get; set; }
    public string Telephone { get; set; }

}

public static class CommonFunctions
{

    public static int GetProperInt(this string str)
    {
        try
        {
            return Convert.ToInt32(str);
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static decimal GetProperDecimal(this string str)
    {
        try
        {
            return Convert.ToDecimal(str);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static DateTime? GetProperDate(this string str)
    {
        try
        {
            return Convert.ToDateTime(str);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static Dictionary<string, string> Response_Type = new Dictionary<string, string>
        {
            { "UPDATE", Messages.Update },
            { "INSERT", Messages.Insert },
            { "DUPLICATE" ,Messages.Duplicate },
            { "NOT FOUND",Messages.NotFound },
            { "DELETE" ,Messages.Delete}
        };
    public static T GetResponseValue<T>(string intValue) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new Exception("T must be an Enumeration type.");
        }
        T val = ((T[])Enum.GetValues(typeof(T)))[0];

        foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
        {
            if (enumValue.ToString().Equals(intValue))
            {
                val = enumValue;
                break;
            }
        }
        return val;
    }

    public static String MessageResponse(Dictionary<string, string> Data_Array, String find, string field)
    {
        var responseMsg = Data_Array.FirstOrDefault(x => x.Key == find).Value;
        return field + " " + responseMsg;
    }

    public static class Messages
    {
        public static String Update { get { return "Updated Successfully"; } }
        public static String Insert { get { return "Inserted Successfully"; } }
        public static String Delete { get { return "Deleted Successfully"; } }
        public static String Duplicate { get { return "Already Exists"; } }
        public static String Invalid { get { return "User Not found"; } }
        public static String NotFound { get { return "Not found"; } }

    }

    
}
