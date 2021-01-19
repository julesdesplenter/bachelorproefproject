using Identity.Model;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity
{
    class UserRepo : IUserRepo
    {
        private readonly IReliableStateManager stateManager;

        public UserRepo(IReliableStateManager stateManager)
        {
            this.stateManager = stateManager;
        }
        public async Task<bool> AddUser(User user)
        {
            if(await checkIfUserExists(user))
            {
                IReliableDictionary<Guid, User> products = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, User>>("User");

                using (ITransaction tx = stateManager.CreateTransaction())
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    await products.AddOrUpdateAsync(tx, user.Id, user, (id, value) => user);
                    await tx.CommitAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<Dictionary<string,Guid>> ValiDateUser(User user)
        {
            IReliableDictionary<Guid, User> products = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, User>>("User");
            var result = new Dictionary<string,Guid>();

            using (ITransaction tx = stateManager.CreateTransaction())
            {
                Microsoft.ServiceFabric.Data.IAsyncEnumerable<KeyValuePair<Guid, User>> allProducts = await products.CreateEnumerableAsync(tx, EnumerationMode.Unordered);

                using (Microsoft.ServiceFabric.Data.IAsyncEnumerator<KeyValuePair<Guid, User>> enumerator = allProducts.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<Guid, User> current = enumerator.Current;
                        if (user.Username == current.Value.Username && BCrypt.Net.BCrypt.Verify(user.Password,current.Value.Password))
                        {
                            result[current.Value.Role] = current.Value.Id;
                        }

                    }
                }

            }
            return result;
        }

        private async Task<bool> checkIfUserExists(User user)
        {
            IReliableDictionary<Guid, User> products = await stateManager.GetOrAddAsync<IReliableDictionary<Guid, User>>("User");
            using (ITransaction tx = stateManager.CreateTransaction())
            {
                Microsoft.ServiceFabric.Data.IAsyncEnumerable<KeyValuePair<Guid, User>> allProducts = await products.CreateEnumerableAsync(tx, EnumerationMode.Unordered);

                using (Microsoft.ServiceFabric.Data.IAsyncEnumerator<KeyValuePair<Guid, User>> enumerator = allProducts.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<Guid, User> current = enumerator.Current;
                        if (user.Username == current.Value.Username)
                        {
                            return false;
                        }

                    }
                }

            }
            return true;
        }
    }
}
