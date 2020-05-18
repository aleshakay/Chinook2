
using System.Linq;
using Chinook.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepository _repository = new CustomerRepository();

        // GET: api/customers/Brazil
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var customers = _repository.GetCustomersByCountry(country);
            var isEmpty = !customers.Any();
            if (isEmpty)
            {
                return NotFound("No customers found in that country");
            }
            return Ok(customers);


        }

        // GET: api/customers/invoices/Brazil
        [HttpGet("invoices/{country}")]
        public IActionResult GetInvoicesByCountry(string country)
        {
            var invoices = _repository.GetAllInvoicesByCountry(country);
            var isEmpty = !invoices.Any();
            if (isEmpty)
            {
                return NotFound("No invoices found in that country");
            }
            return Ok(invoices);


        }


    }
}