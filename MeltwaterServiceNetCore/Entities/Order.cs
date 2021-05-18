using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeltwaterServiceNetCore.Entities
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
