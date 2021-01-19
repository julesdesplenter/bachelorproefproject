using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.Model;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Identity
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class Identity : StatefulService, IIdentityService
    {
        private IUserRepo repo;
        public Identity(StatefulServiceContext context)
            : base(context)
        { }

        public async Task<bool> AddUser(User user)
        {
            bool result = await repo.AddUser(user);
            return result;
        }

        public async Task<Dictionary<string,Guid>> ValiDateUser(User user)
        {
            return await repo.ValiDateUser(user);
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
           {
                new ServiceReplicaListener(context => new FabricTransportServiceRemotingListener(context, this))
            };
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            repo = new UserRepo(this.StateManager);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = "bob",
                Email = "bob@email.com",
                Password = "bob",
                Role = "admin"
            };

           
            await repo.AddUser(user);
            
        }
    }
}
