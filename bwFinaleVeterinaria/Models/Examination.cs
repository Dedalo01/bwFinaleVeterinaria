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

        [Display(Name = "Data della visita")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        [Column(TypeName = "smalldatetime")]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = "Esame obiettivo")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        public string ObjectiveExamimation { get; set; }

        [Display(Name = "Descrizione del trattamento")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        public string TreatmentDescription { get; set; }

        [Display(Name = "ID Animale")]
        [Required(ErrorMessage = "È necessario selezionare un animale.")]
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
