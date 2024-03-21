using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bwFinaleVeterinaria.Models
{
    public class ProductAddViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string PossibleUses { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Display(Name = "Drawer")]
        public int DrawerId { get; set; }

        [Required]
        [Display(Name = "Numeric Code")]
        public string NumericCode { get; set; }

        [Display(Name = "Cabinet")]
        public int CabinetId { get; set; }

        [Display(Name = "Drawer Number")]
        public short DrawerNumber { get; set; }





        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Drawer> Drawers { get; set; }
        public IEnumerable<Cabinet> Cabinets { get; set; }

        public IEnumerable<string> ProductTypes { get; } = new List<string> { "Farmaco", "Alimentare" };
    }
}