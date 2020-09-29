using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Dejumble.Web.Model
{
    public class ContentItem
    {
        private HashSet<Relation> _outgoingRelations = new HashSet<Relation>();
        
        public ContentItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
        public ContentItemType ItemType { get; set; }
        public string Label { get; set; }
        public string Content { get; set; }
        public IEnumerable<Relation> OutgoingRelations => _outgoingRelations.ToList();

        public bool AddRelation(ContentItem target, RelationType relationType)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (target == this) throw new ArgumentException("Cannot relate to self", nameof(target));
            var relation = new Relation(this, target, relationType);
            return _outgoingRelations.Add(relation);
        }

        public bool DropRelation(Relation relation)
        {
            return _outgoingRelations.Remove(relation);
        }
    }
}