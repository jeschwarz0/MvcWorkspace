using MvcWorkspace.Models;

namespace MvcWorkspace.DAL
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// The Youtube Channel repository.
        /// </summary>
        GenericRepository<YoutubeChannel> YoutubeChannel { get; }
        /// <summary>
        /// The Youtube Video repository
        /// </summary>
        GenericRepository<YoutubeVideo> YoutubeVideo { get; }
        /// <summary>
        /// Saves the current transactions.
        /// </summary>
        void Save();
    }
}
