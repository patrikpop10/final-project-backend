using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace models
{
    public class Characters
    {

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("count")]
        public int Count { get; set; }

        [BsonElement("coreference_list")]
        public ICollection<string> CoreferenceList { get; set; }
        [BsonElement("adjecency_list")]
        public Dictionary<string, int> AdjecencyList { get; set; }
    }
}