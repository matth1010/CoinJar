using CoinJarEntities;

namespace CoinJarLogic
{
    public interface ICoinJarManager
    {
		bool AddCoin(CoinEntity coin);
		decimal GetTotalAmount();
		void Reset();
	}
}
