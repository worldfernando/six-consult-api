using AutoMapper;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Domain.Entities;
using System.Linq;
using SixConsultApi.Service.Interfaces;
using SixConsultApi.Infra.Data.Repository.interfaces;

namespace SixConsultApi.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }
        public Customer Delete(Customer objectInstance)
        {
            return _customerRepository.Delete(objectInstance);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer Post(Customer objectInstance)
        {
            return _customerRepository.Post(objectInstance);
        }

    public IQueryable<Customer> Query(string filter)
    {
      return _customerRepository.Query(filter);
    }

    public Customer Update(Customer objectInstance)
        {
            return _customerRepository.Update(objectInstance);
        }
    }
}
