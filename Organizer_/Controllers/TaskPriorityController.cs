using System.Data;
using System.Net;
using System.Web.Mvc;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;

namespace Organizer_.Controllers
{
    public class TaskPriorityController : Controller
    {
        private readonly ITaskPriorityRepository _taskRepository;

        public TaskPriorityController(ITaskPriorityRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: Notice
        public PartialViewResult Index()
        {
            var entries = _taskRepository.GetAllTaskPriorities();
            return PartialView(entries);
        }

        public PartialViewResult CreateTaskPriority()
        {
            //return new model for create new article.
            return PartialView("UpdateTaskPriority", model: new TaskPriority());
        }

        public ActionResult UpdateTaskPriority(int id)
        {
            var taskPriority = _taskRepository.GetTaskPriorityById(id);
            return PartialView(model: taskPriority);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTaskPriority(TaskPriority taskPriority)
        {
            try
            {
                // Test if article object and modelstate is valid.
                if (ModelState.IsValid)
                {
                    _taskRepository.SaveTaskPriority(taskPriority);
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

        public ActionResult DeleteTaskPriority(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskPriority = _taskRepository.GetTaskPriorityById(id);
            if (taskPriority == null)
            {
                return HttpNotFound();
            }
            return View(taskPriority);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("DeleteTaskPriority")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTaskPriorityConfirmed(int id)
        {
            var taskPriority = _taskRepository.GetTaskPriorityById(id);
            _taskRepository.DeleteTaskPriority(taskPriority);
            return RedirectToAction("Index");
        }
    }
}