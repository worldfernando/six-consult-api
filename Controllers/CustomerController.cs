using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SixConsultApi.Dto.Customer;
using System.Net;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SixConsultApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerController(ICustomerService customerService, IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._customerService = customerService;
            this._userService = userService;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
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
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Create)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var customer = new Customer(customerDto.FTIN, customerDto.Name, customerDto.TradeName, customerDto.ContactEmail, customerDto.ContactPhone, userCreatedId: tools.GetUserTokenId(), userUpdatedId: tools.GetUserTokenId());
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
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Update)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
                var customer = _customerService.GetById(id);
                if (customer == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Cliente não localizado" });
                    
                customer.FTIN = customerDto.FTIN;
                customer.Name = customerDto.Name;
                customer.TradeName = customerDto.TradeName;
                customer.ContactEmail = customerDto.ContactEmail;
                customer.ContactPhone = customerDto.ContactPhone;
                customer.UserUpdatedId = user.Id;
                customer.UpdatedAt = DateTime.Now;

                _customerService.Update(customer);
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
                var tools = new SixTools(_httpContextAccessor);
                var user = _userService.GetById(tools.GetUserTokenId());
                if (user == null)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não localizado" });
                if (!user.Profile.Delete)
                    return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, message = "Usuário não possui permissão para realizar esta operacao" });
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
