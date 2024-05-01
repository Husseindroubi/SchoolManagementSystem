using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TopicController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*public IActionResult Index()
        {
            List<Topic> Topics = _unitOfWork.Topic.GetAll().ToList();
            return View(Topics);
        }*/
        [Authorize(Roles = "Teacher, Student")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 5)
        {
            var topics = _unitOfWork.Topic.GetAll();
            ViewBag.TotalPages = (int)Math.Ceiling(topics.Count() / (double)pageSize);
            ViewBag.PageIndex = pageIndex;

            var paginatedTopics = topics.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return View(paginatedTopics);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(Topic Topic)
        {
                _unitOfWork.Topic.Add(Topic);
                _unitOfWork.Save();
                TempData["SuccessMessage"] = "Weekly Plan created successfully!!";
                return RedirectToAction("Index");
        }



        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int? TopicId)
        {
            if (TopicId == null || TopicId == 0)
            {
                return NotFound();
            }

            Topic? TopicFromDB = _unitOfWork.Topic.Get(u => u.TopicId == TopicId); ;
            if (TopicFromDB == null)
            {
                return NotFound();
            }

            return View(TopicFromDB);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(Topic Topic)
        {
         
                _unitOfWork.Topic.Update(Topic);
                _unitOfWork.Save();
                TempData["SuccessMessage"] = "Weekly Plan updated successfully!!";
                return RedirectToAction("Index");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int? TopicId)
        {
            if (TopicId == null || TopicId == 0)
            {
                return NotFound();
            }

            Topic? TopicFromDB = _unitOfWork.Topic.Get(u => u.TopicId == TopicId);
            if (TopicFromDB == null)
            {
                return NotFound();
            }

            return View(TopicFromDB);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteConfirmed(int? TopicId)
        {
            if (TopicId == null)
            {
                return NotFound();
            }

            Topic? Topic = _unitOfWork.Topic.Get(u => u.TopicId == TopicId);
            if (Topic == null)
            {
                return NotFound();
            }

            _unitOfWork.Topic.Remove(Topic);
            _unitOfWork.Save();
            TempData["SuccessMessage"] = "Weekly Plan deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
