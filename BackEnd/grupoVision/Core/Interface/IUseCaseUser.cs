using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUseCaseUser
    {
        public IEnumerable<Usuario> ValidacionUsuario(string user, string password);
    }
}
