using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBook.Core.Entities
{
    [Table("phones")]
    public class Phone : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
    }
}
