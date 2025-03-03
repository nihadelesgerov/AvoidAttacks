using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
namespace AvoidDoS.XSS
{
    public class ControllerXSS : Controller
    {

        


        public IActionResult AvoidXssMethod(TestModel info)
        {
            // Nuget Package Called HtmlSanitizer process input to convert fully text file that is not able to perform :)
            // Human Facing applications must use it 
            var sanitizedInfo = new HtmlSanitizer().Sanitize(info.UserName);
            return View();
        }
    }
}
