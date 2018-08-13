using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BloggingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBlogService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/api/v1/blogs", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        int AddBlog(DataContracts.Blog blog);

        [WebInvoke(Method = "PUT", UriTemplate = "/api/v1/blogs/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void EditBlog(string id, DataContracts.Blog blog);

        [WebInvoke(Method = "DELETE", UriTemplate = "/api/v1/blogs/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void DeleteBlog(string id);

        [WebGet(UriTemplate = "/api/v1/blogs/{id}", ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        DataContracts.Blog GetById(string id);

        [WebGet(UriTemplate = "/api/v1/blogs", ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        List<DataContracts.Blog> Get();
    }
    
}
