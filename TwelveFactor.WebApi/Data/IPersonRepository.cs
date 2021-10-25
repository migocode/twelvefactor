using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwelveFactor.WebApi.Data.Models;

namespace TwelveFactor.WebApi.Data
{
    public interface IPersonRepository
    {
        Task InsertAsync(Person person);

        Task<List<Person>> SelectAllAsync();
    }
}
