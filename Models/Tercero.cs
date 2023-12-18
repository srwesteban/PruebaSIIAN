using System;
using System.Collections.Generic;

namespace Tienda2.Models;

public partial class Tercero
{
    public int Id { get; set; }

    public string? Identificacion { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Nombre1 { get; set; }

    public string? Nombre2 { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
