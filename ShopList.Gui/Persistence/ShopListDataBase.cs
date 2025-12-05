using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ShopList.Gui.Persistence.Configuration;
using ShopList.Gui.Models;
namespace ShopList.Gui.Persistence
{
    public class ShopListDataBase
    {
        private SQLiteAsyncConnection? _connection; //ESTABLECE LA CONECCIÓN

        private async Task InitAsync()         //VERIFICA SI EXISTE UNA BASE DE DATOS O LA CREA "ASINCRONO"
        {
            if (_connection != null)
            {
                return;
            }

            _connection = new SQLiteAsyncConnection      //establecer la coneccion
                (
                Constants.DatabasePath,                  //opciones de apertura
                Constants.flags
                );

            await _connection.CreateTableAsync<Item>();
        }

        public async Task<int> SaveItemAsync(Item item)
        {
            await InitAsync();
            return await _connection!.InsertAsync(item);
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync() //recore del principio a fin
        {
            await InitAsync();
            return await _connection.Table<Item>().ToListAsync(); //siempre tiene que ser TolistAsycn para satisfacer al metodo
        }

        public async Task<int> RemoveItemAsync(Item item)
        {

            await InitAsync();
            return await _connection!.DeleteAsync(item);
        }
    }
}
