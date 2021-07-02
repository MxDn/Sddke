using System;

namespace Agility.Api.Backlog.Domain
{
    public class Entity : IEntity
    {
        private Guid id = Guid.NewGuid();
        public virtual Guid Id
        {
            get
            {
                return id;
            }
            protected set
            {
                id = value;
            }
        }
    }
}
