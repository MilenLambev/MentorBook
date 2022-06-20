using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Models.QueryModels
{
    public class CreateCountryQM
    {
        [Required]
        public string Name { get; set; }
    }
}
