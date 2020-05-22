using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Training.Data.Repositories;
using Training.Domain.Entities;
using TrainingManagement.Areas.Admin.Models;
using TrainingMgt.Areas.Admin.Controllers; 
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetCourses_CourseController()
        {
            //arrange
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(repo => repo.GetCourses()).Returns(GetTestCourses());
            var controller = new CourseController(mockRepo.Object);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CourseViewModel>>(viewResult.ViewData.Model);

        }

        private List<Course> GetTestCourses()
        {
            var courses = new List<Course>();
            courses.Add(new Course()
            {
                CourseId = 30,
                CourseName = "Public speaking",
                CourseType = 0
            });
            courses.Add(new Course()
            {
                CourseId = 31,
                CourseName = "Lean startup",
                CourseType = 0
            });
            return courses;
        }

    }

}
