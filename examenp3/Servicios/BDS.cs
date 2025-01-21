using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenp3.Servicios
{
    public class BDS
    {
        private readonly SQLiteAsyncConnection _baseDeDatos;

        public BDS(string rutaBD)
        {
            _baseDeDatos = new SQLiteAsyncConnection(rutaBD);
            _baseDeDatos.CreateTableAsync<Peli>().Wait();
        }

        public Task<int> AgregarPeliculaAsync(Peli pelicula)
        {
            return _baseDeDatos.InsertAsync(pelicula);
        }

        public Task<List<Peli>> ObtenerPeliculasAsync()
        {
            return _baseDeDatos.Table<Peli>().ToListAsync();
        }

        public Task<int> EliminarTodasLasPeliculasAsync()
        {
            return _baseDeDatos.DeleteAllAsync<Peli>();
        }
    }
}