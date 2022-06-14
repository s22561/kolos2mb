using Microsoft.EntityFrameworkCore;
using kolos2_mb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2_mb.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicContext _context;
        public MusicService(MusicContext context)
        {
            _context = context;
        }
      
        public IQueryable<Album> GetAlbumInfo(int IdAlbum)
        {
            return _context.Album.Where(e => e.IdAlbum == IdAlbum)
                .Include(e => e.MusicLabel)
                .Include(e => e.Tracks).OrderBy(e => e.Tracks.FirstOrDefault().Duration);
        }

        public IQueryable<Album> GetAlbumById(int IdAlbum)
        {
            return _context.Album.Where(e => e.IdAlbum == IdAlbum); 
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
