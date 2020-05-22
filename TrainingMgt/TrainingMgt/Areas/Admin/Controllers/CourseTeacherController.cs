using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Data.Repositories;
using Training.Domain.Entities;
using TrainingManagement.Areas.Admin.Models;


namespace TrainingManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseTeacherController : Controller
    {
        private readonly ICourseRepository _repository;

        public CourseTeacherController(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var result = (from c in _repository.GetCourses()
                          join t in _repository.GetTeachers()
                          on c.CourseId equals t.CourseId
                          select new
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseType = c.CourseType,
                              TeacherId = t.TeacherId,
                              FirstName = t.FirstName,
                              LastName = t.LastName,
                              Speciality = t.Speciality
                          }).ToList();

            var model = new List<CourseTeacherEditModel>();

            foreach (var r in result)
            {
                var item = new CourseTeacherEditModel();
                item.CourseId = r.CourseId;
                item.CourseName = r.CourseName;
                item.CourseType = r.CourseType;
                item.TeacherId = r.TeacherId;
                item.FirstName = r.FirstName;
                item.LastName = r.LastName;
                item.Speciality = r.Speciality;

                model.Add(item);
            }
            return View(model);
        }

        /*public IActionResult Details(int id)
        {
            var result = (from c in _repository.GetCourseById(id)
                          join t in _repository.GetTeacherByCourseId(id)
                          on c.CourseId equals t.CourseId

                          select new
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseType = c.CourseType,
                              TeacherId = t.TeacherId,
                              FirstName = t.FirstName,
                              LastName = t.LastName,
                              Speciality = t.Speciality
                          });

            if (result == null)
            {
                return NotFound();
            }

            var model = new CourseTeacherEditModel()
            {
                CourseId = result.CourseId,
                CourseName = result.CourseName,
                CourseType = result.CourseType,
                TeacherId = result.TeacherId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Speciality = result.Speciality
            };
            return View(model);
        }*/

        /*[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseTeacherEditModel courseTeacherEditModel)
        {
            Boolean anything = true;
            if (anything == true)
            {
                var course = new Course()
                {
                    CourseId = courseTeacherEditModel.CourseId,
                    CourseName = courseTeacherEditModel.CourseName,
                    CourseType = courseTeacherEditModel.CourseType,
                    TeacherId = courseTeacherEditModel.TeacherId
                };

                var teacher = new Teacher()
                {
                    TeacherId = courseTeacherEditModel.TeacherId,
                    FirstName = courseTeacherEditModel.FirstName,
                    LastName = courseTeacherEditModel.LastName,
                    Speciality = courseTeacherEditModel.Speciality,
                    CourseId = courseTeacherEditModel.CourseId
                };

                _repository.CreateCourse(course);
                _repository.CreateTeacher(teacher);
                _repository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(courseTeacherEditModel);
        }*/







    }
}