using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
