using System;
using System.Collections.Generic;

namespace Ejercicio1.Models;

public partial class Asociado
{
    public int AsociadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Salario { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }
}
