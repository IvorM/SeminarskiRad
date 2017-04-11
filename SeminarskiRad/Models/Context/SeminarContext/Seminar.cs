using System.ComponentModel;

namespace SeminarskiRad.Models.Context.SeminarContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seminar")]
    public partial class Seminar
    {
        public Seminar()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Naziv")]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Opis")]
        public string SeminarDescription { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime SeminarDate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Profesor")]
        public string Teacher { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Closed { get; set; }

        [Required]
        [Display(Name = "Moguci broj polaznika")]
        public int MaxStudents { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
