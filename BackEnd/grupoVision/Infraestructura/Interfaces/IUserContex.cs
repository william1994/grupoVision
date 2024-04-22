using Infraestructura.Repositories.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface IUserContex
    {
        DbContext Instance { get; }
        DbSet<Usuariotbl> Usuarios { get; set; }
        DbSet<PassView> PassViews { get; set; }
    }
}
