using System.ComponentModel;

namespace PamirAccounting.Commons.Enums
{
    public class Settings
    {
        public enum ExchangeRate
        {
        }

        public enum Action
        {
            [Description("ضرب")]
            Multiplication = 1,
            [Description("تقسیم")]
            Division = 2,
            [Description("جمع")]
            Sum = 3,
        }

        public enum RoundLimit
        {
            Admin = 1,
            Users = 2,
        }
    }
}