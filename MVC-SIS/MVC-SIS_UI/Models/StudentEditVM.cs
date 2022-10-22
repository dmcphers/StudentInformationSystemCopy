using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Models
{
    public class StudentEditVM : IValidatableObject
    {
        public Student student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public StudentEditVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            student = new Student();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (student.FirstName == null || student.FirstName == "")
            {
                errors.Add(new ValidationResult("Please enter a First Name",
                    new[] { "Student.FirstName" }));
            }

            if (student.LastName == null || student.LastName == "")
            {
                errors.Add(new ValidationResult("Please enter a Last Name",
                    new[] { "Student.LastName" }));
            }

            if (student.GPA == 0.0M)
            {
                errors.Add(new ValidationResult("Please enter a GPA",
                    new[] { "Student.GPA" }));
            }

            if (student.Address.Street1 == null || student.Address.Street1 == "")
            {
                errors.Add(new ValidationResult("Please enter a Street Address",
                    new[] { "Student.Address.Street1" }));
            }

            if (student.Address.City == null || student.Address.City == "")
            {
                errors.Add(new ValidationResult("Please enter a City",
                    new[] { "Student.Address.City" }));
            }

            if (student.Address.State.StateAbbreviation == null || student.Address.State.StateAbbreviation == "")
            {
                errors.Add(new ValidationResult("Please enter a State Abbreviation",
                    new[] { "Student.Address.State.StateAbbreviation" }));
            }

            if (student.Address.State.StateName == null || student.Address.State.StateName == "")
            {
                errors.Add(new ValidationResult("Please enter a State Name",
                    new[] { "Student.Address.State.StateName" }));
            }

            if (student.Address.PostalCode == null || student.Address.PostalCode == "")
            {
                errors.Add(new ValidationResult("Please enter a Postal Code",
                    new[] { "Student.Address.PostalCode" }));
            }

            return errors;
        }
    }
}