using System;
using DataContracts;
using Repository;
using System.Collections.Generic;
using Autofac;

namespace BloggingService
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IContainer container;

        public static void SetContainer(IContainer mockedContainer)
        {
            container = mockedContainer;
        }

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddBlog(DataContracts.Blog blog)
        {
            Repository.Blog entityBlog = new Repository.Blog { Name = blog.Name, Url = blog.Url };
            _unitOfWork.BlogRepository.Insert(entityBlog);
            _unitOfWork.Save();

            return entityBlog.BlogId;
        }

        public void DeleteBlog(string blogId)
        {
            throw new NotImplementedException();
        }

        public void EditBlog(string id, DataContracts.Blog blog)
        {
            throw new NotImplementedException();
        }

        public DataContracts.Blog GetById(string id)
        {
            Repository.Blog blog = this._unitOfWork.BlogRepository.GetByID(id);

            return new DataContracts.Blog
            {
                Id = blog.BlogId,
                Name = blog.Name
            };
        }

        public List<DataContracts.Blog> Get()
        {
            var blogsList = this._unitOfWork.BlogRepository.Get();
            List<DataContracts.Blog> returnList = new List<DataContracts.Blog>();

            foreach (Repository.Blog blog in blogsList)
            {
                returnList.Add(
                    new DataContracts.Blog
                    {
                        Id = blog.BlogId,
                        Name = blog.Name
                    }
                );
            }

            return returnList;
        }
    }
}
