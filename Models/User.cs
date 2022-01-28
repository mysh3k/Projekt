using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Login { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Username { get; set; }
        public bool Permissions { get; set; }
    }
}