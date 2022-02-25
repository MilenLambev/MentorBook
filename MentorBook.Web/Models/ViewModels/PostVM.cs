using MentorBook.Data.Models;
using System;

namespace MentorBook.Web.Models.ViewModels
{
    public class PostVM
    {
        public PostVM(Post post)
        {
            Id = post.Id;
            UserId = post.UserId;
            UserName = $"{post.FirstName} {post.LastName}";
            SharedFromPostId = post.SharedFromPostId;
            Title = post.Title;
            Body = post.Body;
            CreatedDate = post.CreatedDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int SharedFromPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
