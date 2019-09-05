using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}
