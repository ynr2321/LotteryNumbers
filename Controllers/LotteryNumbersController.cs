using System.Security.Cryptography.Xml;
using LotteryNumbers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotteryNumbers.Controllers
{
    public class LotteryNumbersController : Controller
    {
        /// <summary>
        /// Service to randomly generate and return LotteryNumbers models
        /// </summary>
        private readonly INumberGenerator _numberGenerator;

        public LotteryNumbersController(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public async Task<IActionResult> Index()
        {
            Models.LotteryNumbers nums = await _numberGenerator.GetNums();

            return View(nums);
        }
    }
}
