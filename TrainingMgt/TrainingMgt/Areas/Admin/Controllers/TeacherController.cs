using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Training.Data.Repositories;
using Training.Domain.Entities;
using TrainingManagement.Areas.Admin.Models;

namespace TrainingMgt.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private ITeacherRepository _repository;
        private IWebHostEnvironment _environment;

        public TeacherController(ITeacherRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var teachersListFromDB = _repository.GetTeachers();
            var model = new List<TeacherViewModel>();
            foreach (var teacher in teachersListFromDB)
            {
                var teacherModelItem = new TeacherViewModel();
                teacherModelItem.TeacherId = teacher.TeacherId;
                teacherModelItem.FullName = teacher.FirstName + " " + teacher.LastName;
                teacherModelItem.Speciality = teacher.Speciality;
                teacherModelItem.CourseId = teacher.CourseId;

                model.Add(teacherModelItem);
            }

            return View(model);
        }


        public IActionResult Details(int id)
        {
            var teacher = _repository.GetTeacherById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            var model = new TeacherViewModel()
            {
                TeacherId = teacher.TeacherId,
                FullName = teacher.FirstName + " " + teacher.LastName,
                Speciality = teacher.Speciality,
                CourseId = teacher.CourseId
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherEditModel teacherEditModel)
        {
            Boolean anything = true;
            if (anything == true)
            {
                var teacher = new Teacher()
                {
                    TeacherId = teacherEditModel.TeacherId,
                    FirstName = teacherEditModel.FirstName,
                    LastName = teacherEditModel.LastName,
                    Speciality = teacherEditModel.Speciality,
                    CourseId = teacherEditModel.CourseId
                };

                _repository.CreateTeacher(teacher);
                _repository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(teacherEditModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _repository.GetTeacherById(id);

            var model = new TeacherEditModel()
            {
                TeacherId = teacher.TeacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Speciality = teacher.Speciality,
                CourseId = teacher.CourseId
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
            var teacherToUpdate = _repository.GetTeacherById(id);

            bool isUpdated = await TryUpdateModelAsync<Teacher>(
                                            teacherToUpdate,
                                            "",
                                            t => t.TeacherId,
                                            t => t.FirstName,
                                            t => t.LastName,
                                            t => t.Speciality,
                                            t => t.CourseId);
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = _repository.GetTeacherById(id);

            var model = new TeacherEditModel()
            {
                TeacherId = teacher.TeacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Speciality = teacher.Speciality,
                CourseId = teacher.CourseId
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
            _repository.DeleteTeacher(id);
            return RedirectToAction("Index");
        }
    }
}