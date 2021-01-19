using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using SMSong.Interfaces;

namespace SMSong
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
    internal class SMSong : Actor, ISMSong
    {
        /// <summary>
        /// Initializes a new instance of SMSong
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public SMSong(ActorService actorService, ActorId actorId) 
            : base(actorService, actorId)
        {
        }

        public async Task AddSong(Interfaces.SMSongClass song)
        {
            await StateManager.AddOrUpdateStateAsync(song.Id.ToString(),song,(Id,oldSong) => oldSong = song);
        }

        public async Task DeleteSong(Interfaces.SMSongClass song)
        {
            IEnumerable<string> songIDs = await StateManager.GetStateNamesAsync();

            foreach (string songID in songIDs)
            {
                SMSongClass songs = await StateManager.GetStateAsync<SMSongClass>(songID);
                if (songs.Name == song.Name)
                {
                    StateManager.RemoveStateAsync(songID);

                }
            }
        }

        public async Task EditSong(Interfaces.SMSongClass song)
        {
            await StateManager.AddOrUpdateStateAsync(song.Id.ToString(), song, (Id, oldSong) => oldSong = song);
        }

        public async Task<Interfaces.SMSongClass[]> GetSongs(Guid userId)
        {
            var result = new List<SMSongClass>();
            IEnumerable<string> songIDs = await StateManager.GetStateNamesAsync();
            foreach (string song in songIDs)
            {
                SMSongClass songs = await StateManager.GetStateAsync<SMSongClass>(song);
               if(songs.UserId == userId)
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
            ActorEventSource.Current.ActorMessage(this, "SMSong activated.");


            return Task.FromResult(true);
        }

     
    }
}
