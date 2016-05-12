using System;
using System.Collections.Generic;
namespace ToDo.Entity
{
    public interface IToDoItem
    {
        bool Complete { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        string Title { get; set; }
        string RelatedId { get; set; }
        Dictionary<string, string> RelatedItems { get; set; }
    }
}
