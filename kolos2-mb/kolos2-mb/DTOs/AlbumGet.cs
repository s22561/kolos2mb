using kolos2_mb.Models;
using System;
using System.Collections.Generic;

namespace kolos_probny_MB.DTOs
{
    public class AlbumGet
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public List<TrackCustom> Tracks { get; set; }
    }

    public class TrackCustom
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }
}
