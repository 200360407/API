using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("company")]
    public class company
    {
        [Required]
        public int ID { get; set; }

       [Required]
        public string name { get; set; }

        [Key]
      [Required]
        public string color { get; set; }
    }
}
