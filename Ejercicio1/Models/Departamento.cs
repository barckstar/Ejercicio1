using System;
using System.Collections.Generic;

namespace Ejercicio1.Models;

public partial class Departamento
{
    public int DepartamentoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Asociado> Asociados { get; set; } = new List<Asociado>();
}
