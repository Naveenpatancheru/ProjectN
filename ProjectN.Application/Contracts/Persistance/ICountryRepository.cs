using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Application.Contracts.Persistance
{
    public interface ICountryRepository : IAsyncRepository<Country>
    {
    }
}
