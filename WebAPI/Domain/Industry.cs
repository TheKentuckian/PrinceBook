using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrinceBookWebAPI.Models
{
    public class Industry
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
