namespace EamonnCoyleATM.Models.ATM
{
    public class WithdrawalResponseModel
    {
        public int ClientId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
