using SQLite;
using ExamenP3.Modelos;

namespace ExamenP3.Servicios;

public class BDS
{
    private readonly SQLiteAsyncConnection _BDS;

    public BDS(string rutaBD)
    {
        _BDS = new SQLiteAsyncConnection(rutaBD);
        _BDS.CreateTableAsync<Peli>().Wait();
    }

    public Task<int> AgregarPeliculaAsync(Peli pelicula)
    {
        return _BDS.InsertAsync(pelicula);
    }

    public Task<List<Peli>> ObtenerPeliculasAsync()
    {
        return _BDS.Table<Peli>().ToListAsync();
    }

    public Task<int> EliminarTodasLasPeliculasAsync()
    {
        return _BDS.DeleteAllAsync<Peli>();
    }
}
