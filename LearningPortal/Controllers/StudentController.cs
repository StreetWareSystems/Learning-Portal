using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningPortal.Models;


namespace LearningPortal.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        public ApplicationDbContext Db = new ApplicationDbContext();
        // GET: Student
    
        public ActionResult StudentDashboard()
        {
            return View();
        }
      

        public PartialViewResult Menu()
        {
            var ls = Db.Categories.ToList();
            //DataSet ds = dblayer.get_category();
            //ViewBag.category = ds.Tables[0];

            Session["Menu"] = ls;

            return PartialView();
        }


        // Get submenu
        public void get_Submenu(int catid)
        {
            var subCat = Db.SubCategories.Where(i => i.CategoryId == catid).ToList();
            Session["submenu"] = subCat;
        }

        // Get Subtosubmenu
        public void get_Subtosubmenu(int Subcat_id)
        {
            var cour = Db.Courses.Where(i => i.SubCategoryId == Subcat_id).ToList();
            Session["subtosubmenu"] = cour;
        }

        public PartialViewResult ResumeCourse()
        {
            var course = Db.Courses.Where(e=>e.IsFeatured==true).ToList();
         
            return PartialView(course);
        }

        public PartialViewResult FeaturedCourse()
        {
            var course = Db.Courses.Where(e => e.IsFeatured == false).ToList();
           // var course = Db.Courses.SqlQuery("select * from Courses where IsFeatured = 'False'").ToList();

            return PartialView(course);
        }

        public ActionResult StudentCourse(int? id)
        {
            var courses = Db.Courses.Find(id)
;

            string Section = "Section " + courses.Sections.Count();
            int videocount = 0;
            foreach (var item in courses.Sections)
            {
                videocount = videocount + item.SectionMedia.Count();
            }
            string Video = " - Videos " + videocount;

            ViewBag.data = Section + Video;
            return View(courses);
        }

    }
}