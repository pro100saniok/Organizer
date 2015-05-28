
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Organizer_Domain.EntityModel;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITagRepository
    {
        Tag SaveTag(Tag tag);

        void DeleteTag(Tag tag);

        Tag GetTagById(int? tagId);

        List<Tag> GetAllTags(string userName);

      
    }
}
