using System.Data;
using System.Net;
using System.Web.Mvc;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;

namespace Organizer_.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: Notice
        public PartialViewResult Index()
        {
            var entries = _tagRepository.GetAllTags(User.Identity.Name);
            return PartialView(entries);
        }

        public PartialViewResult CreateTag()
        {
            //return new model for create new article.
            return PartialView("UpdateTag", model: new Tag());
        }

        public ActionResult UpdateTag(int id)
        {
            var taskPriority = _tagRepository.GetTagById(id);
            return PartialView(model: taskPriority);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTag(Tag tag)
        {
            try
            {
                // Test if article object and modelstate is valid.
                if (ModelState.IsValid)
                {
                    tag.UserName = User.Identity.Name;
                    _tagRepository.SaveTag(tag);
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

        public ActionResult DeleteTag(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tag = _tagRepository.GetTagById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("DeleteTag")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTagPriorityConfirmed(int id)
        {
            var tag = _tagRepository.GetTagById(id);
            _tagRepository.DeleteTag(tag);
            return RedirectToAction("Index");
        }
    }
}