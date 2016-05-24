using System.Collections.Generic;
using ToDo.BusinessTier.BusinessTier.Abstract;

namespace ToDo.Entity
{
    public interface IToDoItem
    {
        bool Complete { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        string Title { get; set; }
        string RelatedId { get; set; }
        List<IRelatedItem> RelatedItems { get; set; }
    }
}
