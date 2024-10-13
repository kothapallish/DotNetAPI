using DomainLayer;
using DomainLayer.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly IDocumentStore _documentStore;

        public PersonRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public Person Add(Person person)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(person);  // Save the person object
                session.SaveChanges();  // Commit the transaction to RavenDB
            }
            return person;
        }     
    }

}
