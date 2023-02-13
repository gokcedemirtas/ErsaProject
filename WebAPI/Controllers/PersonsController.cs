using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("get-all")]   
        public IActionResult GetAll()
        {
            var result = _personService.GetAll().ToList();
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int personId)
        {
            var result = _personService.GetById(personId);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Person person)
        {
            var result = _personService.Add(person);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Person person)
        {
            var result = _personService.Delete(person);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Person person)
        {
            var result = _personService.Update(person);
            return Ok(result);
        }
    }
}
