using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Agility.Api.Backlog.Domain.Customers
{
    public class AccountCollection : Collection<Guid>
    {
        public AccountCollection()
        {

        }

        public AccountCollection(IEnumerable<Guid> list)
        {
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }
    }
}
