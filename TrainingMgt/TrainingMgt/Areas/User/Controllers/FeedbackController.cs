using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Data.Repositories;
using TrainingManagement.Areas.User.Models;
using TrainingManagement.Areas.Admin.Models;
using Training.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TrainingMgt.Areas.User.Controllers
{
    [Area("User")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Evaluate()
        {
            PopulateCoursesDropDownList();
            return View();
        }

        [HttpPost]
        public IActionResult Evaluate(FeedbackEditModel feedbackEditModel)
        {
            Boolean anything = true;
            if (anything == true)
            {
                var feedback = new Feedback()
                {
                    FeedbackId = feedbackEditModel.FeedbackId,
                    CourseId = feedbackEditModel.CourseId,
                    CourseSatisfaction = feedbackEditModel.CourseSatisfaction,
                    LikedAspects = feedbackEditModel.LikedAspects,
                    AspectsToImprove = feedbackEditModel.AspectsToImprove
                };

                PopulateCoursesDropDownList(feedbackEditModel.CourseId);
                _repository.Evaluate(feedback);
                _repository.SaveChanges();

                return RedirectToAction(nameof(EvaluationComplete));
            }
            
            return View(feedbackEditModel);
        }

        public IActionResult EvaluationComplete()
        {
            ViewBag.EvaluationCompleteMessage = "Evaluation saved!";
            return View();
        }


        private void PopulateCoursesDropDownList(int? selectedCourse = null)
        {
            var courses = _repository.PopulateCoursesDropDownList();
            ViewBag.CourseId = new SelectList(courses.AsNoTracking(), "CourseId", "CourseName", selectedCourse);
        }

    }
}