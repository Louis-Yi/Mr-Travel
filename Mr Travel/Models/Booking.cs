namespace Mr_Travel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255,MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string User_ID { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
