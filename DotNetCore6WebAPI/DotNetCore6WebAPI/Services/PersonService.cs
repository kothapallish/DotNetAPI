using DomainLayer;
using DomainLayer.Interfaces;

namespace DotNetCore6WebAPI.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person AddPerson(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");

            var person = new Person(name, address);
            return _repository.Add(person);
        }
    }

}
