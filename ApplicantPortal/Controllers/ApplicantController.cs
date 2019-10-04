using ApplicantPortal.Data;
using ApplicantPortal.Models;
using ApplicantPortal.Models.StudentDTO;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ApplicantPortal.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Index()
        {
            StudentSteps data = new StudentSteps();
            data.studentStep1 = new StudentStep1();
            data.studentStep2 = new StudentStep2();
            data.studentStep3 = new StudentStep3();
            Models.DDLBinding objBoard = new Models.DDLBinding("BoardMaster", "", "","");
            data.studentStep1.Boards = objBoard.GetData().Select(x => new ABoardMastrer()
            {
                Id = Convert.ToInt32(x.ID),
                Name=x.Name
            });
            Models.DDLBinding objDistricts = new Models.DDLBinding("DistrictMaster", "", "", "");
            data.studentStep1.Districts = objDistricts.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.ADistrictMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            data.studentStep2.step2Districts = data.studentStep1.Districts;
            data.studentStep3.step3Districts = data.studentStep1.Districts;

            Models.DDLBinding objYears = new Models.DDLBinding("YearMaster", "", "", "");
            data.studentStep1.Years = objYears.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AYearMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            Models.DDLBinding objColleges = new Models.DDLBinding("CollegeMaster", "", "", "");
            data.studentStep1.Colleges = objColleges.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.ACollegeMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            data.studentStep3.step3Colleges = data.studentStep1.Colleges;
            Models.DDLBinding objGender = new Models.DDLBinding("GenderMaster", "", "", "");
            data.studentStep2.Genders = objGender.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AGenderMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            Models.DDLBinding objMotherTounge = new Models.DDLBinding("MotherToungeMaster", "", "", "");
            data.studentStep2.MotherTounges = objMotherTounge.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AMotherToungeMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            Models.DDLBinding objNationality = new Models.DDLBinding("NationalityMaster", "", "", "");
            data.studentStep2.Nationalities = objNationality.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.ANationalityMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            Models.DDLBinding objReligion = new Models.DDLBinding("ReligionMaster", "", "", "");
            data.studentStep2.Religions = objReligion.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AReligionMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            Models.DDLBinding objBloodGroup = new Models.DDLBinding("BloodGroupMaster", "", "", "");
            data.studentStep2.BloodGroups = objBloodGroup.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.ABloodGroupMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            Models.DDLBinding objStates = new Models.DDLBinding("StateMaster", "", "", "");
            data.studentStep2.States = objStates.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AStateMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            Models.DDLBinding objBlocks = new Models.DDLBinding("BlockMaster", "", "", "");
            data.studentStep2.Blocks = objStates.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.ABlockMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            Models.DDLBinding objStreams = new Models.DDLBinding("StreamMaster", "", "", "");
            data.studentStep3.step3Streams = objStreams.GetData().Select(x => new ApplicantPortal.Models.StudentDTO.AStreamMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });

            return View(data);
        }
        //public ActionResult _StudentStep1()
        //{
        //    return PartialView("_StudentStep1");
        //}

        [HttpPost]
        public ActionResult StudentStep1(StudentStep1 data)
        {
            try
            {
                ModelState.Remove("PostedPhoto");
                ModelState.Remove("PostedSignature");
                if (ModelState.IsValid)
                {
                    TempData["Step1"] = data;
                    TempData.Keep();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                ex.SetLog(ex.Message);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult StudentStep2(StudentStep2 data)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    TempData["Step2"] = data;
                    TempData.Keep();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                ex.SetLog(ex.Message);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult StudentStep3(StudentStep3 data)
        {
            try
            {

                if (ModelState.IsValid)
                { 
                    StudAppDBEntities db = new StudAppDBEntities();
                    TempData["Step3"] = data;
                    TempData.Keep();
                    
                    var step1 = (StudentStep1)TempData["Step1"];
                    var step2 = (StudentStep2)TempData["Step2"];
                    var step3 = data;
                    ApplicationMaster app = new ApplicationMaster();
                    app.ApplicantName = step1.ApplicantName;
                    app.ApplicationNumber = DateTime.Now.ToString("MMddmmssff");
                    app.EntryDate = DateTime.Now;
                    app.BoardId = step1.BoardId;
                    app.PassingYearId = step1.PassingYearId;
                    app.ExamType = step1.ExamType=="Annual"?1:2;
                    app.BOD = Convert.ToDateTime(step1.BOD);
                    app.RollCode = step1.RollCode;
                    app.RollNumber = step1.RollNumber;
                    app.FatherName = step1.FatherName;
                    app.MotherName = step1.MotherName;
                    app.S10MaxiMarks = string.IsNullOrEmpty(step1.S10MaxiMarks)?0: Convert.ToInt32(step1.S10MaxiMarks);
                    app.S10TotalMarks = string.IsNullOrEmpty(step1.S10TotalMarks) ? 0 : Convert.ToInt32(step1.S10TotalMarks);
                    app.Is10Compartmentally = step1.Is10Compartmentally==null?false: (bool)step1.Is10Compartmentally;
                    app.SchoolName = step1.SchoolName;
                    app.SchoolAddress = step1.SchoolAddress;
                    app.DistrictId = step1.DistrictId;
                    app.YearOfJoin = step1.YearOfJoin;
                    app.YearOfLeaving = step1.YearOfLeaving;
                    app.Gender = step2.GenderId.ToString();
                    app.MotherTongue = step2.MotherToungueId.ToString();
                    app.Nationality = step2.Nationalityid.ToString();
                    app.Religion = step2.ReligionId.ToString();
                    app.BloodGroup = step2.BloodGroupId.ToString();
                    app.State = step2.StateId.ToString();
                    app.District = step2.AddressDistrictId.ToString();
                    app.Block = step2.BlockId.ToString();
                    app.HouseAddress = step2.HouseNo.ToString();
                    app.PinCode = step2.PinCode.ToString();
                    app.MobileNo = step2.MobileNo.ToString();
                    app.Email = step2.Email.ToString();
                    if (!string.IsNullOrEmpty(step2.STD) && !string.IsNullOrEmpty(step2.PhoneNo))
                    {
                        app.TelephoneNo = step2.STD.ToString() + "-" + step2.PhoneNo;
                    }
                    app.ReservationId = Convert.ToInt16(step2.Cast);
                    app.EWS = Convert.ToInt16(step2.EWS);
                    if (!string.IsNullOrEmpty(step2.IsSpeciallyAbled))
                    {
                        app.SpecialAbied = (step2.IsSpeciallyAbled == "No") ? 0 : 1;
                    }
                   
                    app.IsActive = true;
                    db.ApplicationMasters.Add(app);
                    int id=db.SaveChanges();
                    if(id > 0)
                    {
                        AppCollegeMaster dt = new AppCollegeMaster();
                        dt.ApllicationId = id;
                        dt.CollegeId = step3.step3CollegeId;
                        dt.DistrictId = step3.step3DistrictId;
                        dt.StremId = step3.StreamId;
                        db.AppCollegeMasters.Add(dt);
                        db.SaveChanges();
                        var data_Application = GetStudentbyId(id);
                        string htmlString = null;
                        using (FileStream fs = System.IO.File.Open(HttpContext.Server.MapPath("~/form/form.html"), FileMode.Open, FileAccess.ReadWrite))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                htmlString = sr.ReadToEnd();
                            }
                        }
                        //GenrateHtmlTPDF(htmlString, data_Application);
                        //byte[] bytes = Encoding.Default.GetBytes(htmlString);
                        var html = htmlString;
                        html = html.Replace("@@college1", "3");
                        html = html.Replace("@@college2", "1");
                        html = html.Replace("@@college3", "0");
                        html = html.Replace("@@college4", "1");
                        html = html.Replace("@@college5", "1");
                        var RegNo = app.ApplicationNumber.ToString().Select(x => new string(x, 1)).ToArray();
                        for (var i = 0; i < RegNo.Count(); i++)
                        {
                            html = html.Replace("@@Reg" + (i+1), RegNo[i]);
                        }
                        html = html.Replace("@@RegisterationNo", app.RollNumber.ToString());
                        html = html.Replace("@@CollegeName", "L.S COLLEGE,MUZZAFARPUR");
                        html = html.Replace("@@StudentName", step1.ApplicantName);
                        html = html.Replace("@@FatherName", step1.FatherName);
                        html = html.Replace("@@MotherName", step1.MotherName);
                        html = html.Replace("value="+step2.GenderId, "value=" + step2.GenderId+" checked='checked'");
                        html = html.Replace("value=Cast" + step2.Cast, "value=Cast" + step2.Cast + " checked='checked'");
                        var res = step2.MobileNo.Select(x => new string(x, 1)).ToArray();
                        for(var i = 0; i < res.Count(); i++)
                        {
                            html = html.Replace("@@Mobile"+i, res[i]);
                        }
                        html = html.Replace("@@Email", step2.Email);
                        var Rcode = step1.RollCode.Select(x => new string(x, 1)).ToArray();
                        for (var i = 0; i < Rcode.Count(); i++)
                        {
                            html = html.Replace("@@RollCode" + i, Rcode[i]);
                        }
                        var RNumber = step1.RollNumber.Select(x => new string(x, 1)).ToArray();
                        for (var i = 0; i < RNumber.Count(); i++)
                        {
                            html = html.Replace("@@RollNumber" + i, RNumber[i]);
                        }
                        var year = db.YearMasters.Where(a => a.Year == step1.PassingYearId).FirstOrDefault().Year.ToString();
                        var sYear= year.Select(x => new string(x, 1)).ToArray();
                        for (var i = 0; i < sYear.Count(); i++)
                        {
                            html = html.Replace("@@PYear" + i, sYear[i]);
                        }
                        byte[] bytes = Encoding.Default.GetBytes(html);//
                        TempData["html"] = html;
                        TempData.Keep();
                        // System.IO.File.Create(HttpContext.Server.MapPath("~/applicant/data.pdf"));
                        System.IO.File.WriteAllBytes(HttpContext.Server.MapPath("~/applicant/data1.pdf"), bytes);
                    }

                    return Json(new { result = true, path = "data1.pdf" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                ex.SetLog(ex.Message);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

      
        public ApplicationMaster GetStudentbyId(int id)
        {

            try
            {
                StudAppDBEntities db = new StudAppDBEntities();
                var data = db.ApplicationMasters.Where(a => a.ApplicationId == id).FirstOrDefault();
                return data;
            }
            catch (Exception)
            {

                return (dynamic)null;
            }
        }

        public string GenrateHtmlTPDF(string html,ApplicationMaster data)
        {
            try
            {
                //if (System.IO.File.Exists(HttpContext.Server.MapPath("~/applicant/data.pdf"))){
                //    System.IO.File.Delete(HttpContext.Server.MapPath("~/applicant/data.pdf"));
                //}
                //System.IO.File.Create(HttpContext.Server.MapPath("~/applicant/data.pdf"));
               
                Download(HttpContext.Server.MapPath("~/applicant/data.pdf"));
                return "true";
            }
            catch (Exception ex)
            {

                return "false";
            }
        }
        
        public FileResult Download(string path)
        {
            var htmlToPdf = new HtmlToPdfConverter();

            var pdfContentType = "application/pdf";
            TempData.Keep();
            var sData = (dynamic)null;
            if (Session["sData"] == null)
            {
                 sData = TempData["html"];
                Session["sData"] = sData;
                return File(htmlToPdf.GeneratePdf(sData, null), pdfContentType);
            }
            else
            {
                sData=Session["sData"] ;
                return File(htmlToPdf.GeneratePdf(sData, null), pdfContentType);
            }
           
            
            //byte[] fileBytes = System.IO.File.ReadAllBytes(HttpContext.Server.MapPath("~/applicant/"+path));
            //string fileName = path;
            //MemoryStream workStream = new MemoryStream();
            //workStream.Write(fileBytes, 0, fileBytes.Length);
            //workStream.Position = 0;
            //return File(workStream.ToArray(), "application/pdf", fileName);
            //using (MemoryStream pdfStream = new MemoryStream())
            //{
            //    pdfStream.Write(fileBytes, 0, fileBytes.Length);
            //    pdfStream.Position = 0;
            //    return new FIle(pdfStream, "application/pdf");
            //}   
        }
    }
}