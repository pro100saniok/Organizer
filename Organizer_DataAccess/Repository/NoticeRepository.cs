
using System.Data.Entity;
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Organizer_DataAccess.Repository
{
    public class NoticeRepository : INoticeRepository
    {
        /// <summary>
        /// Saves the notice.
        /// </summary>
        /// <param name="notice">The notice.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public Notice SaveNotice(Notice notice)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    if (notice.NoticeId == 0)
                    {
                        notice.DateAdded = DateTime.Now;
                        context.Notices.Add(notice);
                    }
                    else
                    {
                        Notice oldNotice = context.Notices.FirstOrDefault(c => c.NoticeId == notice.NoticeId);
                        if (oldNotice != null)
                        {
                            oldNotice.Name = notice.Name;
                            oldNotice.Body = notice.Body;
                            oldNotice.DateAdded = DateTime.Now; 
                            oldNotice.UserName = notice.UserName;
                        }
                    }
                    context.SaveChanges();
                    return notice;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Deletes the notice.
        /// </summary>
        /// <param name="notice">The notice.</param>
        /// <exception cref="System.Exception">
        /// </exception>
        public void DeleteNotice(Notice notice)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    var entry = context.Entry(notice);
                    if (entry.State == EntityState.Detached)
                    {
                        context.Notices.Attach(notice);
                    }
                    context.Notices.Remove(notice);
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

        /// <summary>
        /// Gets the notice by identifier.
        /// </summary>
        /// <param name="noticeId">The notice identifier.</param>
        /// <returns></returns>
        public Notice GetNoticeById(int? noticeId)
        {
            using (var context = new OrganizerContext())
            {
                return context.Notices.FirstOrDefault(c => c.NoticeId == noticeId);
            }
        }

        /// <summary>
        /// Gets all notice.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public List<Notice> GetAllNotice(string userName)
        {
            using (var context = new OrganizerContext())
            {
                return context.Notices.Where(notice => notice.UserName == userName).ToList();
            }
        }
    }
}
