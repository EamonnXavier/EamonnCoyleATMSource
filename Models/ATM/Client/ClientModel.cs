using System.ComponentModel.DataAnnotations;

namespace EamonnCoyleATM.Models.ATM.Client
{
    public class ClientModel
    {
        [Key]
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string IDNumber { get; set; }
    }
}
