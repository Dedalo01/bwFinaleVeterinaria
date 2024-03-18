namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cabinet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string NumericCode { get; set; }

        public int DrawerId { get; set; }

        public int ProductId { get; set; }

        public virtual Drawer Drawer { get; set; }

        public virtual Product Product { get; set; }
    }
}
