using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horizonx2.Models
{
    public class EksiEntry
    {
       
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string PublishDate { get; set; }
        public string ContentThumbnail { get; set; }
        public string Header { get; set; }
    }
}
