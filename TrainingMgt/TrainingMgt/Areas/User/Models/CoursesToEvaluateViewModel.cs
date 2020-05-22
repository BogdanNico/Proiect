using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.User.Models
{
    public class CoursesToEvaluateViewModel
    {
        public CoursesToEvaluateViewModel()
        {
        }

        public int CourseId { get; set; }

 
        public string CourseName { get; set; }

       
        public CourseType? CourseType { get; set; }

        //public virtual ICollection<Feedback> Feedbacks { get; set; }
    }

}

