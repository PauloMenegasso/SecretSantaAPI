using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace secret_santa.Domain
{
    [System.ComponentModel.DataAnnotations.Schema.Table("dbo.Person")]
    public class Person
    {
        [Computed]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhotoURL { get; set; }
        public bool IsTaken { get; set; }
    }
}