using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using musicAPI.Models;
using SMSong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSongController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task PostAsync([FromBody] SongDTO request)
        {
            ISMSong actor = GetActor(request.UserId);

            SMSongClass song = new SMSongClass
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Length = request.Length,
                UserId = request.UserId,
                Instruments = new List<Instrument>()
            };

            await actor.AddSong(song);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IEnumerable<SongDTO>> GetAsync(Guid userId)
        {
            var result = new List<SongDTO>();
            ISMSong actor = GetActor(userId);
            SMSongClass[] songs = await actor.GetSongs(userId);

            foreach (SMSongClass song in songs)
            {
                var dink = new SongDTO
                {
                    UserId = song.UserId,
                    Length = song.Length,
                    Name = song.Name,

                };
                result.Add(dink);
            }
            return result;
        }

        [Authorize]
        [HttpDelete("{userId}/{songName}")]
        public async Task<ObjectResult> DeleteSong(Guid userId, string songName)
        {
            ISMSong actor = GetActor(userId);
            SMSongClass[] songs = await actor.GetSongs(userId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    await actor.DeleteSong(song);
                    return Ok("deleted");
                }
            }
            return BadRequest("failed to delete");
        }

        [Authorize]
        [HttpGet("onesong/{userId}/{songName}")]
        public async Task<ObjectResult> GetOneSong(Guid userId, string songName)
        {
            ISMSong actor = GetActor(userId);
            SMSongClass[] songs = await actor.GetSongs(userId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    result = song;
                }
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{songName}")]
        public async Task PutAsync([FromBody] SongDTO request, string songName)
        {
            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    result = song;
                }
            }
            result.Name = request.Name;
            result.Length = request.Length;
            await actor.EditSong(result);
        }

        [Authorize]
        [HttpPost("AddInstrument/{songName}")]
        public async Task<ObjectResult> AddInstrument([FromBody] instrumentDTO request,string songName)
        {
            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    song.Instruments.Add(new Instrument
                    {
                        Name = request.Name,
                        InstrumentId = Guid.NewGuid(),
                        Positions = new List<Position>()
                    });
                    result = song;
                }
            }
            await actor.EditSong(result);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddPosition/{songName}/{instrumentId}")]
        public async Task<ObjectResult> AddPosition([FromBody] positionDTO request, string songName, Guid instrumentId)
        {

            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    foreach(Instrument instrument in song.Instruments)
                    {
                        if(instrument.InstrumentId == instrumentId)
                        {
                            if(!checkIfalreadyContains(instrument.Positions, request.Place))
                            {
                                instrument.Positions.Add(new Position
                                {
                                    PositionID = Guid.NewGuid(),
                                    Length = request.Length,
                                    Place = request.Place,
                                    Tones = new List<Tone>()
                                });
                                await actor.EditSong(song);
                                return Ok("updated position");
                            }
                            return Ok("postion already existed");
                        }
                    }
                }
            }
            return BadRequest("position added failed");
        }

        [Authorize]
        [HttpPost("ChangePosition/{songName}/{instrumentId}")]
        public async Task<ObjectResult> ChangePosition([FromBody] positionDTO request, string songName, Guid instrumentId)
        {

            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    foreach (Instrument instrument in song.Instruments)
                    {
                        if (instrument.InstrumentId == instrumentId)
                        {
                            foreach(Position position in instrument.Positions)
                            {
                                if(position.Place == request.Place)
                                {
                                    position.Length = request.Length;
                                    await actor.EditSong(song);
                                    return Ok("length updated");
                                }
                                
                            }
                            
                        }
                    }
                }
            }
            return BadRequest("position added failed");
        }

        [Authorize]
        [HttpPost("AddTone/{songName}/{instrumentId}/{place}")]
        public async Task<ObjectResult> AddTone([FromBody] ToneDTO request, string songName, Guid instrumentId, int place)
        {

            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    foreach (Instrument instrument in song.Instruments)
                    {
                        if (instrument.InstrumentId == instrumentId)
                        {
                           foreach(Position position in instrument.Positions)
                            {
                                if(position.Place == place)
                                {
                                    position.Tones.Add(new Tone
                                    {
                                        ToneId = Guid.NewGuid(),
                                        Pitch = request.Pitch
                                    });
                                    await actor.EditSong(song);
                                    return Ok("updated tone");
                                }
                            }
                        }
                    }
                }
            }
            return BadRequest("tone added failed");
        }

        [Authorize]
        [HttpPost("RemoveTone/{songName}/{instrumentId}/{place}")]
        public async Task<ObjectResult> RemoveTone([FromBody] ToneDTO request, string songName, Guid instrumentId, int place)
        {

            ISMSong actor = GetActor(request.UserId);
            SMSongClass[] songs = await actor.GetSongs(request.UserId);
            SMSongClass result = new SMSongClass();
            foreach (SMSongClass song in songs)
            {
                if (song.Name == songName)
                {
                    foreach (Instrument instrument in song.Instruments)
                    {
                        if (instrument.InstrumentId == instrumentId)
                        {
                            foreach (Position position in instrument.Positions)
                            {
                                if (position.Place == place)
                                {
                                    Tone tone = searchtone(position.Tones, request.Pitch);
                                    position.Tones.Remove(tone);
                                    await actor.EditSong(song);
                                    return Ok("removed tone");
                                }
                            }
                        }
                    }
                }
            }
            return BadRequest("tone removed failed");
        }

        private ISMSong GetActor(Guid UserId)
        {
            return ActorProxy.Create<ISMSong>(
                new ActorId(UserId),
                new Uri("fabric:/musicproject/SMSongActorService"));
        }

        private bool checkIfalreadyContains(List<Position> lst, int place)
        {
            foreach(Position p in lst)
            {
                if(p.Place == place)
                {
                    return true;
                }
            }
            return false;
        }

        private Tone searchtone(List<Tone> lst, string tone)
        {
            foreach(Tone t in lst)
            {
                if(t.Pitch == tone)
                {
                    return t;
                }
            };
            return new Tone();
        }
    }
}
