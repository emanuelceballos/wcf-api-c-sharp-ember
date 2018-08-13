using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using System.Collections.Generic;
using System.Data.Entity;
using Autofac;

namespace BloggingService.UnitTest
{
    [TestClass]
    public class BlogServiceTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBloggingContext> _context;
        private IContainer _container;

        [TestInitialize]
        public void SetUp()
        {
            _context = new Mock<IBloggingContext>();
            _context.Setup(b => b.Blogs).Returns(Mock.Of<DbSet<Blog>>);

            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(u => u.BlogRepository).Returns(Mock.Of<IGenericRepository<Blog>>);
            
            _container = GetMockedContainer(_context.Object, _unitOfWorkMock.Object);
        }

        private IContainer GetMockedContainer(IBloggingContext context, IUnitOfWork unitOfWork)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterInstance(context).As<IBloggingContext>();
            builder.RegisterInstance(unitOfWork).As<IUnitOfWork>();

            return builder.Build();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _container.Dispose();
        }

        [TestMethod]
        public void Get_ReturnsAllBlogs()
        {
            IBlogService service = new BlogService(_unitOfWorkMock.Object);
            Assert.IsInstanceOfType(service.Get(), typeof(List<DataContracts.Blog>));
        }
    }
}
