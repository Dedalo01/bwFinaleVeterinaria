namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        public int Id { get; set; }

        public int? ExaminationId { get; set; }

        public int ProductId { get; set; }

        public int OwnerId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime SaleDate { get; set; }

        public virtual Examination Examination { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Product Product { get; set; }
    }
}
