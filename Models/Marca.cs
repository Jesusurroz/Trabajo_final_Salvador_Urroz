using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("Marca")]
[Microsoft.EntityFrameworkCore.Index("Nombre", Name = "UQ__Marca__75E3EFCF2F4BA9D0", IsUnique = true)]
public partial class Marca
{
    [Key]
    public int MarcaId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Marca")]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
