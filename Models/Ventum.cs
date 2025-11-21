using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

public partial class Ventum
{
    [Key]
    public int VentaId { get; set; }

    public int VehiculoId { get; set; }

    public int ClienteId { get; set; }

    public int EmpleadoId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaVenta { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal PrecioFinal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MetodoPago { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal DescuentoPorc { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Venta")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Venta")]
    public virtual Empleado Empleado { get; set; } = null!;

    [ForeignKey("VehiculoId")]
    [InverseProperty("Venta")]
    public virtual Vehiculo Vehiculo { get; set; } = null!;
}
