using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DriverData : IDriverData
    {
        private readonly ISqlDataAccess _db;

        public DriverData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Driver>> GetDrivers() =>
    _db.LoadData<Driver, dynamic>("dbo.spDrivers_GetAll", new { });

        public async Task<Driver?> GetDriver(string id)
        {
            var results = await _db.LoadData<Driver, dynamic>(
                "dbo.spDrivers_Get",
                new { DriverId = id });
            return results.FirstOrDefault();
        }

        public Task InsertDriver(Driver driver) =>
    _db.SaveData("dbo.spDrivers_Insert",
    new { driver.driverId, driver.url, driver.givenName, driver.familyName, driver.dateOfBirth, driver.nationality, driver.permanentNumber, driver.code });

        public Task UpdateDriver(Driver driver) =>
    _db.SaveData("dbo.spDrivers_Update", driver);

        public Task DeleteDriver(string id) =>
    _db.SaveData("dbo.spDrivers_Delete", new { DriverId = id });
    }
}
