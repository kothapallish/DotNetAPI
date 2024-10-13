using DomainLayer;
using DotNetCore6WebAPI.Services;
using DotNetCore6WebAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;

namespace DotNetCore6WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonService _personService;
        private readonly IDocumentStore _documentStore;
        public PersonController(PersonService personService, IDocumentStore documentStore)
        {
            _personService = personService;
            _documentStore = documentStore;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            using (var session = _documentStore.OpenAsyncSession())
            {
                // Query RavenDB for all Person documents
                var persons = await session.Query<Person>().ToListAsync();

                return Ok(persons); // Return the list of persons
            }
        }
        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonRequest request)
        {
            try
            {
                var person = _personService.AddPerson(request.Name, request.Address);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
