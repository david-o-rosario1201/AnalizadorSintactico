using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorSintactico;

public class Cadena
{
    public string nombre { get; set; }
    public string valor { get; set; }

    public Cadena(string nombre, string valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public Cadena(string nombre)
    {
        this.nombre = nombre;
    }
}
