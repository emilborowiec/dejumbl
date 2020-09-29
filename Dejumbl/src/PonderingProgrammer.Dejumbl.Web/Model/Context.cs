using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Dejumbl.Web.Model
{
    public class Context
    {
        private List<ContentItem> _items = new List<ContentItem>();
        
        public Context(string ownerUserName, string contextKey)
        {
            OwnerUserName = ownerUserName ?? throw new ArgumentNullException(nameof(ownerUserName));
            ContextKey = contextKey ?? throw new ArgumentNullException(nameof(contextKey));
        }

        public string OwnerUserName { get; private set; }
        public string ContextKey { get; private set; }
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