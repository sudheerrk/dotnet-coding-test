using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Core.Factory
{
    public class ToDoItemsFullListServiceFactory
    {
        public ToDoItemsFullListServiceFactory()
        { }

        public IToDoItemService CreateInstance()
        {
            // Instantiate to do item service with an MsSql mapper - hard coded for now
            MapperFactory mapperFactory = new MapperFactory(DA.Enumerations.DataStores.MsSql);

            IToDoItemService tis = new ToDoItemService(mapperFactory.GetToDoItemMapper());
            return tis;
        }

    }
}
