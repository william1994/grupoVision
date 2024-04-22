using Core.Dto;
using Core.Interface;

namespace Core.Interface
{
    public interface IAutorizacionService
    {

        AutorizacionResponse DevolverToken(AutorizacionRequest autorizacion,string id);
       // Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUsuario);
    }
}
