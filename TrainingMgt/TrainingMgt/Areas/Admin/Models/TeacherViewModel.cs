using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class TeacherViewModel
    {
        [Display(Name = "Teacher ID")]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher's full name")]
        public string FullName { get; set; }

        [Display(Name = "Teacher's speciality")]
        public TeacherSpeciality Speciality { get; set; }

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

    }

}
