namespace BookStore.Dtos.CashBoxDtos
{
    public class UpdateCashBoxDto
    {
        public int CashBoxId { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
    }
}
