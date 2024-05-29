using AnalizadorSintactico;
using System;
using System.Text.RegularExpressions;

Console.WriteLine("Hola mundo");

//Palabras reservadas
string[] palabrasReversvadas = { 
    "val", "var", "fun", "Int", "Short", "Long", "Float", "Double", "Boolean", "Char", "String", "main" 
};


//Enteros
string patronEnteroValConValor = @"^val _?[A-Za-z0-9]*: Int = [0-9]+$";
string patronEnteroVal = @"^val _?[A-Za-z0-9]*: Int$";

string patronEnteroVarConValor = @"^var _?[A-Za-z0-9]*: Int = [0-9]+$";
string patronEnteroVar = @"^var _?[A-Za-z0-9]*: Int$";

//Short
string patronShortValConValor = @"^val _?[A-Za-z0-9]*: Short = [0-9]+$";
string patronShortVal = @"^val _?[A-Za-z0-9]*: Short$";

string patronShortVarConValor = @"^var _?[A-Za-z0-9]*: Short = [0-9]+$";
string patronShortVar = @"^var _?[A-Za-z0-9]*: Short$";

//Long
string patronLongValConValor = @"^val _?[A-Za-z0-9]*: Long = [0-9]+$";
string patronLongVal = @"^val _?[A-Za-z0-9]*: Long$";

string patronLongVarConValor = @"^var _?[A-Za-z0-9]*: Long = [0-9]+$";
string patronLongVar = @"^var _?[A-Za-z0-9]*: Long$";

//Float
string patronFloatValConValor = @"^val _?[A-Za-z0-9]*: Float = [0-9]+$";
string patronFloatVal = @"^val _?[A-Za-z0-9]*: Float$";

string patronFloatVarConValor = @"^var _?[A-Za-z0-9]*: Float = [0-9]+$";
string patronFloatVar = @"^var _?[A-Za-z0-9]*: Float$";

//Double
string patronDoubleValConValor = @"^val _?[A-Za-z0-9]*: Double = [0-9]+$";
string patronDoubleVal = @"^val _?[A-Za-z0-9]*: Double$";

string patronDoubleVarConValor = @"^var _?[A-Za-z0-9]*: Double = [0-9]+$";
string patronDoubleVar = @"^var _?[A-Za-z0-9]*: Double$";

//Boolean
string patronBooleanValConValor = @"^val _?[A-Za-z0-9]*: Boolean = [true false]+$";///debo arreglar que no se escriba true true
string patronBooleanVal = @"^val _?[A-Za-z0-9]*: Boolean$";

string patronBooleanVarConValor = @"^var _?[A-Za-z0-9]*: Boolean = [true false]+$";
string patronBooleanVar = @"^var _?[A-Za-z0-9]*: Boolean$";

//Char
string patronCharValConValor = @"^val _?[A-Za-z0-9]*: Char = '\w'$";///debo arreglar que no se escriba true true
string patronCharVal = @"^val _?[A-Za-z0-9]*: Char$";

string patronCharVarConValor = @"^var _?[A-Za-z0-9]*: Char = '\w'$";
string patronCharVar = @"^var _?[A-Za-z0-9]*: Char$";

//String
string patronStringValConValor = @"^val _?[A-Za-z0-9]*: String = ""[^""]*""$";
string patronStringVal = @"^val _?[A-Za-z0-9]*: String$";

string patronStringVarConValor = @"^var _?[A-Za-z0-9]*: String = ""[^""]*""$";
string patronStringVar = @"^var _?[A-Za-z0-9]*: String$";


//Clases
Entero entero;
Short mishort;
Long milong;
Float mifloat;
miDouble midouble;
miBoolean boolean;
miChar michar;
Cadena cadena;

//Lista
List<Entero> enteroList = new List<Entero>();


