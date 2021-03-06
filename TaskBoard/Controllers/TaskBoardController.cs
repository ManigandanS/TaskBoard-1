﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskBoard.Models;
using TaskBoard.Services;

namespace TaskBoard.Controllers
{
    public class TaskBoardController : Controller
    {
        private ITaskBoardService service;

        public TaskBoardController(ITaskBoardService service)
        {
            this.service = service;
        }

        public ViewResult Index()
        {
            return View(service.GetProjects());
        }
        
        [HttpGet]
        public ViewResult TaskBoard(int projectId)
        {
            return View(service.GetTasks(projectId));
        }

        [HttpPost]
        public JsonResult CreateTask(Task task)
        {
            task.CreatedById = 1;
            task.UpdatedById = 1;
            task.TaskId = 4;
            return Json(task);
        }

    }
}
