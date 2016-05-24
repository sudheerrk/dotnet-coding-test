using System.Collections.Generic;
using System.Runtime.Serialization;
using ToDo.BusinessTier.BusinessTier.Abstract;

namespace ToDo.WCF.Contract
{
    [DataContract]
    public class ToDoItemContract
    {
        [DataMember]
        public string Id
        { get; set; }

        [DataMember]
        public string Title
        { get; set; }

        [DataMember]
        public string Description
        { get; set; }

        [DataMember]
        public bool Complete
        { get; set; }

        [DataMember]
        public string RelatedId
        { get; set; }

        [DataMember]
        public List<IRelatedItem> RelatedItems
        { get; set; }
    }
}