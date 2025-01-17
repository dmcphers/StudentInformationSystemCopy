﻿using MVC_SIS_Data;
using MVC_SIS_Models;
using MVC_SIS_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentAddVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentAddVM studentVM)
        {
            if (!ModelState.IsValid)
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());

                return View(studentVM);
            }

            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            StudentEditVM viewmodel = new StudentEditVM();
            viewmodel.SetCourseItems(CourseRepository.GetAll());
            viewmodel.SetMajorItems(MajorRepository.GetAll());
            viewmodel.student = StudentRepository.Get(id);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentEditVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

            viewModel.student.Courses = new List<Course>();

            foreach (var id in viewModel.SelectedCourseIds)
                viewModel.student.Courses.Add(CourseRepository.Get(id));

            viewModel.student.Major = MajorRepository.Get(viewModel.student.Major.MajorId);
            StudentRepository.Edit(viewModel.student);
            StudentRepository.SaveAddress(viewModel.student.StudentId, viewModel.student.Address);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            StudentDeleteVM viewModel = new StudentDeleteVM();
            viewModel.Student = StudentRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteStudent(StudentDeleteVM viewModel)
        {
            StudentRepository.Delete(viewModel.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}