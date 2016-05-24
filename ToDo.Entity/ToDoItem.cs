using System.Collections.Generic;
using ToDo.BusinessTier.BusinessTier.Abstract;

namespace ToDo.Entity
{
    public class ToDoItem : IToDoItem
    {
        private string _id;
        private string _title;
        private string _description;
        private bool _complete;
        private string _relatedId;
        private List<IRelatedItem> _relatedItems { get; set; }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }


        public string RelatedId
        {
            get { return _relatedId; }
            set { _relatedId = value; }
        }

        public List<IRelatedItem> RelatedItems
        {
            get { return _relatedItems; }
            set { _relatedItems = value; }
        }
    }
}
