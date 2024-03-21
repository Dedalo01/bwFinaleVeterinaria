namespace bwFinaleVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo Username è obbligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [StringLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}
