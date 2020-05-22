using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training.Data.Repositories;
using Training.Domain.Entities;
using TrainingManagement.Areas.Admin.Models;

namespace TrainingMgt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var coursesListFromDB = _repository.GetCourses();
            var model = new List<CourseViewModel>();
            foreach (var course in coursesListFromDB)
            {
                var courseModelItem = new CourseViewModel();
                courseModelItem.CourseId = course.CourseId;
                courseModelItem.CourseName = course.CourseName;
                courseModelItem.CourseType = course.CourseType;
                model.Add(courseModelItem);
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var course = _repository.GetCourseById(id);
            var teacher = _repository.GetTeacherById(course.TeacherId);

            if (course == null)
            {
                return NotFound();
            }

            var model = new CourseViewModel()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseEditModel courseEditModel)
        {
            Boolean anything = true;
            if (anything == true)
            {
                var course = new Course()
                {
                    CourseId = courseEditModel.CourseId,
                    CourseName = courseEditModel.CourseName,
                    CourseType = courseEditModel.CourseType,
                    TeacherId = courseEditModel.TeacherId
                };

                _repository.CreateCourse(course);
                _repository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(courseEditModel);
        }
   
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _repository.GetCourseById(id);

            var model = new CourseEditModel()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
                TeacherId = course.TeacherId
            };

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var courseToUpdate = _repository.GetCourseById(id);

            bool isUpdated = await TryUpdateModelAsync<Course>(
                                            courseToUpdate,
                                            "",
                                            c => c.CourseId,
                                            c => c.CourseName,
                                            c => c.CourseType,
                                            c => c.TeacherId);
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(courseToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _repository.GetCourseById(id);

            var model = new CourseEditModel()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
                TeacherId = course.TeacherId
            };

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult ShowFeedbacksForCourse()
        {

            var feedbackListFromDb = _repository.GetFeedbacks().OrderBy(x => x.CourseId);

            var model = new List<FeedbacksForCourseViewModel>();
            foreach (var feedback in feedbackListFromDb)
            {
                var feedbackModelItem = new FeedbacksForCourseViewModel();
                feedbackModelItem.FeedbackId = feedback.FeedbackId;
                feedbackModelItem.CourseId = feedback.CourseId;
                feedbackModelItem.Course = feedback.Course;
                feedbackModelItem.CourseSatisfaction = feedback.CourseSatisfaction;
                feedbackModelItem.LikedAspects = feedback.LikedAspects;
                feedbackModelItem.AspectsToImprove = feedback.AspectsToImprove;

                model.Add(feedbackModelItem);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult CourseJoinFeedbacks()
        {
            var result = (from c in _repository.GetCourses()
                          join f in _repository.GetFeedbacks()
                          on c.CourseId equals f.CourseId
                          select new 
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseType = c.CourseType,
                              CourseSatisfaction = f.CourseSatisfaction,
                              LikedAspects = f.LikedAspects,
                              AspectsToImprove = f.AspectsToImprove
                          }).ToList();

            var model = new List<CourseJoinFeedbacksViewModel>();
            
           foreach (var r in result)
           {
                var item = new CourseJoinFeedbacksViewModel();
                item.CourseId = r.CourseId;
                item.CourseName = r.CourseName;
                item.CourseType = r.CourseType;
                item.CourseSatisfaction = r.CourseSatisfaction;
                item.LikedAspects = r.LikedAspects;
                item.AspectsToImprove = r.AspectsToImprove;

                model.Add(item);
           }                
            return View(model);
        }



    }
}