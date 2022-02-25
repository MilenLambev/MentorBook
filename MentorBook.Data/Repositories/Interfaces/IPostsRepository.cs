using MentorBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBook.Data.Repositories
{
    public interface IPostsRepository
    {
        List<Post> GetPostsOfUser(int userId);
        List<Post> GetComments(int rootPostId);
        List<Post> GetAggregatedPostsOfFriends(int userId);
    }
}
