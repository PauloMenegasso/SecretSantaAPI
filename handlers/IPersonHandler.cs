using System.Collections.Generic;
using System.Threading.Tasks;
using secret_santa.Domain;

namespace secret_santa.handlers
{
    public interface IPersonHandler
    {
        Task<Person> InsertPerson(Person person);
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetSantaFriend(string personName);
    }
}