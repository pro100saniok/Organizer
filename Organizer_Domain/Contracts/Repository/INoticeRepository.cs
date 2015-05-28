
using System.Collections.Generic;
using Organizer_Domain.EntityModel;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface INoticeRepository
    {
        Notice SaveNotice(Notice notice);

        void DeleteNotice(Notice notice);

        Notice GetNoticeById(int? noticeId);

        List<Notice> GetAllNotice(string userName);

    }
}
