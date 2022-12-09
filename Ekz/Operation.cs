using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz
{
    public class Operation
    {
        [Key]
        public int ID { get; set; }
        public float Cost { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}
