﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebStockLibrary.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
