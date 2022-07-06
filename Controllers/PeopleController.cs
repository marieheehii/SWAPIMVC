using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class PeopleController : Controller
    {
        private readonly HttpClient _httpclient;
        public PeopleController(IHttpClientFactory httpClientFactory) 
        {
            _httpclient = httpClientFactory.CreateClient("swapi");
        }
        public async Task<IActionResult> Index(string page)
        {
            string route = $"people?page=page{page ?? "1"}";
            HttpResponseMessage response = await _httpclient.GetAsync(route);

            var responseString = await response.Content.ReadAsStringAsync();
            var people = JsonSerializer.Deserialize<ResultsViewModel<PeopleViewModel>>(responseString);
            return View(people);
            
        }
    }
