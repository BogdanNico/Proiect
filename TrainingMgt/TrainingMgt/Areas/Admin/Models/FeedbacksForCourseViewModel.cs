using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class FeedbacksForCourseViewModel
    {
        public FeedbacksForCourseViewModel()
        {
        }

        [Display(Name = "Feedback ID")]
        public int FeedbackId { get; set; }

        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Display(Name = "Course")]
        public Course Course { get; set; }

        [Display(Name = "Course satisfaction")]
        public CourseSatisfaction? CourseSatisfaction { get; set; }

        [Display(Name = "Liked aspects")]
        public string LikedAspects { get; set; }

        [Display(Name = "Aspects to improve")]
        public string AspectsToImprove { get; set; }
    }
}
