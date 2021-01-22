using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using UPSong.Interfaces;

namespace UPSong
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class UPSong : Actor, IUPSong
    {
        /// <summary>
        /// Initializes a new instance of UPSong
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public UPSong(ActorService actorService, ActorId actorId) 
            : base(actorService, actorId)
        {
        }

        public async Task AddSong(UPSongClass song)
        {
            await StateManager.AddOrUpdateStateAsync(song.SongId.ToString(), song, (Id, oldSong) => oldSong = song);
        }

        public async Task DeleteSong(UPSongClass song)
        {
            IEnumerable<string> songIDs = await StateManager.GetStateNamesAsync();

            foreach (string songID in songIDs)
            {
               
                if (songID == song.SongId.ToString())
                {
                    await StateManager.RemoveStateAsync(songID);

                }
            }
        }

        public async Task EditSong(UPSongClass song)
        {
            await StateManager.AddOrUpdateStateAsync(song.SongId.ToString(), song, (Id, oldSong) => oldSong = song);
        }

        public async Task<UPSongClass[]> GetAllSongs(Guid userId)
        {
            var result = new List<UPSongClass>();
            IEnumerable<string> songIDs = await StateManager.GetStateNamesAsync();
            foreach (string song in songIDs)
            {
                UPSongClass songs = await StateManager.GetStateAsync<UPSongClass>(song);
                if (songs.UserId == userId)
                {
                    result.Add(songs);

                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "UPSong activated.");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see https://aka.ms/servicefabricactorsstateserialization
            return Task.FromResult(true);

        }


    }
}
