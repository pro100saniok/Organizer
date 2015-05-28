using Organizer_Domain.EntityModel;
using System.Collections.Generic;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
   public interface ITaskPriorityRepository
    {
        TaskPriority SaveTaskPriority(TaskPriority taskPriority);

        void DeleteTaskPriority(TaskPriority taskPriority);

        List<TaskPriority> GetAllTaskPriorities();

        TaskPriority GetTaskPriorityById(int? taskPriorityId);
    }
}
