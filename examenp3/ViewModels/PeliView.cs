using System.Collections.ObjectModel;
using System.Net.Http.Json;
using ExamenP3.Modelos;
using ExamenP3.Servicios;

namespace ExamenP3.ViewModels;

public class PeliView : BDSView
{
    private readonly BDS _BDS;
    private string _consultaBusqueda;
    public string ConsultaBusqueda
    {
        get => _consultaBusqueda;
        set => SetProperty(ref _consultaBusqueda, value);
    }

    public ObservableCollection<Peli> Peliculas { get; } = new();

    public Command BuscarPeliculaCommand { get; }
    public Command LimpiarBusquedaCommand { get; }

    public PeliView(BDS BDS)
    {
        _BDS = BDS;

        BuscarPeliculaCommand = new Command(async () => await BuscarPeliculaAsync());
        LimpiarBusquedaCommand = new Command(() => ConsultaBusqueda = string.Empty);

        CargarPeliculas();
    }

    private async Task BuscarPeliculaAsync()
    {
        if (string.IsNullOrWhiteSpace(ConsultaBusqueda)) return;

        using var cliente = new HttpClient();
        var respuesta = await cliente.GetFromJsonAsync<List<Peli>>($"https://freetestapi.com/api/v1/movies?search={ConsultaBusqueda}");

        if (respuesta != null && respuesta.Any())
        {
            var pelicula = respuesta.First();
            pelicula.EGalindo = "Esteban Galindo";

            await _BDS.AgregarPeliculaAsync(pelicula);
            CargarPeliculas();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Error", "No se encontró ninguna película.", "Aceptar");
        }
    }

    private async void CargarPeliculas()
    {
        Peliculas.Clear();
        var peliculas = await _BDS.ObtenerPeliculasAsync();
        foreach (var pelicula in peliculas)
        {
            Peliculas.Add(pelicula);
        }
    }
}
