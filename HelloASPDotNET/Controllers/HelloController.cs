using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /helloworld/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
                "<input type='text' name='name' />" +
                "<select name='language'>" + 
                "<option value = 'english' selected> English</option>" +
                "<option value = 'french'> French</option>" +
                "<option value = 'spanish'> Spanish</option>" +
                "<option value = 'arabic' > Arabic</option>" +
                "<option value = 'signLanguage'> SignLanguage</option>" +
                "<input type='submit' value='Greet Me!' />" +
                "</select>" +
                "</form>";
            return Content(html, "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            string hello = "";
            switch(language)
            {
                case "english":
                    hello = "Hello";
                    break;

                case "french":
                    hello = "Bonjour";
                    break;
                case "spanish":
                    hello = "Hola";
                    break;
                case "arabic":
                    hello = "Mrhban";
                    break;
                case "signLanguage":
                    hello = "<h2>&#x1F44B;</h2>";
                    break;
            }
            return $"{hello} {name}";

        }

        // GET: /helloworld/welcome
        // POST: /helloworld/welcome
        [HttpPost("welcome")]
        [HttpGet("welcome/{name?}/{language?}")]
        public IActionResult Welcome(string name = "Tony", string language = "english")
        {
            return Content($"{ CreateMessage(name, language)}", "text/html");
        }
    }
}

