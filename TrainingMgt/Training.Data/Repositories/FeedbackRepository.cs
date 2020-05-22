using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Domain;
using Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Training.Data.Repositories
{
    public interface IFeedbackRepository
    {
        IEnumerable<Course> GetCourses();

        IEnumerable<Feedback> GetFeedbacks();

        void Evaluate(Feedback feedback);

        void SaveChanges();

        IQueryable<Course> PopulateCoursesDropDownList();
    }

    public class FeedbackRepository : IFeedbackRepository
    {
        private TrainingContext _trainingContext;

        public FeedbackRepository(TrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _trainingContext.Courses.ToList();
        }

        public IEnumerable<Feedback> GetFeedbacks()
        {
            return _trainingContext.Feedbacks.ToList();
        }

        public void Evaluate(Feedback feedback)
        {
            _trainingContext.Feedbacks.Add(feedback);
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

    }
}
