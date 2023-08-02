﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(1000, ErrorMessage = "The Comments must be at most 1000 characters long.")]
        public string? Comments { get; set; }

        [Range(1, 5, ErrorMessage = "The Ratings field must be between 1 and 5.")]
        public int Ratings { get; set; }

        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }
    }
}
