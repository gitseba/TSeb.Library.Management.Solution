using TSeb.Library.Core.Models;

namespace TSeb.Library.Data
{
    /// <summary>
    /// Purpose: 
    /// Created by: TSeb
    /// </summary>
    public interface IBooksRepo
    {
        public IReadOnlyList<TrackItemModel<BookModel>> GetAll();

        public TrackItemModel<BookModel> GetById(int id);

        public void Create(TrackItemModel<BookModel> book);

        public void Update(TrackItemModel<BookModel> book);

        public void Delete(int id);
    }
}

