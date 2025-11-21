using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("TipoVehiculo")]
[Microsoft.EntityFrameworkCore.Index("Nombre", Name = "UQ__TipoVehi__75E3EFCF0AD717FF", IsUnique = true)]
public partial class TipoVehiculo
{
    [Key]
    public int TipoVehiculoId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("TipoVehiculo")]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
