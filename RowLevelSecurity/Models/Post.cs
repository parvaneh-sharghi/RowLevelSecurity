using System.ComponentModel.DataAnnotations.Schema;


namespace RowLevelSecurity.Models
{
    public class Post : IUser
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
