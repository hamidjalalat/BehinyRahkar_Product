using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Models.Base
{
    public abstract class Entity : IEntity
    {
        protected Entity() : base()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }
    }
}
