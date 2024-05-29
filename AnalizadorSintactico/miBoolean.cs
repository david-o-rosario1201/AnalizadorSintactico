using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorSintactico;

public class miBoolean
{
    public string nombre { get; set; }
    public bool valor { get; set; }

    public miBoolean(string nombre, bool valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public miBoolean(string nombre)
    {
        this.nombre = nombre;
    }
}
