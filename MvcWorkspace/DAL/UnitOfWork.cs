using MvcWorkspace.Models;
using System;

namespace MvcWorkspace.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private MWContext context = new MWContext();
        #region Backing Repositories
        private GenericRepository<YoutubeVideo> _youtubeVideo;
        private GenericRepository<YoutubeChannel> _youtubeChannel;
        #endregion
        #region Repositories
        /// <summary>
        /// The Youtube Video repository
        /// </summary>
        public GenericRepository<YoutubeVideo> YoutubeVideo
        {
            get
            {

                if (this._youtubeVideo == null)
                {
                    this._youtubeVideo = new GenericRepository<YoutubeVideo>(context);
                }
                return _youtubeVideo;
            }
        }
        /// <summary>
        /// The Youtube Channel repository.
        /// </summary>
        public GenericRepository<YoutubeChannel> YoutubeChannel
        {
            get
            {

                if (this._youtubeChannel == null)
                {
                    this._youtubeChannel = new GenericRepository<YoutubeChannel>(context);
                }
                return _youtubeChannel;
            }
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }
        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}