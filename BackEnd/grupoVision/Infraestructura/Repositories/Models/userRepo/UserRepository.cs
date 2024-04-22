using AutoMapper;
using Core.Domain;
using Infraestructura.Interfaces;
using Infraestructura.Repositories.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories.Models.userRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IUserContex _userContex;

        public UserRepository(IMapper mapper, IUserContex userContex)
        {
            _mapper = mapper;
            _userContex = userContex;
        }

        public IEnumerable <Usuario> userValid(string user, string password)
        {
            var pass = new SqlParameter("@pass", System.Data.SqlDbType.VarChar);
            var usu = new SqlParameter("@usuario", System.Data.SqlDbType.VarChar);
            pass.Value = password;
            usu.Value = user;
            var result = _mapper.Map<IEnumerable<Usuario>>(
                    _userContex.Usuarios.FromSqlRaw("exec VerificacionUsuario @usuario,@pass", usu, pass).ToList()
                    );
            return result;

        }
    }
}
