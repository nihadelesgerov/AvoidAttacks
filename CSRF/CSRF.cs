using Microsoft.AspNetCore.Mvc;

namespace AvoidDoS.CSRF
{
    public class CSRF : Controller
    {

        // Imagine Accept method gets data from your razor page and u need to work on it in Accept Method

        [HttpPost]

        // Only Thing you need to do just use [ValidateAntiForgeryToken]
        // Do not use this over controller, use only over methods that works with data

        [ValidateAntiForgeryToken]
        public IActionResult Accept()
        {
            return View();
        }
    }
}
