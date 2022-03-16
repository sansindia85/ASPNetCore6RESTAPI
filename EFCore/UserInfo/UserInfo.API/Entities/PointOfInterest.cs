﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo.API.Entities
{
    public class PointOfInterest
    {
        public PointOfInterest(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int UserId { get; set; }

    }
}