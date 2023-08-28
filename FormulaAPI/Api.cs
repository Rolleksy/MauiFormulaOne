using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormulaAPI
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Drivers", GetDrivers);
            app.MapGet("/Drivers/{id}", GetDriver);
            app.MapPost("/Drivers", InsertDriver);
            app.MapPut("/Drivers", UpdateDriver);
            app.MapDelete("/Drivers", DeleteDriver);

        }
        private static async Task<IResult> GetDrivers(IDriverData data)
        {
            try
            {
                return Results.Ok(await data.GetDrivers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetDriver(IDriverData data, string id)
        {
            try
            {
                var results = await data.GetDriver(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertDriver(IDriverData data, Driver driver)
        {
            try
            {
                await data.InsertDriver(driver);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateDriver(IDriverData data, Driver driver)
        {
            try
            {
                await data.UpdateDriver(driver);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteDriver(string id, IDriverData data)
        {
            try
            {
                await data.DeleteDriver(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
