using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
namespace AvoidDoS.XSS
{
    public class ControllerXSS : Controller
    {

        // Let's say you get data from use via input


        // ENSURE YOU ARE USING HTMLSANITIZER => Nuget Packages => AspNetHTMLSanitizer package 


        public IActionResult AvoidXssMethod(TestModel info)
        {
            var sanitizedInfo = new HtmlSanitizer().Sanitize(info.UserName);
            // that's it . Data sanitizered already
            return View();
        }
    }
}
