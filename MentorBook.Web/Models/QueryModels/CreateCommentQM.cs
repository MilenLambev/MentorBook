using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBook.Web.Models.QueryModels
{
    public class CreateCommentQM
    {
        [Required]
        public int rootPostId { get; set; }
        [Required]
        public string AuthorID { get; set; }
        [Required]
        public string CommentContent { get; set; }
    }
}
