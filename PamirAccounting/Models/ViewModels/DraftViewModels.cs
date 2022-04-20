using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models.ViewModels
{
    public class DraftViewModels
    {
        public int Index { get; set; }
        public int Type { get; set; }
        public long Id { get; set; }
        public int DocumentID { get; set; }
        public int Radif { get; set; }
        public long Number { get; set; }
        public string OtherNumber { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string FatherName { get; set; }
        public string PayPlace { get; set; }
        public string Description { get; set; }
        public string TypeCurrency { get; set; }
        public string Status { get; set; }
        public long DraftAmount { get; set; }
        public double Rate { get; set; }
        public double Rent { get; set; }
        public double? DepositAmount { get; set; }
        public double RemainAmount { get; set; }
        public string DepositCurrency { get; set; }
        public string Customer { get; set; }
        public int? CustomerId { get; set; }
        public string RunningDate { get; set; }
        public string Date { get; set; }
        public int? ConvertedCurrencyId { get; set; }
        public int TypeCurrencyId { get; set; }
        public string ConvertedCurrency { get; set; }
        public double? ConvertedRate { get; set; }
        public long? ConvertedAmount { get; set; }
        public string ConvertedDate { get; set; }
        public string ExtraDescription { get; set; }


    }

    public class SummeryDraftViewModels
    {
        public double TotalRent { get; set; }
        public double Total { get; set; }
        public string CurrenyName { get; set; }
    }

    public class SummeryDraftStatusViewModels
    {
   
        public int CurrenyId { get; set; }
        public string CurrenyName { get; set; }
        public string Status { get; set; }
        public double TotalDiposit { get; set; }
        public double TotalWithdraw { get; set; }
        public double RemainAmount { get; set; }
    }
}
