using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("child")]
    public class child
    {

        [Key]
        [Required]
        public int color2 { get; set; }

       [Required]
        public int ID { get; set; }
        [Required]
        public string location { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
