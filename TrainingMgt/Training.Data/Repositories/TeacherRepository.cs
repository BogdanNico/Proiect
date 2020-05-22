using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Domain;
using Training.Domain.Entities;


namespace Training.Data.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();

        Teacher GetTeacherById(int id);

        void CreateTeacher(Teacher teacher);

        void DeleteTeacher(int id);

        void SaveChanges();
    }

    public class TeacherRepository : ITeacherRepository
    {
        private TrainingContext _trainingContext;

        public TeacherRepository(TrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _trainingContext.Teachers.ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            return _trainingContext.Teachers.SingleOrDefault(c => c.TeacherId == id);
        }

        public void CreateTeacher(Teacher teacher)
        {
            _trainingContext.Add(teacher);
            _trainingContext.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            var teacher = _trainingContext.Teachers.SingleOrDefault(t => t.TeacherId == id);
            _trainingContext.Teachers.Remove(teacher);
            _trainingContext.SaveChanges();
        }


        public void SaveChanges()
        {
            _trainingContext.SaveChanges();
        }

    }
}
