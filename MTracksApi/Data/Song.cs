﻿using System;
using System.Collections.Generic;

namespace MTracksApi.Data
{
    public class Song
    {
        public int songId { get; set; }
        public int artistID { get; set; }
        public int albumID { get; set; }
        public DateTime dateCreation { get; set; }
        public string? title { get; set; }
        public decimal bpm { get; set; }
        public string? timeSignature { get; set; }
        public bool multitracks { get; set; }
        public bool customMix { get; set; }
        public bool chart { get; set; }
        public bool rehearsalMix { get; set; }
        public bool patches { get; set; }
        public bool songSpecificPatches { get; set; }
        public bool proPresenter { get; set; }

        public virtual Album? _Album { get; set; }
        public virtual Artist? _Artist { get; set; }
    }
}
