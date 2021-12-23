using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace secret_santa.Domain
{
    [System.ComponentModel.DataAnnotations.Schema.Table("dbo.SantaFriend")]
    public class SantaFriend
    {
        [Computed]
        public int SantaFriendId { get; set; }
        public int SantaId { get; set; }
        public int FriendId { get; set; }  
    }
}