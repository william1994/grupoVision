
using Core.Domain;
using Core.Interface;
using Infraestructura.Interfaces;
namespace Core.UseCase
{
    public class UseCaseUser : IUseCaseUser
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Usuario> ValidacionUsuario(string user, string password)
        {
            var result = _userRepository.userValid(user, password);
           return result.Count()==0? null : result;
            
        }
    }
}
