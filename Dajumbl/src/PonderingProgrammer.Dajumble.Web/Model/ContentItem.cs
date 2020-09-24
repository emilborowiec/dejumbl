using System;

namespace PonderingProgrammer.Dajumble.Web.Model
{
    public class ContentItem
    {
        public ContentItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
        public ContentItemType Item { get; set; }
        public string Label { get; set; }
        public string Content { get; set; }
    }
}