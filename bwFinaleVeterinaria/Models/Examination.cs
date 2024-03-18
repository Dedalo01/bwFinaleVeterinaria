namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examination()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ExaminationDate { get; set; }

        [Required]
        public string ObjectiveExamimation { get; set; }

        [Required]
        public string TreatmentDescription { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
