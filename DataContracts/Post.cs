using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class Post : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "id")]
        public int Id { get; set; }
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "title")]
        public string Title { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "content")]
        public string Content { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "blogId")]
        public int BlogId { get; set; }

        #region ExtensibleDataObject member implementation

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
