using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcMovie.Models
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string Thread { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Contents { get; set; }

        [Required]
        [ForeignKey("User")]
        public int? UserID { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public int? MovieID { get; set; }

    }



}