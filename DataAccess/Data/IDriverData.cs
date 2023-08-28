using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IDriverData
    {
        Task DeleteDriver(string id);
        Task<Driver?> GetDriver(string id);
        Task<IEnumerable<Driver>> GetDrivers();
        Task InsertDriver(Driver driver);
        Task UpdateDriver(Driver driver);
    }
}