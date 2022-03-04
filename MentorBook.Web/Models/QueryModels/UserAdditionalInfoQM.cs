using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Models.QueryModels
{
    public class UserAdditionalInfoQM
    {
        [Required]
        public int UserID {get; set;}
        [Required]
        public string Key {get;set;}
        [Required]
        public string Value{get;set;}
    }
}
