using System;

namespace PonderingProgrammer.Dejumble.Web.Model
{
    public class Relation : IEquatable<Relation>
    {
        public bool Equals(Relation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Source, other.Source) && Equals(Target, other.Target) && RelationType == other.RelationType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Relation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Source, Target, (int) RelationType);
        }

        public static bool operator ==(Relation left, Relation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Relation left, Relation right)
        {
            return !Equals(left, right);
        }

        public Relation()
        {
        }

        public Relation(ContentItem source, ContentItem target, RelationType relationType) : this()
        {
            Source = source;
            Target = target;
        }

        public ContentItem Source { get; private set; }
        public ContentItem Target { get; private set; }
        public RelationType RelationType { get; set; }
    }
}