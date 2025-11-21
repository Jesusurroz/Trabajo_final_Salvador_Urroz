using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("Combustible")]
[Microsoft.EntityFrameworkCore.Index("Tipo", Name = "UQ__Combusti__8E762CB499E3749E", IsUnique = true)]
public partial class Combustible
{
    [Key]
    public int CombustibleId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [InverseProperty("Combustible")]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
