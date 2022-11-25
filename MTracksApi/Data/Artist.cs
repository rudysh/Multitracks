using System;
using System.Collections.Generic;

namespace MTracksApi.Data
{
    public class Artist
    {

        public int artistID { get; set; }
        public DateTime? dateCreation { get; set; }
        public string? title { get; set; }
        public string? biography { get; set; }
        public string? imageURL { get; set; }
        public string? heroURL { get; set; }
        public virtual ICollection<Album>? Albums { get; set; }
    }
}
