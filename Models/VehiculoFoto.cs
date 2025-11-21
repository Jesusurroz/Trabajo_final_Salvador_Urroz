using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("VehiculoFoto")]
public partial class VehiculoFoto
{
    [Key]
    public int FotoId { get; set; }

    public int VehiculoId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    public int Orden { get; set; }

    [ForeignKey("VehiculoId")]
    [InverseProperty("VehiculoFotos")]
    public virtual Vehiculo Vehiculo { get; set; } = null!;
}
