using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Dajumble.Web.Model
{
    public class Context
    {
        private List<ContentItem> _items = new List<ContentItem>();
        
        public Context(string ownerUserId)
        {
            Id = Guid.NewGuid().ToString();
            OwnerUserId = ownerUserId;
        }

        public string Id { get; private set; }
        public string OwnerUserId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ContentItem> Items => _items.ToList();

        public void AddItem(ContentItem item)
        {
            _items.Add(item);
        }

        public bool RemoveItem(ContentItem item)
        {
            return _items.Remove(item);
        }
    }
}