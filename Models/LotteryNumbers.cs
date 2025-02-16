using System.ComponentModel.DataAnnotations;

namespace LotteryNumbers.Models
{
    public class LotteryNumbers
    {
        public List<int> MainNums { get; set; }
        public int BonusNum { get; set; }

    }
}
