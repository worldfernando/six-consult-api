using AutoMapper;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T>
    {
        protected ContextDB _context;
        private IMapper _mapper;

        public BaseRepository(ContextDB context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        
        virtual public T Delete(T objectInstance)
        {
            BeforeDelete(objectInstance);
            _context.Remove(objectInstance);
            _context.SaveChanges();
            AfterDelete(objectInstance);
            return objectInstance;
        }
        virtual public void BeforeDelete(T objectInstance)
        {
        }
        virtual public void AfterDelete(T objectInstance)
        {
        }
        virtual public void BeforePost(T objectInstance)
        {
        }
        virtual public T Post(T objectInstance)
        {
            BeforePost(objectInstance);
            _context.Add(objectInstance);
            _context.SaveChanges();
            AfterPost(objectInstance);
            return objectInstance;
        }
        virtual public void AfterPost(T objectInstance)
        {
        }
        virtual public void BeforeUpdate(T objectInstance)
        {
        }
        virtual public T Update(T objectInstance)
        {
            BeforePost(objectInstance);
            _context.Add(objectInstance);
            _context.Entry(objectInstance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            AfterDelete(objectInstance);
            return objectInstance;
        }
        virtual public void AfterUpdate(T objectInstance)
        {
        }
        virtual public IQueryable<T> Query(string filter)
        {
            throw new NotImplementedException();
        }

        virtual public T GetById(long id)
        {
            throw new NotImplementedException();
        }
  }
}
