using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using secret_santa.Domain;

namespace secret_santa.Infra
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public PersonRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public async Task<int> Insert(Person person)
        {
            return await _connection.InsertAsync<Person>(person);
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _connection.QueryAsync<Person>("Select * from Person");
        }

        public async Task<Person> GetCurrentPerson(string personName)
        {
            return await _connection.QueryFirstAsync<Person>($"Select * from Person where Name = '{personName}'");
        }

        public async Task<IEnumerable<Person>> GetPersonPool(int id)
        {
           return await _connection.QueryAsync<Person>($"Select * from Person where personId <> {id}");            
        }

        public async Task TakePerson(int personId)
        {
            await _connection.QueryAsync($"Update Person set IsTaken = 1 where PersonId = {personId}");
        }

        public async Task<int> Insert(SantaFriend santaFriend)
        {
            return await _connection.InsertAsync<SantaFriend>(santaFriend);
        }
    }
}
