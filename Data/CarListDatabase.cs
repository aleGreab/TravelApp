using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CarTravel.Models;

namespace CarTravel.Data
{
    public class CarListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CarListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            //tabela pt car
            _database.CreateTableAsync<CarList>().Wait();
            //tabela pt travel
            _database.CreateTableAsync<TravelList>().Wait();
            //tabela pt locuri/destinatii
            _database.CreateTableAsync<Place>().Wait();
            //tabela pt lista de locuri
            _database.CreateTableAsync<ListPlace>().Wait();
        }

        //pt car
        public Task<List<CarList>> GetCarListsAsync()
        {
            return _database.Table<CarList>().ToListAsync();
        }
        public Task<CarList> GetCarListAsync(int id)
        {
            return _database.Table<CarList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveCarListAsync(CarList clist)
        {
            if (clist.ID != 0)
            {
                return _database.UpdateAsync(clist);
            }
            else
            {
                return _database.InsertAsync(clist);
            }
        }
        public Task<int> DeleteCarListAsync(CarList clist)
        {
            return _database.DeleteAsync(clist);
        }

        // pt travel
        public Task<List<TravelList>> GetTravelListsAsync()
        {
            return _database.Table<TravelList>().ToListAsync();
        }
        public Task<TravelList> GetTravelListAsync(int id)
        {
            return _database.Table<TravelList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveTravelListAsync(TravelList tlist)
        {
            if (tlist.ID != 0)
            {
                return _database.UpdateAsync(tlist);
            }
            else
            {
                return _database.InsertAsync(tlist);
            }
        }
        public Task<int> DeleteTravelListAsync(TravelList tlist)
        {
            return _database.DeleteAsync(tlist);
        }

        //pt places
        public Task<int> SavePlaceAsync(Place place)
        {
            if (place.ID != 0)
            {
                return _database.UpdateAsync(place);
            }
            else
            {
                return _database.InsertAsync(place);
            }
        }
        public Task<int> DeletePlaceAsync(Place place)
        {
            return _database.DeleteAsync(place);
        }
        public Task<List<Place>> GetPlacesAsync()
        {
            return _database.Table<Place>().ToListAsync();
        }
        public Task<int> SaveListPlaceAsync(ListPlace listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Place>> GetListPlacesAsync(int placelistid)
        {
            return _database.QueryAsync<Place>(
            "select P.ID, P.Name from Place P"
            + " inner join ListPlace LP"
            + " on P.ID = LP.PlaceID where LP.PlaceListID = ?",
            placelistid);
        }
    }
}
