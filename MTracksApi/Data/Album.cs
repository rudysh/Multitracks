using System;
using System.Collections.Generic;

namespace MTracksApi.Data
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public int albumId { get; set; }
        public int artistId { get; set; }
        public DateTime dateCreation { get; set; }
        public string? title { get; set; }
        public string? imageUrl { get; set; }
        public int year { get; set; }

        public virtual Artist? _Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
