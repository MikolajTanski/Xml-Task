using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Xml_Task.Models;
using Xml_Task.Services;

namespace Xml_Task.Controllers
{
    public class XMLController : Controller
    {
        public XMLService _XMLService;
        public XMLController()
        {
            _XMLService = new XMLService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(IFormFile file)
        {
            string filePath = Path.Combine("Temp/",
                           Path.GetRandomFileName());
            if (file.Length > 0)
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyToAsync(stream);
                }
            }

            _XMLService.Save(filePath);
            User user = _XMLService.GetUserFromXML(filePath);
            return View("Index", user);
        }
    }
}
