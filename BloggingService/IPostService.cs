using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BloggingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPostService" in both code and config file together.
    [ServiceContract]
    public interface IPostService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/api/v1/posts", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        int AddPost(DataContracts.Post Post);

        [WebInvoke(Method = "DELETE", UriTemplate = "/api/v1/posts/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void DeletePost(string id);

        [WebInvoke(Method = "PUT", UriTemplate = "/api/v1/posts/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void EditPost(string id, DataContracts.Post Post);

        [WebGet(UriTemplate = "/api/v1/posts/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        DataContracts.Post Get(string id);

        [WebGet(UriTemplate = "/api/v1/posts?blogId={blogId}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<DataContracts.Post> GetById(string blogId);
    }
}