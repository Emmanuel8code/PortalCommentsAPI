using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PortalService : IPortalService
    {
        private readonly IGenericRepositoryAsync<Portal> _portalRepository;
        public PortalService(IGenericRepositoryAsync<Portal> portalRepository)
        {
            _portalRepository = portalRepository;
        }

        public Task<bool> IsPortalLegalAgeRequired(int portalId)
        {
            throw new NotImplementedException();
        }

        public bool PortalExists(int portalId)
        {
            return _portalRepository.EntityExists(portalId);
        }
    }
}
