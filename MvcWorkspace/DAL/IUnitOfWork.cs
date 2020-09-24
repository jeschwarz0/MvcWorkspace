using MvcWorkspace.Models;

namespace MvcWorkspace.DAL
{
    /// <summary>
    /// The Unit of Work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The Youtube Channel repository.
        /// </summary>
        IRepository<YoutubeChannel> YoutubeChannel { get; }
        /// <summary>
        /// The Youtube Video repository
        /// </summary>
        IRepository<YoutubeVideo> YoutubeVideo { get; }
        /// <summary>
        /// Saves the current transactions.
        /// </summary>
        void Save();
    }
}
