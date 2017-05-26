namespace RvaRoofing.Controllers
{
    using System.Web.Mvc;
    using Helpers;
    using ViewModels;

    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel submission)
        {
            if (ModelState.IsValid)
            {
                var name = submission.FirstName + " " + submission.LastName;
                var message = "This is email was generated from the online contact form. original message - " +
                              submission.Message;

                Emailer.SendMsg(null, submission.FromEmail, name, "New online contact form submission.", message);

                return RedirectToAction("Success");
            }
            return View(submission);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}