while (true)
{
    Console.Write("Ingrese un string: ");
    string valor = Console.ReadLine();

    //Entero
    if (Regex.IsMatch(valor, patronEnteroValConValor) || Regex.IsMatch(valor, patronEnteroVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        entero = new Entero(nombre, int.Parse(valorDespuesDelIgual));
        enteroList.Add(entero);

        Console.WriteLine("Nombre de la variable: " + entero.nombre);
        Console.WriteLine("Valor: " + entero.valor);
    }
    //Entero
    else if (Regex.IsMatch(valor, patronEnteroVal) || Regex.IsMatch(valor, patronEnteroVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        entero = new Entero(nombre);
        enteroList.Add(entero);

        Console.WriteLine("Nombre de la variable: " + entero.nombre);
        //Console.WriteLine("Valor: " + entero.valor);

        Console.WriteLine("Imprimiendo el nombre de este lado: " + nombre);
        Console.WriteLine("Probando la lista: ");

        ///Aqui hay algo raro, no se porque con " " me da null reference...
        var num1 = enteroList.FirstOrDefault(e => e.nombre.Equals("num1"));
        //var num2 = enteroList.FirstOrDefault(e => e.nombre == "num2");


        Console.WriteLine("Variable1: " + num1?.nombre);
        //Console.WriteLine("Variable2: " + num2.nombre);
    }
    //Short
    else if (Regex.IsMatch(valor, patronShortValConValor) ||  Regex.IsMatch(valor, patronShortVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        mishort = new Short(nombre, short.Parse(valorDespuesDelIgual));

        Console.WriteLine("Nombre de la variable: " + mishort.nombre);
        Console.WriteLine("Valor: " + mishort.valor);
    }
    //Short
    else if (Regex.IsMatch(valor, patronShortVal) || Regex.IsMatch(valor, patronShortVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        mishort = new Short(nombre);

        Console.WriteLine("Nombre de la variable: " + mishort.nombre);
        Console.WriteLine("Valor: " + mishort.valor);
    }
    //Long
    else if (Regex.IsMatch(valor, patronLongValConValor) || Regex.IsMatch(valor, patronLongVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        milong = new Long(nombre, long.Parse(valorDespuesDelIgual));

        Console.WriteLine("Nombre de la variable: " + milong.nombre);
        Console.WriteLine("Valor: " + milong.valor);
    }
    //Long
    else if (Regex.IsMatch(valor, patronLongVal) || Regex.IsMatch(valor, patronLongVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        milong = new Long(nombre);

        Console.WriteLine("Nombre de la variable: " + milong.nombre);
        Console.WriteLine("Valor: " + milong.valor);
    }
    //Float
    else if (Regex.IsMatch(valor, patronFloatValConValor) || Regex.IsMatch(valor, patronFloatVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        mifloat = new Float(nombre, float.Parse(valorDespuesDelIgual));

        Console.WriteLine("Nombre de la variable: " + mifloat.nombre);
        Console.WriteLine("Valor: " + mifloat.valor);
    }
    //Float
    else if (Regex.IsMatch(valor, patronFloatVal) || Regex.IsMatch(valor, patronFloatVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        mifloat = new Float(nombre);

        Console.WriteLine("Nombre de la variable: " + mifloat.nombre);
        Console.WriteLine("Valor: " + mifloat.valor);
    }
    //Double
    else if (Regex.IsMatch(valor, patronDoubleValConValor) || Regex.IsMatch(valor, patronDoubleVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        midouble = new miDouble(nombre, double.Parse(valorDespuesDelIgual));

        Console.WriteLine("Nombre de la variable: " + midouble.nombre);
        Console.WriteLine("Valor: " + midouble.valor);
    }
    //Double
    else if (Regex.IsMatch(valor, patronDoubleVal) || Regex.IsMatch(valor, patronDoubleVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        midouble = new miDouble(nombre);

        Console.WriteLine("Nombre de la variable: " + midouble.nombre);
        Console.WriteLine("Valor: " + midouble.valor);
    }
    //Boolean
    else if (Regex.IsMatch(valor, patronBooleanValConValor) || Regex.IsMatch(valor, patronBooleanVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        boolean = new miBoolean(nombre, bool.Parse(valorDespuesDelIgual));

        Console.WriteLine("Nombre de la variable: " + boolean.nombre);
        Console.WriteLine("Valor: " + boolean.valor);
    }
    //Boolean
    else if (Regex.IsMatch(valor, patronBooleanVal) || Regex.IsMatch(valor, patronBooleanVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        boolean = new miBoolean(nombre);

        Console.WriteLine("Nombre de la variable: " + boolean.nombre);
        Console.WriteLine("Valor: " + boolean.valor);
    }
    //Char
    else if (Regex.IsMatch(valor, patronCharValConValor) || Regex.IsMatch(valor, patronCharVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        // Encuentra el índice del signo '='
        int indiceIgual = valor.IndexOf('=');

        // Encuentra el índice de las comillas simples que rodean el carácter
        int inicioChar = valor.IndexOf('\'', indiceIgual);
        int finChar = valor.IndexOf('\'', inicioChar + 1);

        // Extrae el carácter entre las comillas simples
        char charValor = valor.Substring(inicioChar + 1, finChar - inicioChar - 1)[0];

        michar = new miChar(nombre, charValor);

        Console.WriteLine("Nombre de la variable en miChar: " + michar.nombre);
        Console.WriteLine("Valor: " + michar.valor);
    }
    //Char
    else if (Regex.IsMatch(valor, patronCharVal) )
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        michar = new miChar(nombre);

        Console.WriteLine("Nombre de la variable: " + michar.nombre);
        Console.WriteLine("Valor: " + michar.valor);
    }
    //String
    else if (Regex.IsMatch(valor, patronStringValConValor) || Regex.IsMatch(valor, patronStringVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        // Encuentra el índice del signo '='
        int indiceIgual = valor.IndexOf('=');

        // Obtén la parte de la cadena después del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1).Trim();

        // Elimina las comillas dobles alrededor del valor
        valorDespuesDelIgual = valorDespuesDelIgual.Trim('"', ' ');

        // Crea una instancia de la clase Cadena
        cadena = new Cadena(nombre, valorDespuesDelIgual);

        // Imprime los resultados
        Console.WriteLine("Nombre de la variable: " + cadena.nombre);
        Console.WriteLine("Valor: " + cadena.valor);
    }
    //String
    else if (Regex.IsMatch(valor, patronStringVal) || Regex.IsMatch(valor, patronStringVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        cadena = new Cadena(nombre);

        Console.WriteLine("Nombre de la variable: " + cadena.nombre);
        Console.WriteLine("Valor: " + cadena.valor);
    }
    else
        Console.WriteLine("Syntaxis incorrecta");

    Console.WriteLine();
}
