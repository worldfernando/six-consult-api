using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixConsultApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SixConsultApi.Dto.Customer;

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
        /// Retorna Recurso pelo Identificador único
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return Ok(_mapper.Map<CustomerDto>(_customerService.GetById(id)));
        }
    }
}
