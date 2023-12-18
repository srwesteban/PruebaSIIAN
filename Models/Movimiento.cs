using System;
using System.Collections.Generic;

namespace Tienda2.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public int Idtercero { get; set; }

    public DateOnly? Fecha { get; set; }

    public bool gasto { get; set; }

    public bool ingreso { get; set; }

    public string? Detalle { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Valorunitario { get; set; }

    public decimal? Valortotal { get; set; }

    public virtual Tercero? IdCliente { get; set; } = null!;
}
