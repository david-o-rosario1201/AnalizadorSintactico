using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorSintactico;

public class miChar
{
    public string nombre { get; set; }
    public char valor { get; set; }

    public miChar(string nombre, char valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public miChar(string nombre)
    {
        this.nombre = nombre;
    }
}
