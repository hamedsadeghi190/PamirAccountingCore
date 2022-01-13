﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models.ViewModels
{
    public class DraftViewModels
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string OtherNumber { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string FatherName { get; set; }
        public string PayPlace { get; set; }
        public string Description { get; set; }
        public string TypeCurrency { get; set; }
        public long DraftAmount { get; set; }
        public long Rate { get; set; }
        public long Rent { get; set; }
        public double? DepositAmount { get; set; }
        public string DepositCurrency { get; set; }
        public string Customer { get; set; }
        public string RunningDate { get; set; }
        public string Date { get; set; }

    }

    public class SummeryDraftViewModels
    {
        public long TotalRent { get; set; }
        public double Total { get; set; }
        public string CurrenyName { get; set; }
    }
}
