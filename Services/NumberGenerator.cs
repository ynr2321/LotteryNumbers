using LotteryNumbers.Interfaces;

namespace LotteryNumbers.Services
{
    public class NumberGenerator : INumberGenerator
    {
        public async Task<Models.LotteryNumbers> GetNums()
        {
            // Keeping this helper local to method, but would have as a static class level member if it took long to instantiate
            var random  = new Random();

            // Generate unique 6 random nums where 1 <= num <= 59
            var nums = new List<int>();
            while (nums.Count < 6)
            {

                var potentialNum = random.Next(1, 60);

                if(!nums.Contains(potentialNum))
                    nums.Add(potentialNum);
            }

            // remove the last num and make it the bonus num (no need to randomise index as we haven't sorted yet)
            var bonusNum = nums[^1];
            nums.RemoveAt(nums.Count -1);

            // Sort the first 5 generated in ascending order
            nums.Sort();


            return new Models.LotteryNumbers()
            {
                MainNums = nums,
                BonusNum = bonusNum
            };

        }
    }
}
