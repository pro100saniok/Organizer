using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System.Data;
using System.Net;
using System.Web.Mvc;
using PagedList;

namespace Organizer_.Controllers
{
    [Authorize]
    public class NoticeController : Controller
    {
        private readonly INoticeRepository _noticeRepository;

        public NoticeController(INoticeRepository noticeRepository)
        {
            _noticeRepository = noticeRepository;
        }

        // GET: Notice
        public ActionResult Index(int page = 1)
        {
            var entries = _noticeRepository.GetAllNotice(User.Identity.Name);
            return View(entries.ToPagedList(page, 6));
        }

        public PartialViewResult CreateNotice()
        {
            //return new model for create new article.
            return PartialView("UpdateNotice", model: new Organizer_Domain.EntityModel.Notice());
        }

        public ActionResult UpdateNotice(int id)
        {
            var notice = _noticeRepository.GetNoticeById(id);
            return PartialView(model: notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNotice(Notice notice)
        {
            try
            {
                // Test if article object and modelstate is valid.
                if (ModelState.IsValid)
                {
                    notice.UserName = User.Identity.Name;
                    _noticeRepository.SaveNotice(notice);
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

        public ActionResult DeleteNotice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var notice = _noticeRepository.GetNoticeById(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("DeleteNotice")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNoticeConfirmed(int id)
        {
            var notice = _noticeRepository.GetNoticeById(id);
            _noticeRepository.DeleteNotice(notice);
            return RedirectToAction("Index");
        }
    }
}