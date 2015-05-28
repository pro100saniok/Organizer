using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using PagedList;

namespace Organizer_.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskPriorityRepository _taskPriorityRepository;
        public TaskController(ITaskRepository taskRepository, ITaskPriorityRepository taskPriorityRepository)
        {
            _taskRepository = taskRepository;
            _taskPriorityRepository = taskPriorityRepository;
        }

       public ActionResult Index(int? selectedDepartment, int page = 1)
        {
            var departments = _taskPriorityRepository.GetAllTaskPriorities();
            ViewBag.SelectedDepartment = new SelectList(departments, "TaskPriorityId", "Name", selectedDepartment);
            int departmentId = selectedDepartment.GetValueOrDefault();

            IEnumerable<Task> courses =
                _taskRepository.GetAllTask(User.Identity.Name)
                    .Where(c => !selectedDepartment.HasValue || c.TaskPriorityId == departmentId);

            //  var sql = courses.ToString();
            return View(courses.ToList().ToPagedList(page, 6));
        }

        public PartialViewResult CreateTask()
        {
            PopulateDepartmentsDropDownList();
            return PartialView("UpdateTask", model: new Task());
        }

        public ActionResult UpdateTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            PopulateDepartmentsDropDownList(task.TaskPriorityId);
            return PartialView(model: task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTask(Task task)
        {
            try
            {
                // Test if article object and modelstate is valid.
                if (ModelState.IsValid)
                {
                    task.UserName = User.Identity.Name;
                    _taskRepository.SaveTask(task);
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

        public ActionResult DeleteTask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            
            return View(task);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("DeleteTask")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTaskConfirmed(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            _taskRepository.DeleteTask(task);
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _taskPriorityRepository.GetAllTaskPriorities();
            ViewBag.TaskPriorityId = new SelectList(departmentsQuery, "TaskPriorityId", "Name", selectedDepartment);
        }
    }
}