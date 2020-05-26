using System.Collections.Generic;

namespace MvcWorkspace.Models
{
    public partial class YoutubeChannel
    {
        public YoutubeChannel()
        {
            YoutubeVideo = new HashSet<YoutubeVideo>();
        }

        public int ChannelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ChannelIdentifier { get; set; }

        public ICollection<YoutubeVideo> YoutubeVideo { get; set; }
    }
}
