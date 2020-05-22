using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.User.Models
{
    public class FeedbackEditModel
    {
        public FeedbackEditModel()
        {
        }

        public int FeedbackId { get; set; }

        public int CourseId { get; set; }

        [Display(Name = "Choose a course!")]
        public Course Course { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string CourseName { get; set; }

        [Display(Name = "Choose your overall course satisfaction!")]
        public CourseSatisfaction? CourseSatisfaction { get; set; }

        [Display(Name = "What did you liked about this course?")]
        [StringLength(200, MinimumLength = 10)]
        public string LikedAspects { get; set; }

        [Display(Name = "What should we improve at this course?")]
        [StringLength(200, MinimumLength = 10)]
        public string AspectsToImprove { get; set; }
    }
}
