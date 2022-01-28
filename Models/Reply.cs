using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Post")]
        public int? PostID { get; set; }
        public virtual Post Post { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string Contents { get; set; }

    }


}