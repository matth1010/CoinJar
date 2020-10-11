using CoinJarEntities;
using CoinJarWebApi.Shared.DTO;

namespace CoinJarWebApi.Services
{
    public interface ICoinJarMapper
    {
        CoinCarrier MapToCarrier(CoinEntity coinEntity);
        CoinEntity MapToEntity(CoinCarrier coinCarrier);
    }
}