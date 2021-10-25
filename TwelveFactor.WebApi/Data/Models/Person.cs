using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwelveFactor.WebApi.Data.Models
{
    public class Person
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
