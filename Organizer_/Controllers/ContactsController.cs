using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System.Data;
using System.Net;
using System.Web.Mvc;
using PagedList;

namespace Organizer_.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: Notice
        public ActionResult Index(int page = 1)
        {
            var entries = _contactRepository.GetAllContact(User.Identity.Name);
            return View(entries.ToPagedList(page, 6));
        }


        public PartialViewResult CreateContact()
        {
            //return new model for create new article.
            return PartialView("UpdateContact", model: new Contact());
        }

        public ActionResult UpdateContact(int? id)
        {
            var contact = _contactRepository.GetContactById(id);
            return PartialView(model: contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContact(Contact contact)
        {
            try
            {
               ModelState.Remove("ContactId");
                // Test if article object and modelstate is valid.
                if (ModelState.IsValid)
                {
                    contact.UserName = User.Identity.Name;
                    _contactRepository.SaveContact(contact);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", @"ВведІть коректні дані");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @"Нажаль не вдалось зберегти зміни!");
            }
            return null;
        }

        public ActionResult DeleteContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var notice = _contactRepository.GetContactById(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("DeleteContact")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNoticeConfirmed(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            _contactRepository.DeleteContact(contact);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
    }
}