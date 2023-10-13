using SQLite;

namespace MovieRatingApp.DataAccess.Interfaces
{
    public interface IDBConnection
    {
        Task<SQLiteAsyncConnection> Connect();
    }
}
