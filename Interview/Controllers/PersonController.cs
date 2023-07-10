using Interview.Data;
using Interview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public readonly TaskManagerContext _context;
        public PersonController(TaskManagerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return _context.People.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        [HttpPost]
        public ActionResult<Person> AddPerson(string fName, string lName ,string nCode, long phoneNumber , string email )
        {
            Person person = new Person
            {
                InsDate= DateTime.Now,
                FirstName = fName,
                LastName = lName,
                NationalCode = nCode,
                PhoneNumber = phoneNumber,
                Email = email
            };
            _context.People.Add(person);
            _context.SaveChanges();
            return person;
        }
        [HttpDelete]
        public ActionResult DeletePerson(int id)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
                _context.People.Remove(person);
            return Ok("Person Removed");
        }
        [HttpPut]
        public ActionResult<Person> UpdatePerson(int id , string fName , string lName, string nCode, long phoneNumber, string email)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = fName;
            person.LastName = lName;
            person.NationalCode = nCode;
            person.PhoneNumber = phoneNumber;
            person.Email = email;


            _context.SaveChanges();
            return person;
        }

    }
}
