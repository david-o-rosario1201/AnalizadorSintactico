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

while (true)
{
    Console.Write("Ingrese un string: ");
    string valor = Console.ReadLine();

    if (Regex.IsMatch(valor, patronEnteroValConValor) || Regex.IsMatch(valor, patronEnteroVal)
        || Regex.IsMatch(valor, patronEnteroVarConValor) || Regex.IsMatch(valor, patronEnteroVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }

    else if (Regex.IsMatch(valor, patronShortValConValor) || Regex.IsMatch(valor, patronShortVal)
        || Regex.IsMatch(valor, patronShortVarConValor) || Regex.IsMatch(valor, patronShortVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronLongValConValor) || Regex.IsMatch(valor, patronLongVal)
        || Regex.IsMatch(valor, patronLongVarConValor) || Regex.IsMatch(valor, patronLongVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronFloatValConValor) || Regex.IsMatch(valor, patronFloatVal)
        || Regex.IsMatch(valor, patronFloatVarConValor) || Regex.IsMatch(valor, patronFloatVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronDoubleValConValor) || Regex.IsMatch(valor, patronDoubleVal)
        || Regex.IsMatch(valor, patronDoubleVarConValor) || Regex.IsMatch(valor, patronDoubleVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronBooleanValConValor) || Regex.IsMatch(valor, patronBooleanVal)
        || Regex.IsMatch(valor, patronBooleanVarConValor) || Regex.IsMatch(valor, patronBooleanVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronCharValConValor) || Regex.IsMatch(valor, patronCharVal)
        || Regex.IsMatch(valor, patronCharVarConValor) || Regex.IsMatch(valor, patronCharVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else if (Regex.IsMatch(valor, patronStringValConValor) || Regex.IsMatch(valor, patronStringVal)
        || Regex.IsMatch(valor, patronStringVarConValor) || Regex.IsMatch(valor, patronStringVar))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='
        Console.WriteLine("Valor después del signo '=': " + valorDespuesDelIgual);
    }
    else
        Console.WriteLine("Incorrecto");
}
