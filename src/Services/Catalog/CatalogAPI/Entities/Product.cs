using MongoDB.Bson.Serialization.Attributes;

namespace CatalogAPI.Entities
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

		[BsonElement("Name")]
        public string Name { get; set; }

		public string Category { get; set; }


	}
}
