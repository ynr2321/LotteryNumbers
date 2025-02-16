using LotteryNumbers.Models;

namespace LotteryNumbers.Interfaces
{
    public interface INumberGenerator
    {
        public Task<Models.LotteryNumbers> GetNums();
    }
}
