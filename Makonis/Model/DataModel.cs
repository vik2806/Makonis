using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.Model
{
    public class DataModel
    {
        [Required(ErrorMessage = "First name required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name required!")]
        public string LastName { get; set; }
    }
}
