
using Organizer_Domain.EntityModel;
using System.Collections.Generic;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskRepository
    {
        Task SaveTask(Task task);

        void DeleteTask(Task task);

        Task GetTaskById(int? taskId);

        List<Task> GetAllTask(string userName);
    }
}
