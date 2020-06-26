using AutoMapper;
using PhoneBook.Api.Extentions.PagedResult;
using PhoneBook.Api.Models;
using PhoneBook.Api.Resources;
using PhoneBook.Core.Entities;
using PhoneBook.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly IRepository<Phone> _repository;
        public PhoneRepository(IRepository<Phone> repository)
        {
            _repository = repository;
        }

        public Task Create(Phone entity, bool autoSave = true)
        {
            _repository.AddAsync(entity);

            if (autoSave)
                _repository.SaveAsync();

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            _repository.Delete(id);

            _repository.SaveAsync();
            return Task.CompletedTask;
        }

        public IQueryable<Phone> GetAll()
        {
            return _repository.FindAll();
        }

        public Task<Phone> GetById(int id)
        {
            return _repository.GetFirstAsync(id);
        }

        public IEnumerable<Phone> SelectByParam(PhoneResourceParametr phoneResource)
        {
            var query = _repository.FindAll();

            if (!string.IsNullOrWhiteSpace(phoneResource.SearchKey))
            {
                query = query.Where(w => w.PhoneNumber.Contains(phoneResource.SearchKey) ||
                                              w.UserName.Contains(phoneResource.SearchKey));
            }

            return query.AsEnumerable();
        }

        public Task Update(Phone entity, bool autoSave = true)
        {
            _repository.Update(entity);

            if (autoSave)
                _repository.SaveAsync();

            return Task.CompletedTask;
        }
    }
}
