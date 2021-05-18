using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeltwaterServiceNetCore.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public long OrderId { get; set; }
    }
}
