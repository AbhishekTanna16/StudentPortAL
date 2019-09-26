using ApplicantPortal.Data;
using ApplicantPortal.Models;
using ApplicantPortal.Models.StudentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    }

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                ex.SetLog(ex.Message);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}