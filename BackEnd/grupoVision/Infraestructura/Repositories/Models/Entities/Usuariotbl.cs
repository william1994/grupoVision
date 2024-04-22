using System;
using System.Collections.Generic;

namespace Infraestructura.Repositories.Models.Entities;

public partial class Usuariotbl
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public byte[]? PassWord { get; set; }
}
