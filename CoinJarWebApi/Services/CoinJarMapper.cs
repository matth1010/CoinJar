using CoinJarEntities;
using CoinJarWebApi.Shared.DTO;

namespace CoinJarWebApi.Services
{
    public class CoinJarMapper : ICoinJarMapper
    {
        public CoinCarrier MapToCarrier(CoinEntity coinEntity)
        {
            return new CoinCarrier()
            {
              Amount = coinEntity.Amount,
              Volume = coinEntity.Volume
            };
        }

        public CoinEntity MapToEntity(CoinCarrier coinCarrier)
        {
            return new CoinEntity()
            {
              Amount = coinCarrier.Amount,
              Volume = coinCarrier.Volume
            };
        }
    }
}