using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Models;

namespace IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Controllers
{
    public class ProjectsController : Controller
    {
        private static readonly List<Project> projects = new List<Project>
        {

            new Project
            {
                Id = 2,
                Title = "Prelim Activity 2",
                Category = "Prelim",

                Description =
                    "This project was created for Laboratory Exercise 2. " +
                    "It helped me practice creating a C# console project while " +
                    "also learning how to use Visual Studio, Git, and GitHub.",

                GitHubLink =
                    "https://github.com/thinevillarino/BSIT31E3_PRELIM_A2_VILLARINO-JUSTINE-NICOLE",

                Image = "/images/autobay Service Monitor 2.png"
            },

            new Project
            {
                Id = 3,
                Title = "Prelim Examination",
                Category = "Prelim",

                Description =
                    "This is my IT Elective 2 Prelim Examination project. " +
                    "It contains the work I completed for my examination " +
                    "during the prelim period.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_PRELIM_EXAM_-VILLARINO-_JUSTINE-NICOLE-",

                Image = "/images/PRELIM EXAM - Copy.png"
            },


            new Project
            {
                Id = 4,
                Title = "IT Elective BSIT31E3",
                Category = "Midterm",

                Description =
                    "This project is one of the web applications I worked on " +
                    "during IT Elective 2. It helped me become more familiar " +
                    "with building and organizing a web application.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_BSIT_BSIT31E3_Villarino_Justine",

                Image = "/images/LOGIN DEMO (1).png"
            },

            new Project
            {
                Id = 5,
                Title = "Midterm Assignment 1",
                Category = "Midterm",

                Description =
                    "For this assignment, I worked with ASP.NET Core MVC and " +
                    "practiced using controllers, Razor views, layouts, " +
                    "Bootstrap, and responsive web design.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_Midterm_A1_Villarino_Justine",

                Image = "/images/midterm-a1.png"
            },

            new Project
            {
                Id = 6,
                Title = "Midterm H1, H2 and H3",
                Category = "Midterm",

                Description =
                    "This repository contains my H1, H2, and H3 activities " +
                    "from the Midterm period. These activities allowed me to " +
                    "practice different web development exercises from class.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_MIDTERM_H1_H2_H3",

                Image = "/images/LOGIN DEMO(2)png.png"
            },

            new Project
            {
                Id = 7,
                Title = "Midterm Quiz 3",
                Category = "Midterm",

                Description =
                    "This is my Midterm Quiz 3 project. I used this activity " +
                    "to apply the web development concepts covered during " +
                    "our midterm lessons.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_MIDTERM_Q3_Villarino",

                Image = "/images/MVC.AUTH.png"
            },

            new Project
            {
                Id = 8,
                Title = "Midterm Examination",
                Category = "Midterm",

                Description =
                    "This is my IT Elective 2 Midterm Examination project. " +
                    "It represents the work and skills I developed throughout " +
                    "the midterm part of the course.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_MIDTERM_EXAM_1_Villarino_Justine-Nicole",

                Image = "/images/POS-MIDTERM.png"
            },

            new Project
            {
                Id = 9,
                Title = "Playlist App",
                Category = "Midterm",

                Description =
                    "This is my Playlist App project from the Midterm period. " +
                    "It gave me another opportunity to practice building a " +
                    "simple and organized web interface.",

                GitHubLink =
                    "https://github.com/thinevillarino/Playlist-App",

                Image = "/images/Playlist.png"
            },

            new Project
            {
                Id = 10,
                Title = "Prefinals Project",
                Category = "Prefinal",

                Description =
                    "This project was created during the Prefinal period. " +
                    "It allowed me to apply the skills I learned from my " +
                    "earlier Prelim and Midterm activities.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_PREFINALS_PROJECT",

                Image = "/images/PREFINALEXAM.png"
            },

            new Project
            {
                Id = 11,
                Title = "Prefinal Examination",
                Category = "Prefinal",

                Description =
                    "This is my IT Elective 2 Prefinal Examination project. " +
                    "It is one of my latest projects and shows how I applied " +
                    "the web development concepts I learned during the semester.",

                GitHubLink =
                    "https://github.com/thinevillarino/IT_ELECTIVE_2_-BSIT31E3-_PREFINAL_EXAM_Villarino_Justine-Nicole",

                Image = "/images/PREFINALEXAM.png"
            }
        };

        private bool IsLoggedIn()
        {
            string? username =
                HttpContext.Session.GetString("Username");

            return !string.IsNullOrEmpty(username);
        }


        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction(
                    "Index",
                    "Login"
                );
            }

            return View(projects);
        }

        public IActionResult Details(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction(
                    "Index",
                    "Login"
                );
            }

            Project? selectedProject =
                projects.FirstOrDefault(p => p.Id == id);

            if (selectedProject == null)
            {
                return NotFound();
            }

            return View(selectedProject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(
            int projectId,
            string name,
            string message)
        {
     
            if (!IsLoggedIn())
            {
                return RedirectToAction(
                    "Index",
                    "Login"
                );
            }


            Project? selectedProject =
                projects.FirstOrDefault(
                    p => p.Id == projectId
                );


            if (selectedProject == null)
            {
                return NotFound();
            }


            name = name?.Trim() ?? "";

            message = message?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(message))
            {
                TempData["CommentError"] =
                    "Please enter your name and comment.";

                return RedirectToAction(
                    "Details",
                    new
                    {
                        id = projectId
                    }
                );
            }

            if (name.Length > 50)
            {
                name = name.Substring(0, 50);
            }

            if (message.Length > 500)
            {
                message = message.Substring(0, 500);
            }


            Comment comment = new Comment
            {
                ProjectId = projectId,

                Name = name,

                Message = message,

                DatePosted = DateTime.Now
            };

            selectedProject.Comments.Add(comment);


            TempData["CommentSuccess"] =
                "Your comment has been posted.";


            return RedirectToAction(
                "Details",
                new
                {
                    id = projectId
                }
            );
        }
    }
}