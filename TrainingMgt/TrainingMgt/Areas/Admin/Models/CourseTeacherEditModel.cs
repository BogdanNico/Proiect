using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class CourseTeacherEditModel
    {
        public CourseTeacherEditModel()
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

        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please write the first name!")]
        [StringLength(10, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please write the last name!")]
        [StringLength(10, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Teacher's speciality")]
        public TeacherSpeciality Speciality { get; set; }

    }
}
