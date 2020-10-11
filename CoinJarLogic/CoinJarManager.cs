using CoinJarEntities;
using System;
using System.Collections.Generic;

namespace CoinJarLogic
{
	public class CoinJarManager : ICoinJarManager
	{
		readonly Dictionary<int, CoinEntity> _coinJar = new Dictionary<int, CoinEntity>();

		public int Id { get; private set; }
		public decimal TotalVolume { get; private set; }
		public decimal UsedVolume { get; private set; }
		public decimal TotalValue { get; private set; }

		public CoinJarManager()
		{
			this.Id = 0;
			this.TotalValue = 0;
			this.TotalVolume = 42;
			this.UsedVolume = 0;
		}

		public bool AddCoin(CoinEntity coin)
		{
			if (coin.Volume + this.UsedVolume > this.TotalVolume)
			{
				return false;
			}

			_coinJar.Add(Id++, coin);

			this.TotalValue += coin.Amount;
			this.UsedVolume += coin.Volume;

			return true;
		}

		public decimal GetTotalAmount()
		{
			return this.TotalValue;
		}

		public void Reset()
		{
			_coinJar.Clear();
			this.Id = 0;
			this.TotalValue = 0;
			this.UsedVolume = 0;
		}
	}
}