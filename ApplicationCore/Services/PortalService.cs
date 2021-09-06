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
        private readonly IPortalRepository _portalRepository;
        public PortalService(IPortalRepository portalRepository)
        {
            _portalRepository = portalRepository;
        }

        public Task<bool> IsPortalLegalAgeRequired(int portalId)
        {
            return _portalRepository.IsLegalAgeRequired(portalId);
        }

        public bool PortalExists(int portalId)
        {
            return _portalRepository.EntityExists(portalId);
        }
    }
}
