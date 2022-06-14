using kolos2_mb.DTOs;
using kolos2_mb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2_mb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMusicService _service;

        public AlbumController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet("{IdAlbum}")]
        public async Task<IActionResult> GetAlbumInfo(int IdAlbum)
        {
            if (await _service.GetAlbumById(IdAlbum).FirstOrDefaultAsync() is null)
                return NotFound("Nie znaleziono albumu o tym ID");
            return Ok(
                await _service.GetAlbumInfo(IdAlbum)
                .Select(e =>
                new AlbumGet
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    IdMusicLabel = e.IdMusicLabel,
                    Tracks = e.Tracks.Select(e => new TrackCustom
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).ToList()
                }).ToListAsync()
            );
        }
    }
}
