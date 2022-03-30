namespace LearningPortal.Migrations
{
    using LearningPortal.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningPortal.Models.ApplicationDbContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(LearningPortal.Models.ApplicationDbContext context)
        {
            var date = DateTime.Now;
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(

                new ApplicationRole() { Name = "Admin" },
                new ApplicationRole() { Name = "Student" }
                );
            context.SaveChanges();

         
            
            if (!context.Users.Any(u => u.UserName == "LearningPotral"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Email = "Admin@LearningPortal.com",
                   
                    UserName = "LearningPotral"

                };




               manager.Create(user, "Abc@12");
              
                 manager.AddToRole(user.Id, "Admin");
            }


         //context.Categories.Single(i => i.CategoryName == "Audio/Video").CategoryId


            context.SaveChanges();
           
            context.Categories.AddOrUpdate(
                         new Categories() { CategoryName = "Audio/Video", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now ,IsActive = true },
                         new Categories() { CategoryName = "Communication", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Design", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Development", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Marketing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Miscellaneous", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Project Management", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Soft Skills", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "Writing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                         new Categories() { CategoryName = "IT & Networks", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true }


                             );
            context.SaveChanges();
            context.SubCategories.AddOrUpdate(

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Audio/Video").CategoryId, SubCategoryName = "Video Graphy", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Audio/Video").CategoryId, SubCategoryName = "Audio Editor", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Communication").CategoryId, SubCategoryName = "Content Writing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Communication").CategoryId, SubCategoryName = "Technical Writing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Communication").CategoryId, SubCategoryName = "Eassy Writing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Design").CategoryId, SubCategoryName = "Web Designing", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Design").CategoryId, SubCategoryName = "Bootstrap", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                      new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Development").CategoryId, SubCategoryName = "Java", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Development").CategoryId, SubCategoryName = ".Net", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Development").CategoryId, SubCategoryName = "Php", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                      new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Marketing").CategoryId, SubCategoryName = "HCI", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Miscellaneous").CategoryId, SubCategoryName = "Bowling Actions", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Miscellaneous").CategoryId, SubCategoryName = "Others", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Project Management").CategoryId, SubCategoryName = "Agile", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Project Management").CategoryId, SubCategoryName = "Scurm", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Project Management").CategoryId, SubCategoryName = "Time Management", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Project Management").CategoryId, SubCategoryName = "Temper Management", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },


                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "Soft Skills").CategoryId, SubCategoryName = "Vision & Communication", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },

                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "IT & Networks").CategoryId, SubCategoryName = "Networking", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true },
                     new SubCategories() { CategoryId = context.Categories.Single(i => i.CategoryName == "IT & Networks").CategoryId, SubCategoryName = "Cisico", Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", Time = DateTime.Now, IsActive = true }


                );
            context.SaveChanges();

            context.Courses.AddOrUpdate(
                new Courses() { Description = "JAVA was developed by James Gosling at Sun Microsystems Inc in the year 1991, later acquired by Oracle Corporation.It is a simple programming language.Java makes writing, compiling, and debugging programming easy. ... Java applications are compiled to byte code that can run on any Java Virtual Machine", Levels = "Easy", Year = 2006, Image = "256_rsz_90-jiang-640827-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == "Java").SubCategoryId, IsFeatured = true, CourseName = "Introduction To Java", Time = DateTime.Now, UploadedDate = date.Date,IsActive= true },
                new Courses() { Description = "ASP.NET is a web application framework designed and developed by Microsoft. ASP.NET is open source and a subset of the . NET Framework and successor of the classic ASP(Active Server Pages). ... ASP.NET is built on the CLR(Common Language Runtime) which allows the programmers to execute its code using any .", Levels = "Easy", Year = 2007, Image = "256_rsz_karl-s-973833-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = false, CourseName = "Introduction To .NET", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "PHP started out as a small open source project that evolved as more and more people found out how useful it was. Rasmus Lerdorf unleashed the first version of PHP way back in 1994.", Levels = "Easy", Year = 2004, Image = "256_rsz_clem-onojeghuo-150467-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == "Php").SubCategoryId, IsFeatured = true, CourseName = "Introduction To Php", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "In statistics, ordinary least squares (OLS) is a type of linear least squares method for estimating the unknown parameters in a linear regression model. OLS chooses the parameters of a linear function of a set of explanatory variables by the principle of least squares: minimizing the sum of the squares of the differences between the observed dependent variable (values of the variable being observed) in the given dataset and those predicted by the linear function of the independent variable.", Levels = "Easy", Year = 2006, Image = "256_rsz_karl-s-973833-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == "Video Graphy").SubCategoryId, IsFeatured = true, CourseName = "OLSs", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "A design is a plan or specification for the construction of an object or system or for the implementation of an activity or process, or the result of that plan or specification in the form of a prototype, product or process. The verb to design expresses the process of developing a design.", Levels = "Easy", Year = 2006, Image = "256_rsz_nicolas-horn-689011-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == "Web Designing").SubCategoryId, IsFeatured = true, CourseName = "AutoCAD", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Machine learning is a subfield of artificial intelligence (AI). The goal of machine learning generally is to understand the structure of data and fit that data into models that can be understood and utilized by people.", Levels = "Medium", Year = 2019, Image = "256_rsz_sharina-mae-agellon-377466-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Introduction To ML", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Deep learning is a branch of machine learning which is completely based on artificial neural networks, as neural network is going to mimic the human brain so deep learning is also a kind of mimic of human brain. In deep learning, we don't need to explicitly program everything.", Levels = "Hard", Year = 2020, Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Introduction To DeepLearing", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Computer vision is a field of study focused on the problem of helping computers to see. At an abstract level, the goal of computer vision problems is to use the observed image data to infer something about the world.", Levels = "Hard", Year = 2021, Image = "256_rsz_sharina-mae-agellon-377466-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Introduction To OpenCv", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Neuro-linguistic programming (NLP) is a psychological approach that involves analyzing strategies used by successful individuals and applying them to reach a personal goal. It relates thoughts, language, and patterns of behavior learned through experience to specific outcomes.", Levels = "Hard", Year = 2021, Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Introduction To NLP", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Neuro-linguistic programming (NLP) is a psychological approach that involves analyzing strategies used by successful individuals and applying them to reach a personal goal. It relates thoughts, language, and patterns of behavior learned through experience to specific outcomes.", Levels = "Hard", Year = 2021, Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Indepth NLP", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Neuro-linguistic programming (NLP) is a psychological approach that involves analyzing strategies used by successful individuals and applying them to reach a personal goal. It relates thoughts, language, and patterns of behavior learned through experience to specific outcomes.", Levels = "Hard", Year = 2021, Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = false, CourseName = "Open CV", Time = DateTime.Now, UploadedDate = date.Date, IsActive = true },
                new Courses() { Description = "Neuro-linguistic programming (NLP) is a psychological approach that involves analyzing strategies used by successful individuals and applying them to reach a personal goal. It relates thoughts, language, and patterns of behavior learned through experience to specific outcomes.", Levels = "Hard", Year = 2021, Image = "265_rsz_mubariz-mehdizadeh-364026-unsplash.jpg", SubCategoryId = context.SubCategories.Single(i => i.SubCategoryName == ".Net").SubCategoryId, IsFeatured = true, CourseName = "Big Data", Time = DateTime.Now, UploadedDate = date.Date,IsActive= true  }
            ) ;
            context.SaveChanges();

            context.Sections.AddOrUpdate(
                new Section() { SectionName = "Intro", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },
                new Section() { SectionName = "Installation", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },
                new Section() { SectionName = "Fundamentals", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },
                new Section() { SectionName = "OOP", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },
                new Section() { SectionName = "Data Structure", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },
                new Section() { SectionName = "Project", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId },

                new Section() { SectionName = "Introduction", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId },

            new Section() { SectionName = "PhpIntro", CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId }
            );
            context.SaveChanges();


            context.SectionMedia.AddOrUpdate(
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4580.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Intro").SectionId, VideoTitle = "Video1", VideoDuration = 14 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4584.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Intro").SectionId, VideoTitle = "Video2", VideoDuration = 13 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Intro").SectionId, VideoTitle = "Video3", VideoDuration = 1005 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4580.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Installation").SectionId, VideoTitle = "Video1", VideoDuration = 14 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4580.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Installation").SectionId, VideoTitle = "Video2", VideoDuration = 14 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4580.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Installation").SectionId, VideoTitle = "Video3", VideoDuration = 14 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4584.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Installation").SectionId, VideoTitle = "Video4", VideoDuration = 13 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4584.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Fundamentals").SectionId, VideoTitle = "Video1", VideoDuration = 13 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4584.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Fundamentals").SectionId, VideoTitle = "Video2", VideoDuration = 13 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Pexels Videos 4584.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Fundamentals").SectionId, VideoTitle = "Video3", VideoDuration = 13 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Data Structure").SectionId, VideoTitle = "Video4", VideoDuration = 1005 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Project").SectionId, VideoTitle = "Video1", VideoDuration = 1005 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "Introduction").SectionId, VideoTitle = "Video1", VideoDuration = 1005 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "PhpIntro").SectionId, VideoTitle = "Video1", VideoDuration = 1005 },
              new SectionMedia() { Videotype = "video/mp4", VideoUrl = "Video-20211018_095303-Meeting Recording.mp4", SectionId = context.Sections.Single(i => i.SectionName == "PhpIntro").SectionId, VideoTitle = "Video2", VideoDuration = 1005 }

            );

            context.SaveChanges();

            context.CourseLearnings.AddOrUpdate(
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Java").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },

                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To .NET").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },

                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." },
                new CourseLearning() { CourseId = context.Courses.Single(i => i.CourseName == "Introduction To Php").CourseId, Description = "In this video, I will demo how to Build Multi Level Menu Dynamically with Entity Framework in ASP.NET MVC." }

                );



        }

    }
}
