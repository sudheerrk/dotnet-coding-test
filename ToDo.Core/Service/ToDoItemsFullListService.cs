using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Core.Service
{
    public class ToDoItemsFullListService: IToDoItemService
    {
        public IList<Entity.IToDoItem> GetTodoItems(string idFilter = "")
        {
            throw new NotImplementedException();
        }

        public string Save(Entity.IToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
