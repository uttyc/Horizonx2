using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string ContentThumbnail { get; set; }
        public string Header { get; set; }

        public string PublishDate { get; set; }
        private string color;
        public string Color
        {
            get
            {
                var colors = new List<string> { "#f9ed69", "#f08a5d", "#b83b5e", "#6a2c70", "#381460", "#b21f66", "#fe346e", "#ffbd69" };
                color = colors[new Random().Next(0, colors.Count - 1)];
                return color;
            }
            set { color = value; }
        }


    }
}
