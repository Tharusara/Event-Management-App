using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public PaymentController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var payments = await _repo.GetPayments(userParams);
            var paymentsToReturn = _mapper.Map<IEnumerable<PaymentToReturnDto>>(payments);
            Response.AddPagination(payments.CurrentPage, payments.PageSize, payments.TotalCount, payments.TotalPages);
            return Ok(paymentsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var payment = await _repo.GetPayment(Id);
            var paymentToReturn = _mapper.Map<PaymentToReturnDto>(payment);
            return Ok(paymentToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment paymentForCreation)
        {
            if (paymentForCreation == null)
            {
                return BadRequest("Payment data is null");
            }
            // paymentForCreation.EventId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); need to think a way set the id
            _repo.Add(paymentForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Payment Successfully Added", paymentForCreation);
            }
            return BadRequest("Adding the Payment Failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaymentToUpdateDto paymentForUpdate)
        {
            if (paymentForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            paymentForUpdate.Id = id;
            var paymentFromRepo = await _repo.GetPayment(id);
            if (paymentFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(paymentForUpdate, paymentFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Payment{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var paymentToDelete = await _repo.GetPayment(id);
            if (paymentToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(paymentToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Payment is removed successfully." });
        }
    }
}
