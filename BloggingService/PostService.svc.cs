using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataContracts;
using Repository;

namespace BloggingService
{
    public class PostService : IPostService
    {
        private IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddPost(DataContracts.Post Post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public void EditPost(string id, DataContracts.Post Post)
        {
            throw new NotImplementedException();
        }

        public DataContracts.Post Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.Post> GetById(string blogId)
        {
            int intBlogId;
            if (!int.TryParse(blogId, out intBlogId))
            {
                return null;
            }

            List<Repository.Post> posts = _unitOfWork.PostRepository.Get(p => p.BlogId == intBlogId).ToList();
            List<DataContracts.Post> returnList = new List<DataContracts.Post>();

            foreach (Repository.Post post in posts)
            {
                returnList.Add(
                    new DataContracts.Post
                    {
                        Id = post.PostId,
                        Title = post.Title,
                        BlogId = post.BlogId,
                        Content = post.Content
                    }
                );
            }

            return returnList;
        }
    }
}