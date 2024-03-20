using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bwFinaleVeterinaria.Models;

namespace bwFinaleVeterinaria.Models
{
    public class SalesViewModel
    {
        [Required(ErrorMessage = "Seleziona un prodotto valido")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Seleziona un proprietario valido")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Seleziona un operazione valida")]
        public int ExaminationId { get; set; }

        [Required(ErrorMessage = "Inserisci una data valida")]
        public DateTime SaleDate { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Examination> Examinations { get; set; }
    }
}