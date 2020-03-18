using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMd.PasswordDecrypt.App.DataAccess.Entities
{
    [Table("ProdMember")]
    public class Member
    {
        [Key]
        public long MemberId { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string HostReference { get; set; }
        public string Password { get; set; }
        public string PasswordDecrypted { get; set; }
        public string HashedPassword { get; set; }
        public bool? Active { get; set; }
    }
}