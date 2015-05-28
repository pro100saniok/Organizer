using System.Collections.Generic;
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System;
using System.Data.Entity;
using System.Linq;

namespace Organizer_DataAccess.Repository
{
    public class TaskPriorityRepository : ITaskPriorityRepository
    {
        public TaskPriority SaveTaskPriority(TaskPriority taskPriority)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    if (taskPriority.TaskPriorityId == 0)
                    {
                        context.TaskPriorities.Add(taskPriority);
                    }
                    else
                    {
                        TaskPriority oldTaskPriority = context.TaskPriorities.FirstOrDefault(c => c.TaskPriorityId == taskPriority.TaskPriorityId);
                        if (oldTaskPriority != null)
                        {
                            oldTaskPriority.Name = taskPriority.Name;
                        }
                    }
                    context.SaveChanges();
                    return taskPriority;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void DeleteTaskPriority(TaskPriority taskPriority)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    var entry = context.Entry(taskPriority);
                    if (entry.State == EntityState.Detached)
                    {
                        context.TaskPriorities.Attach(taskPriority);
                    }
                    context.TaskPriorities.Remove(taskPriority);
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

        public List<TaskPriority> GetAllTaskPriorities()
        {
            using (var context = new OrganizerContext())
            {
                return context.TaskPriorities.ToList();
            }
        }

        public TaskPriority GetTaskPriorityById(int? taskPriorityId)
        {
            using (var context = new OrganizerContext())
            {
                return context.TaskPriorities.FirstOrDefault(c => c.TaskPriorityId == taskPriorityId);
            }
        }
    }
}
