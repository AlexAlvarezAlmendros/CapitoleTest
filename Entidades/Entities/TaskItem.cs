using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskItem
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [Required]
        [StringLength(20, ErrorMessage = "The Name value cannot exceed 20 characters. ")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "The Name field can only contain letters, numbers, and spaces.")]
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public bool IsFavorite { get; set; }
    }
}
