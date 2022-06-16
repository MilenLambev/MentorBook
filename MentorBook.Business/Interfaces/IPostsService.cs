using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Business
{
    public interface IPostsService
    {
        List<Post> GetPostsOfUser (int userId);
        List<Post> GetComments(int rootPostId);
        bool CreateComment(int rootPostId, int AuthorID, string CommentContent);
        List<Post> GetAggregatedPostsOfFriends(int userId);

    }
}
