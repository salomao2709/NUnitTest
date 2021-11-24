using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }
    public class VideoReader : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            return new List<Video> { new Video { Id = 10 } };
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();
                return videos;
            }
        }
    }
}
