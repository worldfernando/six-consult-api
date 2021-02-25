using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SixConsultApi.Dto.Customer;
using System.Net;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService;
            this._mapper = mapper;
        }

        // GET api/<controller>/5
        /// <summary>
        /// Return Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return Ok(_mapper.Map<CustomerDto>(_customerService.GetById(id)));
        }

        // POST api/<controller>
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Post(CustomerDto customerDto)
        {
            try
            {
                var customer = new Customer(customerDto.FTIN, customerDto.Name, customerDto.TradeName, customerDto.ContactEmail, customerDto.ContactPhone);
                _customerService.Post(customer);
                return Ok(_mapper.Map<CustomerDto>(customer));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerDto customerDto)
        {
            try
            {
                var customer = new Customer(customerDto.FTIN, customerDto.Name, customerDto.TradeName, customerDto.ContactEmail, customerDto.ContactPhone);
                _customerService.Post(customer);
                return Ok(_mapper.Map<CustomerDto>(customer));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Delete Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _customerService.GetById(id);
                if (customer == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Cliente não localizado" });
                _customerService.Delete(customer);
                return Ok(_mapper.Map<CustomerDto>(customer));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = HttpStatusCode.PreconditionFailed, message = e.Message });
            }
        }
    }
}
