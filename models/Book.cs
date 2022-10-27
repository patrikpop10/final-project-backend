using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace models;
[BsonIgnoreExtraElements]
public class Book
{

    [BsonElement("text")]
    public string Text { get; set; }

    [BsonElement("language")]
    public string Language { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("author")]
    public string Author { get; set; }
    [BsonElement("series")]
    public string Series { get; set; }
    [BsonElement("categories")]
    public ICollection<string> Categories { get; set; }
    [BsonElement("characters")]
    public ICollection<Characters> Characters { get; set; }
}
