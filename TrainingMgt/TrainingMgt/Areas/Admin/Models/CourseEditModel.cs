using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class CourseEditModel
    {
        public CourseEditModel()
        {
        }

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        [StringLength(30, MinimumLength = 3)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please select a course type")]
        [Display(Name = "Course Type")]
        public CourseType? CourseType { get; set; }

        [Display(Name = "Teacher ID")]
        public int TeacherId { get; set; }
    }
}
