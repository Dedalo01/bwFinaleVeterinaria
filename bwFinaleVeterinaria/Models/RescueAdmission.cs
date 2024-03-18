namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RescueAdmission
    {
        public int Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime AdmissionDate { get; set; }

        [Required]
        public string PetImageUrl { get; set; }

        public int PetId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndAdmissionDate { get; set; }

        public decimal? Price { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
