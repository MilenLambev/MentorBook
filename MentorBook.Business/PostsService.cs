using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorBook.Data.Models;
using MentorBook.Data.Repositories;

namespace MentorBook.Business
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public List<Post> GetAggregatedPostsOfFriends(int userId)
        {
            return _postsRepository.GetAggregatedPostsOfFriends(userId);
        }

        public List<Post> GetComments(int rootPostId)
        {
            return _postsRepository.GetComments(rootPostId);
        }

        public List<Post> GetPostsOfUser(int userId)
        {
            return _postsRepository.GetPostsOfUser(userId);
        }
    }
}
