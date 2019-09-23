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
            Models.DDLBinding objBoard = new Models.DDLBinding("BoardMaster", "", "","");
            data.studentStep1.Boards = objBoard.GetData().Select(x => new BoardMastrer()
            {
                Id = Convert.ToInt32(x.ID),
                Name=x.Name
            });
            Models.DDLBinding objDistricts = new Models.DDLBinding("DistrictMaster", "", "", "");
            data.studentStep1.Districts = objDistricts.GetData().Select(x => new DistrictMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            Models.DDLBinding objYears = new Models.DDLBinding("YearMaster", "", "", "");
            data.studentStep1.Years = objYears.GetData().Select(x => new YearMaster()
            {
                Id = Convert.ToInt32(x.ID),
                Name = x.Name
            });
            Models.DDLBinding objColleges = new Models.DDLBinding("CollegeMaster", "", "", "");
            data.studentStep1.Colleges = objColleges.GetData().Select(x => new CollegeMaster()
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
                    Session["Step1"] = data;
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