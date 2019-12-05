using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3GraphQL.Models
{
    public class Model
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } 
        
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}