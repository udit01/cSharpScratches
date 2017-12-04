using System;
using System.Runtime.Serialization;

namespace WebAPIClient
{
    [DataContract(Name="repo")]
    public class Repository{

    /*  Before you add more features, let's address the repo type and make it follow more standard C# conventions.
        You'll do this by annotating the repo type with attributes that control how the JSON Serializer works.
        In your case, you'll use these attributes to define a mapping between the JSON key names and the C# class and member names.
        The two attributes used are the DataContract attribute and the DataMember attribute. 
        By convention, all Attribute classes end in the suffix Attribute. 
        However, you do not need to use that suffix when you apply an attribute.  */

    // public class repo{
        //Field names here match that of the field names in JSON object then only put inside by the serializer class
        //other wise ignored //so these field names don't follow c# conventions
        // public string name;

        [DataMember(Name="name")]
        public string Name{ get; set; }

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [DataMember(Name="homepage")]
        public Uri Homepage { get; set; }

        [DataMember(Name="watchers")]
        public int Watchers { get; set; }   

    }
}