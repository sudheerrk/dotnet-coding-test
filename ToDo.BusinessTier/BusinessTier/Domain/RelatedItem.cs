using ToDo.BusinessTier.BusinessTier.Abstract;

namespace ToDo.BusinessTier.BusinessTier.Domain
{
    public class RelatedItem : IRelatedItem
    {
        public string id { get; set; }

        public string title { get; set; }
    }
}
