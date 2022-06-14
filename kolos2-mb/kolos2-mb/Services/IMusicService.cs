using kolos2_mb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2_mb.Services
{
    public interface IMusicService
    {
        IQueryable<Album> GetAlbumInfo(int IdAlbum);
        IQueryable<Album> GetAlbumById(int IdAlbum);
    }
}
