using System;

namespace PonderingProgrammer.Dajumble.Web.Model
{
    public class Context
    {
        public Context(string ownerUserId)
        {
            Id = Guid.NewGuid().ToString();
            OwnerUserId = ownerUserId;
        }

        public string Id { get; private set; }
        public string OwnerUserId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}