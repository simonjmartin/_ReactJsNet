﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> comments;

        static HomeController()
        {
            comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Simon Martin",
                    Text = "Something I've said"
                },
                new CommentModel
                {
                    Id=2,
                    Author ="Someone Else",
                    Text="What they said"
                },
                new CommentModel
                {
                    Id=3,
                    Author = "Mr Happy",
                    Text="This is *another* comment."
                },
            };
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location =ResponseCacheLocation.None, NoStore =true)]
        public ActionResult Comments()
        {
            return Json(comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            comment.Id = comments.Count + 1;
            comments.Add(comment);

            return Content("Success :)");
        }
    }
}
