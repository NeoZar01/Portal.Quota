using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Globalization;

namespace DoE.Quota.Repositories.Services.BusinessServices
{
    using Contracts;
    using Core.Repositories.Contracts;
    using Core.Repositories.BusinessInterOps;
    using Core.Repositories.BusinessInterOps.Models;

    public sealed class UserServices : IUserServices
    {
        private readonly InterOpSettings TEAMSERVICES_CONFIGURATIONS = null;

        private string payload = string.Empty;

        public UserServices(IServerRepository serverRepository)
        {
             var servers  = serverRepository.GetServerObjects(GlobalConstants.SERVER_TEAMSERVICES);

            if(servers != null)
            {                
                var server = servers.SingleOrDefault();
                try
                { TEAMSERVICES_CONFIGURATIONS = (InterOpSettings)server; }
                catch
                {}
            }
        }

        public Task<TSAuthenticationToken> Impersonate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string SignIn(string userName, string password, out TSAuthenticationToken authentication)
        {
            ServerCollection serverCollection = null;
            authentication = null;
            string signInState = GlobalConstants.FAILED;

            serverCollection = BusinessServicesRequest.Get<TSAuthenticationToken>(TEAMSERVICES_CONFIGURATIONS, payload, new TSAuthenticationToken().GetType());

            if(serverCollection != null)
            {
                if(serverCollection.Current.AuthenticationContext.State.Equals(GlobalConstants.SUCCESSFULL, StringComparison.CurrentCultureIgnoreCase) ) 
                {
                    //[TODO] Login was successful :: 

                    authentication = serverCollection.AuthenticationContext;
                    signInState = serverCollection.Current.AuthenticationContext.State;                                           
                }
            }

            return signInState;
        }

        public Task<TSAuthenticationToken> SignOut(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
