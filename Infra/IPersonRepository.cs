using System.Collections.Generic;
using System.Threading.Tasks;
using secret_santa.Domain;

namespace secret_santa.Infra
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<int> Insert(Person person);
        Task<int> Insert(SantaFriend santaFriend);
        Task<Person> GetCurrentPerson(string personName);
        Task<IEnumerable<Person>> GetPersonPool(int id);
        Task TakePerson(int personId);
    }
}