using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class Blog : IExtensibleDataObject
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "id")]
        public int Id { get; set; }
        [DataMember(EmitDefaultValue=true, IsRequired=true, Name="name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "url")]
        public string Url { get; set; }

        #region ExtensibleDataObject member implementation

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
