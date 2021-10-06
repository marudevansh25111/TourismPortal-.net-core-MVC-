using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Tourism_Portal.Models
{
    public class Destinations
    {
        [Key]
        public int Id { get; set; }
        public String destination { get; set; }
    }
}
