using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using secret_santa.Domain;
using secret_santa.Infra;
using System.Linq;

namespace secret_santa.handlers
{
    public class PersonHandler : IPersonHandler
    {
        private readonly Random _rdn = new Random();
        private readonly IPersonRepository _repository;
        public PersonHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Person>> GetPeople()
        {
            var people = _repository.GetPeople();
            return people;
        }

        public async Task<Person> InsertPerson(Person person)
        {
            try
            {
                var personId = await _repository.Insert(person);
                person.PersonId = personId;
                return person;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error inserting person, {ex.Message}");
            }
        }

        public async Task<Person> GetSantaFriend(string personName)
        {
            var people = await _repository.GetPeople();

            var person = people.Where(p => p.Name == personName).FirstOrDefault();
            var personPool = people.Where(p => p.Name != personName && !p.IsTaken).ToList();
            var untaken = people.Where(p => !p.IsTaken);

            var selectedPerson = SelectPesron(untaken, personName, person, personPool);

            await _repository.TakePerson(selectedPerson.PersonId);

            var santaFriend = new SantaFriend { SantaId = person.PersonId, FriendId = selectedPerson.PersonId };

            await _repository.Insert(santaFriend);

            return selectedPerson;
        }

        private Person SelectPesron(IEnumerable<Person> untaken, string personName, Person person, IEnumerable<Person> personPool)
        {
            if (untaken.Count() == 2)
            {
                foreach (var untakenPerson in untaken)
                {
                    if (person == untakenPerson)
                    {
                        return untaken.Where(p => p.Name != personName).FirstOrDefault();
                    }
                    else
                    {
                        return personPool.ElementAt(_rdn.Next(0, personPool.Count()));
                    }
                }
            }
            else
            {
                return personPool.ElementAt(_rdn.Next(0, personPool.Count()));
            }
            return null;
        }
    }
}