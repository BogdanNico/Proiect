using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Training.Domain.Entities
{
    public partial class Course
    {
        public Course()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public CourseType? CourseType { get; set; }

        public int TeacherId { get; set; }

        //[ForeignKey("TeacherId")]
        //public virtual Teacher Teacher { get; set;  }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }

    public enum CourseType
    {
        Online,
        Onsite,
        Workshop,
    }
}
