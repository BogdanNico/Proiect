using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace TrainingManagement.Areas.Admin.Models
{
    public class CourseViewModelWithFeedbacks
    {
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Type")]
        public CourseType? CourseType { get; set; }

        [Display(Name = "Teacher Id")]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher's full name")]
        public string FullName { get; set; }

        [Display(Name = "Teacher's speciality")]
        public TeacherSpeciality Speciality { get; set; }

        [Display(Name = "Feedback Id")]
        public int FeedbackId { get; set; }

        [Display(Name = "Course satisfaction")]
        public CourseSatisfaction? CourseSatisfaction { get; set; }

        [Display(Name = "Liked aspects about the course")]
        public string LikedAspects { get; set; }

        [Display(Name = "Aspects to improve about the course")]
        public string AspectsToImprove { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }


    }
}
