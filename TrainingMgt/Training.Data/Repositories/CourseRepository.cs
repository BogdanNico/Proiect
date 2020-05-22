using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Domain;
using Training.Domain.Entities;

namespace Training.Data.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();

        Course GetCourseById(int id);

        Teacher GetTeacherById(int id);

        IEnumerable<Feedback> GetFeedbacks();

        void CreateCourse(Course course);

        void DeleteCourse(int id);

        void SaveChanges();

        IQueryable<Course> PopulateCoursesDropDownList();

        IEnumerable<Teacher> GetTeachers();

        Teacher GetTeacherByCourseId(int id);

        void CreateTeacher(Teacher teacher);
    }

    public class CourseRepository : ICourseRepository
    {
        private TrainingContext _trainingContext;

        public CourseRepository(TrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _trainingContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _trainingContext.Courses.SingleOrDefault(c => c.CourseId == id);
        }

        public Teacher GetTeacherById(int id)
        {
            return _trainingContext.Teachers.SingleOrDefault(c => c.CourseId == id);
        }

        public IEnumerable<Feedback> GetFeedbacks()
        {
            return _trainingContext.Feedbacks.ToList();
        }

        public void CreateCourse(Course course)
        {
            _trainingContext.Add(course);
            //_trainingContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Teachers ON");
            _trainingContext.SaveChanges();
            //_trainingContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Teachers OFF");
        }

        public void DeleteCourse(int id)
        {
            var course = _trainingContext.Courses.SingleOrDefault(c => c.CourseId == id);
            _trainingContext.Courses.Remove(course);
            _trainingContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _trainingContext.SaveChanges();
        }

        public IQueryable<Course> PopulateCoursesDropDownList()
        {
            var coursesQuery = from c in _trainingContext.Courses
                               orderby c.CourseName
                               select c;
            return coursesQuery;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _trainingContext.Teachers.ToList();
        }

        public Teacher GetTeacherByCourseId(int id)
        {
            return _trainingContext.Teachers.SingleOrDefault(c => c.CourseId == id);
        }

        public void CreateTeacher(Teacher teacher)
        {
            _trainingContext.Add(teacher);
            _trainingContext.SaveChanges();
        }
    }
}
