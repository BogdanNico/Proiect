using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Training.Domain.Entities;

namespace Training.Domain
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
        new Course
        {
            CourseId = 1,
            CourseName = "Reward Management",
            CourseType = CourseType.Onsite
        },
        new Course
        {
            CourseId = 2,
            CourseName = "LinkedIn Recruitment",
            CourseType = CourseType.Online
        },
        new Course
        {
            CourseId = 3,
            CourseName = "Interviewing Skills",
            CourseType = CourseType.Workshop
        },
        new Course
        {
            CourseId = 4,
            CourseName = "New employee onboarding",
            CourseType = CourseType.Online
        },
        new Course
        {
            CourseId = 5,
            CourseName = "Human resources consultancy",
            CourseType = CourseType.Onsite
        }
                );

            modelBuilder.Entity<Teacher>().HasData(
        new Teacher
        {
            TeacherId = 1,
            FirstName = "Panaite",
            LastName = "Nica",
            Speciality = TeacherSpeciality.Management,
            CourseId = 1
        },
        new Teacher
        {
            TeacherId = 2,
            FirstName = "Adriana",
            LastName = "Prodan",
            Speciality = TeacherSpeciality.Marketing,
            CourseId = 2
        },
        new Teacher
        {
            TeacherId = 3,
            FirstName = "Beatrice",
            LastName = "Galatanu",
            Speciality = TeacherSpeciality.Digital,
            CourseId = 3
        },
        new Teacher
        {
            TeacherId = 4,
            FirstName = "Valentin",
            LastName = "Ionescu",
            Speciality = TeacherSpeciality.Marketing,
            CourseId = 4
        },
        new Teacher
        {
            TeacherId = 5,
            FirstName = "Bogdan",
            LastName = "Nicolae",
            Speciality = TeacherSpeciality.Management,
            CourseId = 5
        }
                );

            modelBuilder.Entity<Feedback>().HasData(
        new Feedback
        {
            FeedbackId = 1,
            CourseId = 1,
            CourseSatisfaction = CourseSatisfaction.ExceedsExpectations,
            LikedAspects = "Course structure, interactivity.",
            AspectsToImprove = "Practical side, implementation proposal."
        },
        new Feedback
        {
            FeedbackId = 2,
            CourseId = 2,
            CourseSatisfaction = CourseSatisfaction.MeetsExpectations,
            LikedAspects = "Very attractive recruitment techniques.",
            AspectsToImprove = "Timing."
        },
        new Feedback
        {
            FeedbackId = 3,
            CourseId = 3,
            CourseSatisfaction = CourseSatisfaction.MeetsExpectations,
            LikedAspects = "Easy to apply concepts.",
            AspectsToImprove = "It should have covered more areas of interviewing."
        },
        new Feedback
        {
            FeedbackId = 4,
            CourseId = 4,13
            CourseSatisfaction = CourseSatisfaction.BelowExpectations,
            LikedAspects = "None",
            AspectsToImprove = "Course structure, concepts aplicability, interactivity"
        },
        new Feedback
        {
            FeedbackId = 5,
            CourseId = 5,
            CourseSatisfaction = CourseSatisfaction.ExceedsExpectations,
            LikedAspects = "Easy to apply in practice, interesting concepts.",
            AspectsToImprove = "The course should have lasted more."
        }
                );
        }
    }*/

}
}
