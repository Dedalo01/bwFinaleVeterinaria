namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Owner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owner()
        {
            Pets = new HashSet<Pet>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        public string Surname { get; set; }

        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Il campo è obbligatorio.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Codice Fiscale non corretto.")]
        public string FiscalCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
