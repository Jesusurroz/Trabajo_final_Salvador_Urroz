using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Autos_Narla_Salvador_Urroz.Models;

[Table("Empleado")]
public partial class Empleado
{
    [Key]
    public int EmpleadoId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Cargo { get; set; } = null!;

    [InverseProperty("Empleado")]
    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
