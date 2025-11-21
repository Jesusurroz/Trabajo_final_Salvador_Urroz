using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("Vehiculo")]
[Microsoft.EntityFrameworkCore.Index("Codigo", Name = "UQ__Vehiculo__06370DAC01948AEF", IsUnique = true)]
[Microsoft.EntityFrameworkCore.Index("NumeroChasis", Name = "UQ__Vehiculo__FDB1AF9A2339DC08", IsUnique = true)]
public partial class Vehiculo
{
    [Key]
    public int VehiculoId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    public int MarcaId { get; set; }

    public int TipoVehiculoId { get; set; }

    public int CombustibleId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Modelo { get; set; } = null!;

    public int AñoProduccion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NumeroChasis { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Cilindraje { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal PrecioCompra { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal PrecioVenta { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaIngreso { get; set; }

    [Column(TypeName = "text")]
    public string? Observaciones { get; set; }

    [ForeignKey("CombustibleId")]
    [InverseProperty("Vehiculos")]
    public virtual Combustible Combustible { get; set; } = null!;

    [ForeignKey("MarcaId")]
    [InverseProperty("Vehiculos")]
    public virtual Marca Marca { get; set; } = null!;

    [ForeignKey("TipoVehiculoId")]
    [InverseProperty("Vehiculos")]
    public virtual TipoVehiculo TipoVehiculo { get; set; } = null!;

    [InverseProperty("Vehiculo")]
    public virtual ICollection<VehiculoFoto> VehiculoFotos { get; set; } = new List<VehiculoFoto>();

    [InverseProperty("Vehiculo")]
    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
