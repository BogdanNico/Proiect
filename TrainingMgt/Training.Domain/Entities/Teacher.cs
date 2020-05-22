using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Training.Domain.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
        }

        [Key]
        public int TeacherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public TeacherSpeciality Speciality { get; set; }

        //[Key, ForeignKey("Course")]
        public int CourseId { get; set; }

        //[ForeignKey("CourseId")]
        //public virtual Course Course { get; set; }
    }

    public enum TeacherSpeciality
    {
        Management,
        Marketing,
        Digital,
    }

}
