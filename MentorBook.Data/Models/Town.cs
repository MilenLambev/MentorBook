using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }  
    }
}
