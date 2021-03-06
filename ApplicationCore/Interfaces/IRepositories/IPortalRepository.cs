using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPortalRepository : IGenericRepositoryAsync<Portal>
    {
        Task<bool> IsLegalAgeRequired(int portalId);
    }
}
