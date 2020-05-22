using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Training.Domain.Entities
{
    public partial class Feedback
    {
        public Feedback()
        {
        }

        [Key]
        public int FeedbackId { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public CourseSatisfaction? CourseSatisfaction { get; set; }

        public string LikedAspects { get; set; }

        public string AspectsToImprove { get; set; }
    }

    public enum CourseSatisfaction
    {
        BelowExpectations,
        MeetsExpectations,
        ExceedsExpectations,
    }
}
