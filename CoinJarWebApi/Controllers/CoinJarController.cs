using System.Web.Http;
using CoinJarEntities;
using CoinJarLogic;
using CoinJarWebApi.Services;
using CoinJarWebApi.Shared;
using CoinJarWebApi.Shared.DTO;

namespace CoinJarWebApi.Controllers
{
	[Route(ApiControllerRoutes.CoinJarController.ControllerPrefix)]
	public class CoinJarController : ApiController
	{
		private readonly ICoinJarManager _coinJarManager;
		private readonly ICoinJarMapper _coinJarMapper;

		public CoinJarController(ICoinJarManager coinJarManager, ICoinJarMapper coinJarMapper)
		{
			_coinJarManager = coinJarManager;
			_coinJarMapper = coinJarMapper;
		}

		/// <summary>
		/// Add Coins to Your Jar in Dollars - Max Ounces = 42
		/// </summary>
		/// <param name="coinCarrier"></param>
		/// <returns></returns>
		[Route(ApiControllerRoutes.CoinJarController.AddCoinSuffix)]
		[HttpPost]
		public IHttpActionResult AddCoin([FromBody] CoinCarrier coinCarrier)
		{
			if (coinCarrier == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			CoinEntity coinEntity = _coinJarMapper.MapToEntity(coinCarrier);

			var result =  _coinJarManager.AddCoin(coinEntity);

			if (!result)
				return BadRequest("Volume Exceeds Max Ounces");

			return Ok();
		}

		/// <summary>
		/// Get Total Amount in Coin Jar
		/// </summary>
		/// <returns></returns>
		[Route(ApiControllerRoutes.CoinJarController.TotalAmountSuffix)]
		[HttpGet]
		public IHttpActionResult GetTotalAmount()
		{
			decimal total = _coinJarManager.GetTotalAmount();

			return Ok(new { TotalAmount = total });
		}

		/// <summary>
		/// Reset The Coin Jar
		/// </summary>
		/// <returns></returns>
    [Route(ApiControllerRoutes.CoinJarController.ResetSuffix)]
		[HttpGet]
		public IHttpActionResult Reset()
		{
			_coinJarManager.Reset();

			return Ok();
		}
	}
}