using LearningPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningPortal.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        public ApplicationDbContext Db = new ApplicationDbContext();

        // GET: Student
       
        public ActionResult StudentDashboard(string id)
        {
            if (id!=null)
            {
                return RedirectToAction("Error404", "Error");
            }
            var featurecourse = Db.Courses.SqlQuery("Select * from Courses where IsFeatured = 1").ToList();
            
            var resumecourse = Db.Courses.SqlQuery("select  DISTINCT cor.*  from Courses cor inner join Sections sCat on cor.CourseId = sCat.CourseId inner join SectionMedias cat on cat.SectionId = sCat.SectionId inner join UserMediaHistories useMedHis on useMedHis.SectionMediaId = cat.SectionMediaId inner join AspNetUsers netUse on netUse.Id = useMedHis.UserId where netUse.Id = '" + User.Identity.GetUserId() + "'  order by cor.Time desc").ToList();



            ViewBag.count = resumecourse.Count();
            ViewBag.fc = featurecourse.Count();
     
            ViewBag.rc = resumecourse.ToList();
            return View(featurecourse);

           

        }


        public ActionResult search(string SearchString)
        {

            var searchResult = Db.Courses.Where(x => x.CourseName.Contains(SearchString)).ToList();

            
                ViewBag.count = searchResult.Count();
            
           
            return View(searchResult);
        }

        /*DropDown*/
        public PartialViewResult Menu()
        {
            var ls = Db.Categories.OrderBy(x => x.Time).ToList(); 
            System.Web.HttpRuntime.Cache["Menu"] = ls;
            return PartialView();
        }
        // Get submenu
        public void get_Submenu(int catid)
        {
            var subCat = Db.SubCategories.Where(i => i.CategoryId == catid).OrderBy(x => x.Time).ToList();
            System.Web.HttpRuntime.Cache["submenu"] = subCat;
        }

        // Get Subtosubmenu
        public void get_Subtosubmenu(int Subcat_id)
        {
            var cour = Db.Courses.Where(i => i.SubCategoryId == Subcat_id).OrderBy(x => x.Time).ToList();
            System.Web.HttpRuntime.Cache["subtosubmenu"] = cour;
        }

        /* End DropDown*/

        /*View All Catagory*/
        public ActionResult ViewAllCategory()
        {

            var cat = Db.Categories.OrderBy(x => x.Time).ToList();
            return PartialView(cat);
        }
        /*End of All Catagory*/

        /*View All SubCategory*/
        public ActionResult ViewAllSubCategory(string id)
        {
            if (id == null)
            {
               return View("Error404", "Error");
            }
            string tempid = id;
            id = id.Replace('!', '+');
            id = id.Replace('%', 'a');
            var decsc = helpper.Decrypto(id.Replace('$', '/'));
           
            if (decsc == "")
            {

                return RedirectToAction("Error404", "Error");


            }
            else
            {
                int cid = Convert.ToInt32(decsc);

                string Cat = "";
                var subcat = Db.SubCategories.Where(i => i.CategoryId == cid).ToList();


                foreach (var item in subcat)
                {

                    Cat = item.Categories.CategoryName;
                }

                ViewBag.BreadCrumbCat = Cat;
                Session["sid"] = tempid;



                return PartialView(subcat);
            }
               
        }

        /* ENd View All SubCategory*/

        /*View All Course*/
        public ActionResult ViewAllCourse(string id)
         {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }
            string tempid = id;
            id = id.Replace('!', '+');
            id = id.Replace('%', 'a');
            var decsc = helpper.Decrypto(id.Replace('$', '/'));

            if (decsc == "")
            {
                return RedirectToAction("Error404", "Error");

            }
            else
            {
                int sbid = Convert.ToInt32(decsc);


                int courseId = 0;
                var course = Db.Courses.Where(i => i.SubCategoryId == sbid).ToList();

                foreach (var item in course)
                {
                    courseId = item.CourseId;
                }

                var subcat = Db.SubCategories.Find(sbid);


                ViewBag.BreadCrumbCatID = subcat.Categories.CategoryId;
                ViewBag.BreadCrumbCat = subcat.Categories.CategoryName;
                ViewBag.BreadCrumbSubCat = subcat.SubCategoryName;

                ViewBag.id = courseId;
                Session["cidall"] = tempid;
                return PartialView(course);
            }

        }

        /* ENd View All Course*/

        /*ResumeCourse */
        public PartialViewResult ResumeCourse(string UserId)
        {

            var course = Db.Courses.SqlQuery("select  DISTINCT cor.*  from Courses cor inner join Sections sCat on cor.CourseId = sCat.CourseId inner join SectionMedias cat on cat.SectionId = sCat.SectionId inner join UserMediaHistories useMedHis on useMedHis.SectionMediaId = cat.SectionMediaId inner join AspNetUsers netUse on netUse.Id = useMedHis.UserId where netUse.Id = '" + UserId + "'").ToList();
            ViewBag.Counts = course.Count();
            return PartialView(course);
        }

        /*End ResumeCourse */


        /*FeaturedCourse */
        public PartialViewResult FeaturedCourse(string UserId)
        {
            //List<LearningPortal.Models.Courses> course = new List<LearningPortal.Models.Courses>();
                var course1 = Db.Courses.SqlQuery("Select * from Courses where Courses.CourseId NOT IN (select Distinct(Courses.CourseId) from  Courses join Sections on Courses.CourseId = Sections.CourseId join SectionMedias on Sections.SectionId = SectionMedias.SectionId join UserMediaHistories on SectionMedias.SectionMediaId = UserMediaHistories.SectionMediaId join AspNetUsers on UserMediaHistories.UserId = AspNetUsers.Id where AspNetUsers.Id = '" + UserId + "')and IsFeatured = 1").ToList();
                return PartialView(course1);
        }

        /*End FeaturedCourse*/


        /* StudentCourse */
    
        public ActionResult StudentCourse(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");   
            }

            string tempid = id;
            // var idd = Convert.ToString(id);
            //var DecryptId = helpper.Decrypt(idd);
            id = id.Replace('!', '+');
            id = id.Replace('%', 'a');

            var decsc= helpper.Decrypto(id.Replace('$','/'));
            
            if (decsc == "") {
                return RedirectToAction("Error404", "Error");
            }
            else
            {
                int cid = Convert.ToInt32(decsc);
                string userid = User.Identity.GetUserId();

                var courses = Db.Courses.Find(cid);
                string Section = courses.Sections.Count() + " Sections-";
                int videocount = 0, totalvideo = 0;
                foreach (var item in courses.Sections)
                {
                    videocount = videocount + item.SectionMedia.Count();
                    foreach (var item1 in item.SectionMedia)
                    {
                        totalvideo = totalvideo + item1.VideoDuration;
                    }


                }

                string Video = videocount + " Videos";

                ViewBag.data = Section + Video;
                ViewBag.totalduration = totalvideo;
                Session["cid"] = tempid;

                  return View(courses);
                }
           
        
        }
        [HttpGet]
        public PartialViewResult Sectons(string cid)
        {

            int coid = Convert.ToInt32(cid);
            var courses = Db.Courses.Find(coid);
          



            return PartialView(courses);
        }
        public ActionResult videoplayer(string cid ,int sid)
        {

            string userid = User.Identity.GetUserId();

          
            //var decs = helpper.Decrypto(sid);
            //if (decs == null)
            //{
            //    return PartialView();
            //}

            // Video Section 
            int id= Convert.ToInt32(cid);

            int sectionmediaid = Convert.ToInt32(sid);
            var playlist1 = Db.SectionMedia.Where(x => x.Section.CourseId == id).Select(x => x.SectionMediaId).ToList();
            var coursename = Db.Courses.Find(id).CourseName;
            var vname = Db.SectionMedia.Find(sectionmediaid).VideoTitle.ToString();
            var SECNAME = Db.SectionMedia.Find(sectionmediaid).Section.SectionName.ToString();
            int index = 0;
            int countloop = 0;
            ViewBag.playlist = playlist1;


            if (playlist1.Count() == 0)
            {

                return PartialView();
            }
            else
            {

                if (sectionmediaid == 0)
                {
                    index = 0;

                }
                else
                {
                    foreach (var item in playlist1)
                    {
                        if (item == sectionmediaid)
                        {

                            index = countloop;

                            break;
                        }
                        countloop++;
                    }
                }

                int media = playlist1[index];
              
                var check = Db.UserMediaHistories.Where(a => a.SectionMediaId == media && a.UserId == userid).FirstOrDefault();
                var startime = 0;

                //var updateUh = Db.UserMediaHistories.Where(a => a.SectionMediaId != media).ToList();
                //foreach(var item in updateUh)
                //{
                //    UserMediaHistory count = Db.UserMediaHistories.Where(a => a.SectionMediaId == item.SectionMediaId).FirstOrDefault();
                  
                //    count.UpdatedTime = false;
                //    //var sc = Db.UserMediaHistories.SqlQuery("update UserMediaHistories  set UpdatedTime=0 where UserMediaHistories.SectionMediaId !=" + number1);
                //    //db.UserMediaHistory.SqlQuery("update UserMediaHistories set UserMediaHistories.WatchedTime=" + number2 + "where UserMediaHistories.UserVideoHistoryId=" + count.UserVideoHistoryId);
                //    if (ModelState.IsValid)
                //    {
                //        //count.UpdatedTime = DateTime.Now;
                //        Db.Entry(count).State = EntityState.Modified;
                //        Db.SaveChanges();
                //    }
                //}
               
               

                if (check == null)
                {
                    //UserMediaHistory obj = new UserMediaHistory();
                    //obj.WatchedTime = startime;
                    //obj.UserId = userid;
                    ////obj.UpdatedTime = DateTime.Now;
                    //obj.UpdatedTime = true;
                  
                    //obj.SectionMediaId = playlist1[index];
                    
                    //Db.UserMediaHistories.Add(obj);
                    //Db.SaveChanges();
                 
                }
                else
                {
                    //UserMediaHistory count = Db.UserMediaHistories.Where(a => a.SectionMediaId == sectionmediaid).FirstOrDefault();

                    //count.UpdatedTime = true;
                    ////var sc = Db.UserMediaHistories.SqlQuery("update UserMediaHistories  set UpdatedTime=0 where UserMediaHistories.SectionMediaId !=" + number1);
                    ////db.UserMediaHistory.SqlQuery("update UserMediaHistories set UserMediaHistories.WatchedTime=" + number2 + "where UserMediaHistories.UserVideoHistoryId=" + count.UserVideoHistoryId);
                    //if (ModelState.IsValid)
                    //{
                    //    //count.UpdatedTime = DateTime.Now;
                    //    Db.Entry(count).State = EntityState.Modified;
                    //    Db.SaveChanges();
                    //}

                    startime = check.WatchedTime;
                }

                // End Video Section



                ViewBag.StartTime = startime;
                ViewBag.index = index;
              

                SectionMedia sm = Db.SectionMedia.Find(media);
                ViewBag.duration = sm.VideoDuration.ToString();
                ViewBag.videotype = sm.Videotype.ToString();
                ViewBag.videourl = coursename+"/"+ SECNAME+"/"+sm.VideoUrl.ToString();
                ViewBag.videotitle = vname;
                ViewBag.Secname = SECNAME;

                return PartialView();
            }
        }
        /* End StudentCourse */

        /*Courses*/
        public ActionResult Course(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error404", "Error");
            }

            string tempid = id;
            // var idd = Convert.ToString(id);
            //var DecryptId = helpper.Decrypt(idd);
            id = id.Replace('!', '+');
            id = id.Replace('%', 'a');

            var decsc = helpper.Decrypto(id.Replace('$', '/'));

            if (decsc == "")
            {
                return RedirectToAction("Error404", "Error");
            }
            else
            {
                int cid = Convert.ToInt32(decsc);
                string userid = User.Identity.GetUserId();

                var courses = Db.Courses.Find(cid);
                string Section = courses.Sections.Count() + " Sections-";
                int videocount = 0, totalvideo = 0;
                foreach (var item in courses.Sections)
                {
                    videocount = videocount + item.SectionMedia.Count();
                    foreach (var item1 in item.SectionMedia)
                    {
                        totalvideo = totalvideo + item1.VideoDuration;
                    }


                }

                string Video = videocount + " Videos";
                if (videocount==0)
                {
                    ViewBag.check = 0;
                }

               
                ViewBag.data = Section + Video;
                ViewBag.totalduration = totalvideo;
                Session["cid"] = tempid;


                var check1 = Db.UserMediaHistories.SqlQuery("SELECT * FROM UserMediaHistories join SectionMedias on UserMediaHistories.SectionMediaId = SectionMedias.SectionMediaId join Sections on SectionMedias.SectionId = Sections.SectionId join Courses on Sections.CourseId = Courses.CourseId WHERE UserMediaHistories.UserId = '" + userid + "'  and Sections.CourseId = " + cid + " ").ToList();

                if (check1.Count == 0)
                {
                   var lastwatched = Db.SectionMedia.SqlQuery("select * from SectionMedias where SectionMedias.SectionMediaId = (select min(SectionMedias.SectionMediaId) from Courses join Sections on Courses.CourseId = Sections.CourseId join SectionMedias on Sections.SectionId = SectionMedias.SectionId where Courses.CourseId = "+cid+")").ToList();

                   foreach (var item in lastwatched)
                    {
                        ViewBag.v = item.SectionMediaId;
                        return View(courses);
                    }
                }
                else
                {
                   var lastwatched = Db.UserMediaHistories.SqlQuery("SELECT * FROM UserMediaHistories join SectionMedias on UserMediaHistories.SectionMediaId = SectionMedias.SectionMediaId join Sections on SectionMedias.SectionId = Sections.SectionId join Courses on Sections.CourseId = Courses.CourseId WHERE UserMediaHistories.UserId = '"+userid+"'  and Sections.CourseId = "+cid+ " and  UserMediaHistories.UpdatedTime=1").ToList();
                    foreach (var item in lastwatched)
                    {
                        ViewBag.v = item.SectionMediaId;
                        return View(courses);
                    }

                }

                
               





                //ViewBag.sectionname=co
                return View(courses);
            }
            
        }
        /*End Courses*/




        /* Foramting Time*/

        public ActionResult FormatTime(int time)
        {
            

            string ttime="";
            if (time == 0)
            {
              ttime = "0";
            }
            else
            {
                if (time / 3600 > 0)
                {
                    double time1 = time / 3600;
                    double hour = Math.Floor(time1);
                    double minutes = time - hour * 3600;
                    minutes = Math.Floor(minutes / 60);
                    double seconds = Math.Floor(time - minutes * 60 - hour * 3600);
                    if (seconds < 10)
                    {
                        ttime = hour + "h:" + minutes + "m:0" + seconds+"s";
                    }
                    else
                    {
                        ttime = hour + "h:" + minutes + "m:" + seconds+"s";
                    }
                  
                }
                else
                {
                    double time1 = time / 60;
                    double minutes = Math.Floor(time1);
                    double temp = minutes * 60;
                    double seconds = time - temp;
                    if (seconds<10)
                    {
                        ttime = minutes + "m:0" + seconds+"s";
                    }
                    else
                    {
                        ttime = minutes + "m:" + seconds+"s";
                    }
                    
                }
            }
           
           



            // var    minutes =Math.floor(minutes/60),
            //  seconds = time - minutes * 60;

           

            
            return Content(ttime); 
        }





        [HttpPost]
        public string UpdateUserMedia(int number1, int number2,int cid)
        {

            string userid = User.Identity.GetUserId();


            var updateUh = Db.UserMediaHistories.SqlQuery("SELECT * FROM UserMediaHistories join SectionMedias on UserMediaHistories.SectionMediaId = SectionMedias.SectionMediaId join Sections on SectionMedias.SectionId = Sections.SectionId join Courses on Sections.CourseId = Courses.CourseId WHERE UserMediaHistories.UserId = '" + userid + "'  and Sections.CourseId = " + cid + " ").ToList();




            foreach (var item in updateUh)
            {
                if (item.SectionMediaId == number1)
                {

                }
                else
                {
                    UserMediaHistory count1 = Db.UserMediaHistories.Where(a => a.SectionMediaId == item.SectionMediaId && a.UserId == userid).FirstOrDefault();

                    count1.UpdatedTime = false;
                    if (ModelState.IsValid)
                    {
                        //count.UpdatedTime = DateTime.Now;
                        Db.Entry(count1).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                }
             
            }

            UserMediaHistory count = Db.UserMediaHistories.Where(a => a.SectionMediaId == number1 && a.UserId == userid).FirstOrDefault();
            Courses cc = Db.Courses.Find(cid);
            cc.Time = DateTime.Now;
            if (count == null)
            {
                UserMediaHistory obj = new UserMediaHistory();
                obj.WatchedTime = number2;
                obj.UserId = userid;
            
                obj.UpdatedTime = true;

                obj.SectionMediaId = number1;

             

                Db.UserMediaHistories.Add(obj);
                Db.Entry(cc).State = EntityState.Modified;
                Db.SaveChanges();
            }
            else
            {
                count.WatchedTime = number2;
                count.UpdatedTime = true;
             

                if (ModelState.IsValid)
                {


                   
                    Db.Entry(cc).State = EntityState.Modified;
                    Db.Entry(count).State = EntityState.Modified;
                    Db.SaveChanges();
                }
            }
            
          
            return "Changeiing";
        }


        /*  End StudentCourseVideo */

        public ActionResult Progress(int? courseid)
        {
            string userid = User.Identity.GetUserId();
            var courses = Db.Courses.Find(courseid);
            int userduration = 0;

            int totalvideo = 0;
            foreach (var item in courses.Sections)
            {
                foreach (var item1 in item.SectionMedia)
                {
                    totalvideo = totalvideo + item1.VideoDuration;
                }
            }
            var dbb = Db.UserMediaHistories.Where(x => x.UserId == userid && x.SectionMedia.Section.CourseId == courseid).Select(m => m.WatchedTime).Sum();
            userduration = Convert.ToInt32(dbb);

            double progresss = ( (double) (userduration) / (double) (totalvideo)) *100 ;
          
            return Content(Math.Floor(progresss).ToString());
        }



       
    }
}