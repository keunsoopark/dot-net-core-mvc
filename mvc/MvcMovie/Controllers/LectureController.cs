// Routing: depending on the URL, providing different service

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_example.Models;
using mvc_example.Services;

namespace mvc_example.Controllers
{
    public class LectureController : Controller
    {
        LectureRepository lecRep = new LectureRepository();
        
        public IActionResult List ()    // URL: baseURL/Lecture/List
        {
            return View(lecRep.GetList());
        }

        public IActionResult Watch (Int64 lecNo)    // URL: baseURL/Lecture/Watch?lecNo={number}
        {
            return View(lecRep.GetOne(lecNo));
        }
    }
}
