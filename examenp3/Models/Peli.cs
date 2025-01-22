using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenP3.Modelos;

public class Peli
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string ActorPrincipal { get; set; }
    public string Premios { get; set; }
    public string SitioWeb { get; set; }
    public string EGalindo { get; set; }
}
