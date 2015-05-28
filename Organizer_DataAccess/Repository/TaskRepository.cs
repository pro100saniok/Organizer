
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Organizer_DataAccess.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public Task SaveTask(Task task)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    if (task.TaskId == 0)
                    {
                        context.Tasks.Add(task);
                    }
                    else
                    {
                        Task oldtask = context.Tasks.FirstOrDefault(c => c.TaskId == task.TaskId);
                        if (oldtask != null)
                        {
                            oldtask.Name = task.Name;
                            oldtask.UserName = task.UserName;
                            oldtask.Body = task.Body;
                            oldtask.DateStart = task.DateStart;
                            oldtask.DateEnd = task.DateEnd;
                            oldtask.TaskPriorityId = task.TaskPriorityId;
                        }
                    }
                    context.SaveChanges();
                    return task;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void DeleteTask(Task task)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    var entry = context.Entry(task);
                    if (entry.State == EntityState.Detached)
                    {
                        context.Tasks.Attach(task);
                    }
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public Task GetTaskById(int? taskId)
        {
            using (var context = new OrganizerContext())
            {
                return context.Tasks.Include(task => task.Priority).FirstOrDefault(c => c.TaskId == taskId);
            }
        }

        public List<Task> GetAllTask(string userName)
        {
            using (var context = new OrganizerContext())
            {
                return context.Tasks.Include(task => task.Priority).Where(task => task.UserName == userName).ToList();
            }
        }
    }
}
