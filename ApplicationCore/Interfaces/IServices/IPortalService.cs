using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IPortalService
    {
        Task<bool> IsPortalLegalAgeRequired(int portalId);
        bool PortalExists(int portalId);
    }
}
