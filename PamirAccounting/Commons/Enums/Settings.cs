﻿using System.ComponentModel;

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

        public enum DepostType
        {
            [Description("نامعلوم")]
            Unkown = 1,
            [Description("معلوم")]
            known = 2,

        }

        public enum TransaActionType
        {
            [Description("حساب جدید")]
            NewAccount = 1,
            [Description("واریز و برداشت نقدی")]
            PayAndReciveCash = 2,
            [Description("واریز و برداشت بانکی")]
            PayAndReciveBank = 3,
            [Description("انتقال حساب")]
            Transfer = 4
        }
    }
}