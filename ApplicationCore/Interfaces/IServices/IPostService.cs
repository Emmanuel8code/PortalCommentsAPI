using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IPostService
    {
        bool PostExists(int postId);
        bool PostBelongsToPortal(int postId, int portalId);
    }
}
