using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3GraphQL.Models
{
    [Table(name: "users")]
    public class Users : Model
    {
        [Column("username")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public String Username { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email cannot be loner then 100 characters")]
        public String Email { get; set; }
        
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }
        
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }
         
        [DefaultValue(false)]
        [Column("email_confirmed")]
        public bool EmailConfirmed { get; set; }

        [Column("first_name")]
        [StringLength(60, ErrorMessage = "First name cannot be loner then 100 characters")]
        public String FirstName { get; set; }

        [Column("last_name")]
        [StringLength(60, ErrorMessage = "Last name cannot be loner then 100 characters")]
        public String LastName { get; set; }
        
        [Column("token")]
        public String Token { get; set; }
    }
}