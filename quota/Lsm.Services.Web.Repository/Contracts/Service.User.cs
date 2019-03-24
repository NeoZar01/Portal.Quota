using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Quota.Repositories.Services.Contracts
{
    using Core.Repositories.BusinessInterOps.Models;

    public interface IUserServices
    {
        string SignIn(string userName, string password, out TSAuthenticationToken authenticationToken);

        Task<TSAuthenticationToken> Impersonate(string userName, string password);

        Task<TSAuthenticationToken> SignOut(string userName, string password);
    }
}
