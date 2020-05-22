using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class TeacherEditModel
    {
        public TeacherEditModel()
        {
        }

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

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

    }
}
