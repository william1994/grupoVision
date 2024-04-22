using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<Usuario> userValid(string user, string password);
    }
}
