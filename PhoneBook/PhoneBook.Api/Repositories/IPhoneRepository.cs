using PhoneBook.Api.Resources;
using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Repositories
{
    public interface IPhoneRepository
    {
        IQueryable<Phone> GetAll();

        Task Create(Phone entity, bool autoSave = true);
        Task Update(Phone entity, bool autoSave = true);
        Task Delete(int id);
        Task<Phone> GetById(int id);
        IEnumerable<Phone> SelectByParam(PhoneResourceParametr phoneResource);
    }
}
