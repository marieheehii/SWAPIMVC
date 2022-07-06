using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class PeopleController : Controller
    {
        private readonly HttpClient _httpclient;
        public PeopleController(IHttpClientFactory httpClientFactory) 
        {
            _httpclient = httpClientFactory.CreateClient("swapi");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
