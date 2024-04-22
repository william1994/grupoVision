using System;
using System.Collections.Generic;

namespace Core.Domain;

public partial class Usuario
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public byte[]? PassWord { get; set; }
}
