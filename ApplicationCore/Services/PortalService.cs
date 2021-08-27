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
        public Task<bool> IsPortalLegalAgeRequired(int PortalId)
        {
            throw new NotImplementedException();
        }

        public bool PortalExists(int PortalId)
        {
            throw new NotImplementedException();
        }
    }
}
