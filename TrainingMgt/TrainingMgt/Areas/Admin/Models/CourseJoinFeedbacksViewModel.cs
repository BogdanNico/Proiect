using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class CourseJoinFeedbacksViewModel
    {
        public CourseJoinFeedbacksViewModel()
        {
        }

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Type")]
        public CourseType? CourseType { get; set; }

        [Display(Name = "Course satisfaction")]
        public CourseSatisfaction? CourseSatisfaction { get; set; }

        [Display(Name = "Liked aspects")]
        public string LikedAspects { get; set; }

        [Display(Name = "Aspects to improve")]
        public string AspectsToImprove { get; set; }

    }
}
