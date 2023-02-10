using Microsoft.AspNetCore.Mvc;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.HighwayToHell.Api.Controllers
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Car { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            foreach (var item in unitOfWork.GetRepo<Order>().GetAll())
            {
                yield return new OrderItem()
                {
                    Name = item.BillingCustomer?.Name,
                    Car = item.Items.FirstOrDefault()?.Color,
                    OrderId = item.Id
                };
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderItem orderItem)
        {
            var newOrder = new Order() { BillingCustomer = new Customer() { Name = orderItem.Name } };
            unitOfWork.OrderRepository.Add(newOrder);   
            unitOfWork.SaveChanges();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
