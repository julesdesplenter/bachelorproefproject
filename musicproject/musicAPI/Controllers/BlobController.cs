using Azure.Storage.Blobs.Models;
using ECommerce.API.Models;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using musicAPI.Models;
using SMSong.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UPSong.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService blobService;

        public BlobController(IBlobService blobService)
        {
            this.blobService = blobService;
        }


        // GET api/<BlobController>/5
        [Authorize]
        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var result = await blobService.GetBlobAsync(fileName);
            return File(result, fileName.GetContentType(), fileName);
        }

        [Authorize]
        [HttpPost("InsertFile/{UserId}")]
        public async Task InsertFile(IFormFile asset, Guid UserId)
        {
            await blobService.UploadFile(asset);
            IUPSong actor = GetActor(UserId);
            UPSongClass song = new UPSongClass
            {
                SongId = Guid.NewGuid(),
                UserId = UserId,
                Name = asset.FileName,
                filters = new List<Filter>()
            };
            await actor.AddSong(song);
        }

        [Authorize]
        [HttpGet("AllSongs/{UserId}")]
        public async Task<List<UPSongDTO>> GetAllSongs(Guid UserId)
        {
            var result = new List<UPSongDTO>();
            IUPSong actor = GetActor(UserId);
            UPSongClass[] songs = await actor.GetAllSongs(UserId);

            foreach (UPSongClass song in songs)
            {
                var dink = new UPSongDTO
                {
                    UserId = song.UserId,
                    Name = song.Name,

                };
                result.Add(dink);
            }
            return result;
        }




        // DELETE api/<BlobController>/5
        [Authorize]
        [HttpDelete("{UserId}/{name}")]
        public async Task<ObjectResult> Delete(string name,Guid UserId)
        {
            
            IUPSong actor = GetActor(UserId);
            UPSongClass[] songs = await actor.GetAllSongs(UserId);
            UPSongClass result = new UPSongClass();
            foreach (UPSongClass song in songs)
            {
                if (song.Name == name)
                {
                    result = song;
                    await actor.DeleteSong(result);
                    await blobService.DeleteBlobAsync(name);
                    return Ok("deleted");
                }
            }
            return BadRequest("delete failed");
            
        }

        //addfilter
        [Authorize]
        [HttpPost("addFilter/{name}")]
        public async Task<ObjectResult> AddFilter([FromBody] filterDTO request, string name)
        {
            IUPSong actor = GetActor(request.UserId);
            UPSongClass[] songs = await actor.GetAllSongs(request.UserId);
            UPSongClass result = new UPSongClass();
            foreach (UPSongClass song in songs)
            {
                if (song.Name == name)
                {
                    song.filters.Add(new Filter
                    {
                        FilterId = Guid.NewGuid(),
                        Name = request.Name,
                        Level = request.Level
                    });
                    await actor.EditSong(song);
                    return Ok("filter added");
                }
            }
            return BadRequest("failed to add filter");
        }

        //getonesong
        [Authorize]
        [HttpGet("OneSong/{UserId}/{name}")]
        public async Task<ObjectResult> GetOneSong(string name, Guid UserId)
        {

            IUPSong actor = GetActor(UserId);
            UPSongClass[] songs = await actor.GetAllSongs(UserId);
            UPSongClass result = new UPSongClass();
            foreach (UPSongClass song in songs)
            {
                if (song.Name == name)
                {
                    return Ok(song);
                }
            }
            return BadRequest("no song found");
        }


            private IUPSong GetActor(Guid UserId)
        {
            return ActorProxy.Create<IUPSong>(
                new ActorId(UserId),
                new Uri("fabric:/musicproject/UPSongActorService"));
        }
    }
}
