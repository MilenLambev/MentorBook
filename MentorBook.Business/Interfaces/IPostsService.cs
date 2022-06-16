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
        void CreateComment(int postID, int authorID, string commContent);
        List<Post> GetAggregatedPostsOfFriends(int userId);

    }
}
