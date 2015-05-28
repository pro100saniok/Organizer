
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;

namespace Organizer_DataAccess.Repository
{
    public class TagRepository : ITagRepository
    {
     
        public Tag SaveTag(Tag tag)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    if (tag.TagId == 0)
                    {
                        context.Tags.Add(tag);
                    }
                    else
                    {
                        Tag oldTag = context.Tags.FirstOrDefault(c => c.TagId == tag.TagId);
                        if (oldTag != null)
                        {
                            oldTag.Name = tag.Name;
                            oldTag.UserName = tag.UserName;
                        }
                    }
                    context.SaveChanges();
                    return tag;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void DeleteTag(Tag tag)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    var entry = context.Entry(tag);
                    if (entry.State == EntityState.Detached)
                    {
                        context.Tags.Attach(tag);
                    }
                    context.Tags.Remove(tag);
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

        public Tag GetTagById(int? tagId)
        {
            using (var context = new OrganizerContext())
            {
                return context.Tags.FirstOrDefault(c => c.TagId == tagId);
            }
        }

        public List<Tag> GetAllTags(string userName)
        {
            using (var context = new OrganizerContext())
            {
                return context.Tags.Where(tag => tag.UserName == userName).ToList();
            }
        }
    }
}
