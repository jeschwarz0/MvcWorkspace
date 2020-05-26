using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public partial class YoutubeVideo
    {
        public int VideoId { get; set; }
        [MaxLength(11)]
        public string Identifier { get; set; }
        public int ChannelId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }

        public YoutubeChannel Channel { get; set; }
    }
}
