namespace SeminarskiRad.Models.Context.SeminarContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentSurname { get; set; }

        [Required]
        [StringLength(150)]
        public string StudentAddress { get; set; }

        public int SeminarID { get; set; }

        public bool Approved { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
