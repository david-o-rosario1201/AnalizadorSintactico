using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorSintactico;

public class miDouble
{
    public string nombre { get; set; }
    public double valor { get; set; }

    public miDouble(string nombre, double valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public miDouble(string nombre)
    {
        this.nombre = nombre;
    }
}
