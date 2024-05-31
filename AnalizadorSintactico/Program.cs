using AnalizadorSintactico;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
string patronCharValConValor = @"^val _?[A-Za-z0-9]*: Char = '\w'$";
string patronCharVal = @"^val _?[A-Za-z0-9]*: Char$";

string patronCharVarConValor = @"^var _?[A-Za-z0-9]*: Char = '\w'$";
string patronCharVar = @"^var _?[A-Za-z0-9]*: Char$";

//String
string patronStringValConValor = @"^val _?[A-Za-z0-9]*: String = ""[^""]*""$";
string patronStringVal = @"^val _?[A-Za-z0-9]*: String$";

string patronStringVarConValor = @"^var _?[A-Za-z0-9]*: String = ""[^""]*""$";
string patronStringVar = @"^var _?[A-Za-z0-9]*: String$";


///Patrones para imprimir
string patronPrint = @"^print\(""[^""]*""\)$";
string patronPrintConVariable = @"^print\([A-Za-z0-9]+\)$";

string patronPrintln = @"^println\(""[^""]*""\)$";
string patronPrintlnConVariable = @"^println\([A-Za-z0-9]+\)$";


///patron para igualar
string patronAsignacion = @"^_?[A-Za-z0-9]* = _?[A-Za-z0-9]*";


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
List<Short> shortList = new List<Short>();
List<Long> longList = new List<Long>();
List<Float> floatList = new List<Float>();
List<miDouble> doubleList = new List<miDouble>();
List<miBoolean> booleanList = new List<miBoolean>();
List<miChar> charList = new List<miChar>();
List<Cadena> cadenaList = new List<Cadena>();

//Dicioanrio de variables
Dictionary<string, bool> variables = new Dictionary<string, bool>();

//Error de variable no creada
string variableNoEncontrada = "";

while (true)
{
    Console.Write("Ingrese un string: ");
    string valor = Console.ReadLine();


    ////////////////////////////////Esta primera condicion creo que se puede eliminar
    //if (Regex.IsMatch(valor, patronStringVal))
    //{
    //    int inicioNombrevarriable = valor.IndexOf(' ') + 1;
    //    int finNombrevarriable = valor.IndexOf(':');
    //    string nombrevarriable = valor.Substring(inicioNombrevarriable, finNombrevarriable - inicioNombrevarriable).Trim();

    //    if (variables.ContainsKey(nombrevarriable))
    //    {
    //        Console.WriteLine($"Ya exiate una variable con este nombre'{nombrevarriable}'\n");
    //        continue;
    //    }
    //    else
    //    {
    //        variables[nombrevarriable] = true;
    //    }
    //}

    if (Regex.IsMatch(valor, patronPrint))
    {
        int indiceComillasInicio = valor.IndexOf('"');
        int indiceComillasFin = valor.LastIndexOf('"');

        string valorEntreComillas = valor.Substring(indiceComillasInicio + 1, indiceComillasFin - indiceComillasInicio - 1);
        Console.Write(valorEntreComillas);
        continue;
    }

    if (Regex.IsMatch(valor, patronPrintln))
    {
        int indiceComillasInicio = valor.IndexOf('"');
        int indiceComillasFin = valor.LastIndexOf('"');

        string valorEntreComillas = valor.Substring(indiceComillasInicio + 1, indiceComillasFin - indiceComillasInicio - 1);
        Console.WriteLine(valorEntreComillas);
        continue;
    }

    if (Regex.IsMatch(valor, patronPrintConVariable))
    {
        int indiceParentesisInicio = valor.IndexOf('(');
        int indiceParentesisFin = valor.IndexOf(')');

        string valorEntreParentesis = valor.Substring(indiceParentesisInicio + 1, indiceParentesisFin - indiceParentesisInicio - 1);

        if (VerificarQueNoSeaUnaPalabraReservada(valorEntreParentesis) == false)
        {
            var result = variables.FirstOrDefault(v => v.Key == valorEntreParentesis);
            if (result.Key != null)
            {
                var enteroResult = enteroList.FirstOrDefault(v => v.nombre == result.Key);
                var shortResult = shortList.FirstOrDefault(v => v.nombre == result.Key);
                var longResult = longList.FirstOrDefault(v => v.nombre == result.Key);
                var floatResult = floatList.FirstOrDefault(v => v.nombre == result.Key);
                var doubleResult = doubleList.FirstOrDefault(v => v.nombre == result.Key);
                var booleanResult = booleanList.FirstOrDefault(v => v.nombre == result.Key);
                var charResult = charList.FirstOrDefault(v => v.nombre == result.Key);
                var cadenaResult = cadenaList.FirstOrDefault(v => v.nombre == result.Key);

                if (enteroResult is not null)
                    Console.Write(enteroResult.valor);

                else if (shortResult is not null)
                    Console.Write(shortResult.valor);

                else if (longResult is not null)
                    Console.Write(longResult.valor);

                else if (floatResult is not null)
                    Console.Write(floatResult.valor);

                else if (doubleResult is not null)
                    Console.Write(doubleResult.valor);

                else if (booleanResult is not null)
                    Console.Write(booleanResult.valor);

                else if (charResult is not null)
                    Console.Write(charResult.valor);

                else if (cadenaResult is not null)
                    Console.Write(cadenaResult.valor);
                else
                    variableNoEncontrada = result.Key;
                continue;
            }
            else
                variableNoEncontrada = valorEntreParentesis;
        }
        else
            continue;
    }

    else if (Regex.IsMatch(valor, patronPrintlnConVariable))
    {
        int indiceParentesisInicio = valor.IndexOf('(');
        int indiceParentesisFin = valor.IndexOf(')');

        string valorEntreParentesis = valor.Substring(indiceParentesisInicio + 1, indiceParentesisFin - indiceParentesisInicio - 1);

        if (VerificarQueNoSeaUnaPalabraReservada(valorEntreParentesis) == false)
        {
            var result = variables.FirstOrDefault(v => v.Key == valorEntreParentesis);
            if (result.Key != null)
            {
                var enteroResult = enteroList.FirstOrDefault(v => v.nombre == result.Key);
                var shortResult = shortList.FirstOrDefault(v => v.nombre == result.Key);
                var longResult = longList.FirstOrDefault(v => v.nombre == result.Key);
                var floatResult = floatList.FirstOrDefault(v => v.nombre == result.Key);
                var doubleResult = doubleList.FirstOrDefault(v => v.nombre == result.Key);
                var booleanResult = booleanList.FirstOrDefault(v => v.nombre == result.Key);
                var charResult = charList.FirstOrDefault(v => v.nombre == result.Key);
                var cadenaResult = cadenaList.FirstOrDefault(v => v.nombre == result.Key);

                if (enteroResult is not null)
                    Console.WriteLine(enteroResult.valor);

                else if (shortResult is not null)
                    Console.WriteLine(shortResult.valor);

                else if (longResult is not null)
                    Console.WriteLine(longResult.valor);

                else if (floatResult is not null)
                    Console.WriteLine(floatResult.valor);

                else if (doubleResult is not null)
                    Console.WriteLine(doubleResult.valor);

                else if (booleanResult is not null)
                    Console.WriteLine(booleanResult.valor);

                else if (charResult is not null)
                    Console.WriteLine(charResult.valor);

                else if (cadenaResult is not null)
                    Console.WriteLine(cadenaResult.valor);

                continue;
            }
            else
                variableNoEncontrada = valorEntreParentesis;
        }
        else
            continue;
    }

    ///igualar
    if (Regex.IsMatch(valor, patronAsignacion))
    {
        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string variable1 = valor.Substring(0, indiceIgual).Trim();
        string variable2 = valor.Substring(indiceIgual + 1).Trim();

        //variable2 = variable2.Replace("'", "").Replace("\"", "");

        var result = variables.FirstOrDefault(v => v.Key == variable1);
        if (result.Key != null)
        {
            var enteroResult = enteroList.FirstOrDefault(v => v.nombre == result.Key);
            var shortResult = shortList.FirstOrDefault(v => v.nombre == result.Key);
            var longResult = longList.FirstOrDefault(v => v.nombre == result.Key);
            var floatResult = floatList.FirstOrDefault(v => v.nombre == result.Key);
            var doubleResult = doubleList.FirstOrDefault(v => v.nombre == result.Key);
            var booleanResult = booleanList.FirstOrDefault(v => v.nombre == result.Key);
            var charResult = charList.FirstOrDefault(v => v.nombre == result.Key);
            var cadenaResult = cadenaList.FirstOrDefault(v => v.nombre == result.Key);

            var result2 = variables.FirstOrDefault(v => v.Key == variable2);

            if(result2.Key == null)
            {
                if (enteroResult is not null && int.TryParse(variable2, out int datoEntero))
                    enteroResult.valor = datoEntero;

                else if (shortResult is not null && short.TryParse(variable2, out short datoShort))
                    shortResult.valor = datoShort;

                else if (longResult is not null && long.TryParse(variable2, out long datoLong))
                    longResult.valor = datoLong;

                else if (floatResult is not null && float.TryParse(variable2, out float datoFloat))
                    floatResult.valor = datoFloat;

                else if (doubleResult is not null && double.TryParse(variable2, out double datoDouble))
                    doubleResult.valor = datoDouble;

                else if (booleanResult is not null && bool.TryParse(variable2, out bool datoBoolean))
                    booleanResult.valor = datoBoolean;

                else if (charResult is not null)
                {
                    // Si es un char, asegúrate de que el valor tenga comillas simples
                    if (variable2.Length != 3 || variable2[0] != '\'' || variable2[2] != '\'')
                    {
                        Console.WriteLine($"Se esperaban comillas simples para el tipo de dato char en la variable '{variable1}'");
                        continue;
                    }
                    charResult.valor = variable2[1]; // Asigna el valor entre las comillas simples
                }
                else if (cadenaResult is not null)
                {
                    // Si es un string, asegúrate de que el valor tenga comillas dobles
                    if (variable2.Length < 2 || variable2[0] != '"' || variable2[variable2.Length - 1] != '"')
                    {
                        Console.WriteLine($"Se esperaban comillas dobles para el tipo de dato string en la variable '{variable1}'");
                        continue;
                    }
                    cadenaResult.valor = variable2.Substring(1, variable2.Length - 2); // Asigna el valor entre las comillas dobles
                }

                else
                    Console.WriteLine($"Los tipos de datos '{variable1}' y '{variable2}' no son compatibles");
            }
            else
            {
                var entero2Result = enteroList.FirstOrDefault(v => v.nombre == result2.Key);
                var short2Result = shortList.FirstOrDefault(v => v.nombre == result2.Key);
                var long2Result = longList.FirstOrDefault(v => v.nombre == result2.Key);
                var float2Result = floatList.FirstOrDefault(v => v.nombre == result2.Key);
                var double2Result = doubleList.FirstOrDefault(v => v.nombre == result2.Key);
                var boolean2Result = booleanList.FirstOrDefault(v => v.nombre == result2.Key);
                var char2Result = charList.FirstOrDefault(v => v.nombre == result2.Key);
                var cadena2Result = cadenaList.FirstOrDefault(v => v.nombre == result2.Key);

                if (enteroResult is not null && entero2Result is not null)
                    enteroResult.valor = entero2Result.valor;

                else if (shortResult is not null && short2Result is not null)
                    shortResult.valor = short2Result.valor;

                else if (longResult is not null && long2Result is not null)
                    longResult.valor = long2Result.valor;

                else if (floatResult is not null && float2Result is not null)
                    floatResult.valor = float2Result.valor;

                else if (doubleResult is not null && double2Result is not null)
                    doubleResult.valor = double2Result.valor;

                else if (booleanResult is not null && boolean2Result is not null)
                    booleanResult.valor = boolean2Result.valor;

                else if (charResult is not null && char2Result is not null)
                {
                    charResult.valor = char2Result.valor;
                }
                else if (cadenaResult is not null && cadena2Result is not null)
                {
                    cadenaResult.valor = cadena2Result.valor;
                }

                else
                    Console.WriteLine($"Los tipos de datos '{variable1}' y '{variable2}' no son compatibles");
            }

            continue;
        }
    }

    //Entero
    if (Regex.IsMatch(valor, patronEnteroValConValor) || Regex.IsMatch(valor, patronEnteroVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - inicioNombre - 1).Trim(); // Corrección aquí

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1).Trim(); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                entero = new Entero(nombre, int.Parse(valorDespuesDelIgual));
                enteroList.Add(entero);
                variables.Add(entero.nombre, true);
            }
        }
    }
    //Entero
    else if (Regex.IsMatch(valor, patronEnteroVal) || Regex.IsMatch(valor, patronEnteroVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - inicioNombre - 1).Trim(); // Corrección aquí

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {

            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                entero = new Entero(nombre);
                enteroList.Add(entero);
                variables.Add(entero.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + entero.nombre);
            ////Console.WriteLine("Valor: " + entero.valor);

            //Console.WriteLine("Imprimiendo el nombre de este lado: " + nombre);
            //Console.WriteLine("Probando la lista: ");

            //// Aquí hay algo raro, no sé por qué con " " me da null reference...
            //var num1 = enteroList.FirstOrDefault(e => e.nombre.Equals("num1"));
            ////var num2 = enteroList.FirstOrDefault(e => e.nombre == "num2");

            //Console.WriteLine("Variable1: " + num1?.nombre);
            ////Console.WriteLine("Variable2: " + num2.nombre);
        }
    }
    //Short
    else if (Regex.IsMatch(valor, patronShortValConValor) || Regex.IsMatch(valor, patronShortVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                mishort = new Short(nombre, short.Parse(valorDespuesDelIgual));
                shortList.Add(mishort);
                variables.Add(mishort.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + mishort.nombre);
            //Console.WriteLine("Valor: " + mishort.valor);
        }
    }
    //Short
    else if (Regex.IsMatch(valor, patronShortVal) || Regex.IsMatch(valor, patronShortVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                mishort = new Short(nombre);
                shortList.Add(mishort);
                variables.Add(mishort.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + mishort.nombre);
            //Console.WriteLine("Valor: " + mishort.valor);
        }
    }
    //Long
    else if (Regex.IsMatch(valor, patronLongValConValor) || Regex.IsMatch(valor, patronLongVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                milong = new Long(nombre, long.Parse(valorDespuesDelIgual));
                longList.Add(milong);
                variables.Add(milong.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + milong.nombre);
            //Console.WriteLine("Valor: " + milong.valor);
        }
    }
    //Long
    else if (Regex.IsMatch(valor, patronLongVal) || Regex.IsMatch(valor, patronLongVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                milong = new Long(nombre);
                longList.Add(milong);
                variables.Add(milong.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + milong.nombre);
            //Console.WriteLine("Valor: " + milong.valor);
        }
    }
    //Float
    else if (Regex.IsMatch(valor, patronFloatValConValor) || Regex.IsMatch(valor, patronFloatVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                mifloat = new Float(nombre, float.Parse(valorDespuesDelIgual));
                floatList.Add(mifloat);
                variables.Add(mifloat.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + mifloat.nombre);
            //Console.WriteLine("Valor: " + mifloat.valor);
        }
    }
    //Float
    else if (Regex.IsMatch(valor, patronFloatVal) || Regex.IsMatch(valor, patronFloatVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                mifloat = new Float(nombre);
                floatList.Add(mifloat);
                variables.Add(mifloat.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + mifloat.nombre);
            //Console.WriteLine("Valor: " + mifloat.valor);
        }
    }
    //Double
    else if (Regex.IsMatch(valor, patronDoubleValConValor) || Regex.IsMatch(valor, patronDoubleVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                midouble = new miDouble(nombre, double.Parse(valorDespuesDelIgual));
                doubleList.Add(midouble);
                variables.Add(midouble.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + midouble.nombre);
            //Console.WriteLine("Valor: " + midouble.valor);
        }
    }
    //Double
    else if (Regex.IsMatch(valor, patronDoubleVal) || Regex.IsMatch(valor, patronDoubleVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                midouble = new miDouble(nombre);
                doubleList.Add(midouble);
                variables.Add(midouble.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + midouble.nombre);
            //Console.WriteLine("Valor: " + midouble.valor);
        }
    }
    //Boolean
    else if (Regex.IsMatch(valor, patronBooleanValConValor) || Regex.IsMatch(valor, patronBooleanVarConValor))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
        string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                boolean = new miBoolean(nombre, bool.Parse(valorDespuesDelIgual));
                booleanList.Add(boolean);
                variables.Add(boolean.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + boolean.nombre);
            //Console.WriteLine("Valor: " + boolean.valor);
        }
    }
    //Boolean
    else if (Regex.IsMatch(valor, patronBooleanVal) || Regex.IsMatch(valor, patronBooleanVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                boolean = new miBoolean(nombre);
                booleanList.Add(boolean);
                variables.Add(boolean.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + boolean.nombre);
            //Console.WriteLine("Valor: " + boolean.valor);
        }
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

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                michar = new miChar(nombre, charValor);
                charList.Add(michar);
                variables.Add(michar.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable en miChar: " + michar.nombre);
            //Console.WriteLine("Valor: " + michar.valor);
        }
    }
    //Char
    else if (Regex.IsMatch(valor, patronCharVal) || Regex.IsMatch(valor, patronCharVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                michar = new miChar(nombre);
                charList.Add(michar);
                variables.Add(michar.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + michar.nombre);
            //Console.WriteLine("Valor: " + michar.valor);
        }
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

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                // Crea una instancia de la clase Cadena
                cadena = new Cadena(nombre, valorDespuesDelIgual);
                cadenaList.Add(cadena);
                variables.Add(cadena.nombre, true);
            }

            // Imprime los resultados
            //Console.WriteLine("Nombre de la variable: " + cadena.nombre);
            //Console.WriteLine("Valor: " + cadena.valor);
        }
    }
    //String
    else if (Regex.IsMatch(valor, patronStringVal) || Regex.IsMatch(valor, patronStringVar))
    {
        int inicioNombre = valor.IndexOf(' ');
        int finNombre = valor.IndexOf(':');
        string nombre = valor.Substring(inicioNombre + 1, finNombre - 4);

        if (variables.ContainsKey(nombre))
        {
            Console.WriteLine($"Ya existe una variable con este nombre '{nombre}'\n");
            continue;
        }
        else
        {
            if (VerificarQueNoSeaUnaPalabraReservada(nombre) == false)
            {
                cadena = new Cadena(nombre);
                cadenaList.Add(cadena);
                variables.Add(cadena.nombre, true);
            }

            //Console.WriteLine("Nombre de la variable: " + cadena.nombre);
            //Console.WriteLine("Valor: " + cadena.valor);
        }
    }
    //Mensajes de error
    else
    {
        Console.WriteLine("\n\n-------------------------------------------------------------------------------------------------");
        if (System.String.IsNullOrEmpty(valor))
        {
            Console.WriteLine("Ingrese una instrucción");
        }
        else
        {
            Console.WriteLine("Syntaxis incorrecta");

            ///// var o val
            //// que contenga :
            //// que contenga el tipo de dato
            ///


            if (valor.StartsWith("v"))
            {
                // Validación adicional
                bool nombreValido = true;
                string mensajeError = "Entrada no válida: ";

                // Verificar si es "var" o "val"
                if (!(valor.StartsWith("var") || valor.StartsWith("val")))
                {
                    nombreValido = false;
                    mensajeError += "debe comenzar con 'var' o 'val'. ";
                }

                // Verificar si el nombre contiene espacio o empieza con un número
                int inicioNombre = valor.IndexOf(' ') + 1;
                int finNombre = valor.IndexOf(':');
                if (finNombre > inicioNombre)
                {
                    string nombre = valor.Substring(inicioNombre, finNombre - inicioNombre).Trim();
                    if (nombre.Contains(' ') || char.IsDigit(nombre[0]))
                    {
                        nombreValido = false;
                        mensajeError += "el nombre no debe contener espacios ni empezar con un número. ";
                    }
                }

                // Verificar si tiene dos puntos
                if (!valor.Contains(":"))
                {
                    nombreValido = false;
                    mensajeError += "debe contener ':'. ";
                }

                // Verificar si tiene un tipo de dato
                bool tipoValido = false;
                foreach (var tipo in new[] { "Int", "Short", "Long", "Float", "Double", "Boolean", "Char", "String" })
                {
                    if (valor.Contains($": {tipo}"))
                    {
                        tipoValido = true;
                        break;
                    }
                }
                if (!tipoValido)
                {
                    nombreValido = false;
                    mensajeError += "debe contener un tipo de dato válido. ";
                }
                //Verificar si el nombre contiene espacios o empieza con numeros
                //int inicioNombre2 = valor.IndexOf(' ') + 1;
                //int finNombre2 = valor.IndexOf(':');
                //if (finNombre2 > inicioNombre2)
                //{
                //    string nombre2 = valor.Substring(inicioNombre2, finNombre2 - inicioNombre2).Trim();
                //    if (!nombre2.Contains(' ') || char.IsDigit(nombre2[0]))
                //    {
                //        nombreValido = false;
                //        mensajeError += "el nombre no debe contener espacios ni empezar con un número. ";
                //    }
                //}

                // Verificar si tiene el signo igual
                if (valor.Contains("="))
                {
                    int indiceIgual = valor.IndexOf('='); // Encuentra la posición del signo '='
                    string valorDespuesDelIgual = valor.Substring(indiceIgual + 1); // Obtén la parte de la cadena después del signo '='

                    if (System.String.IsNullOrEmpty(valorDespuesDelIgual))
                    {
                        nombreValido = false;
                        mensajeError += "debe contener el valor despues del '='. ";
                    }
                }

                if (!nombreValido)
                {
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    Console.WriteLine("Entrada no válida.");
                }
            }

            else if (valor.StartsWith("p"))
            {
                string mensajeError = "Entrada no válida: ";

                if (Regex.IsMatch(valor, patronPrintConVariable) || Regex.IsMatch(valor, patronPrintlnConVariable))
                    Console.WriteLine($"No se reconoce '{variableNoEncontrada}'");

                else
                {
                    // Verificar si es "print" o "println"
                    if (!(valor.StartsWith("print") || valor.StartsWith("println")))
                        mensajeError += "debe comenzar con 'print' o 'println'. ";

                    // Verificar si tiene dos puntos
                    if (!valor.Contains("("))
                        mensajeError += "debe contener '('. ";

                    if (!valor.Contains("\""))
                        mensajeError += "debe contener '\"'. ";

                    if (!valor.Contains(")"))
                        mensajeError += "debe contener ')'. ";

                    Console.WriteLine(mensajeError);
                    Console.WriteLine("Entrada no válida.");
                }
            }

            else
                Console.WriteLine($"No se reconoce '{valor}'");

        }
    }


    Console.WriteLine();
}



static bool VerificarQueNoSeaUnaPalabraReservada(string nombre)
{
    foreach (var tipo in new[] {
    "Int", "Short", "Byte", "Long", "Float", "Double", "Boolean", "Char", "String", "var", "val", "main", "fun",
    "const", "object", "companion", "private", "public", "protected", "internal", "null", "if", "else", "when", "for",
    "array", "ranges", "list", "while", "do", "false", "true", "constructor", "init", "typealias", "interface", "override",
    "abstract", "class", "super", "data", "enum",
    "as", "as?", "break", "class", "continue", "do", "else", "false", "for", "fun", "if", "in", "!in", "interface", "is",
    "!is", "null", "object", "package", "return", "super", "this", "throw", "true", "try", "typealias", "val", "var", "when",
    "while", "by", "catch", "constructor", "delegate", "dynamic", "field", "file", "finally", "get", "import", "init",
    "param", "property", "receiver", "set", "setparam", "where", "actual", "abstract", "annotation", "companion", "const",
    "crossinline", "data", "enum", "expect", "external", "final", "infix", "inline", "inner", "internal", "lateinit",
    "noinline", "open", "operator", "out", "override", "private", "protected", "public", "reified", "sealed", "suspend",
    "tailrec", "vararg", "field", "it", "value"
    })

    {
        if (nombre == tipo)
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"'{nombre}' es una palabra reservada");
            return true;
        }
    }
    return false;
}


//puede que no se necesite esta parte
bool BuscarValorVariable(string nombre)
{
    var result = variables.FirstOrDefault(v => v.Key == nombre);
    if (result.Key != null)
    {
        var enteroResult = enteroList.FirstOrDefault(v => v.nombre == result.Key);
        var shortResult = shortList.FirstOrDefault(v => v.nombre == result.Key);
        var longResult = longList.FirstOrDefault(v => v.nombre == result.Key);
        var floatResult = floatList.FirstOrDefault(v => v.nombre == result.Key);
        var doubleResult = doubleList.FirstOrDefault(v => v.nombre == result.Key);
        var booleanResult = booleanList.FirstOrDefault(v => v.nombre == result.Key);
        var charResult = charList.FirstOrDefault(v => v.nombre == result.Key);
        var cadenaResult = cadenaList.FirstOrDefault(v => v.nombre == result.Key);

        if (enteroResult is not null) return true;

        else if (shortResult is not null) return true;

        else if (longResult is not null) return true;

        else if (floatResult is not null) return true;

        else if (doubleResult is not null) return true;

        else if (booleanResult is not null) return true;

        else if (charResult is not null) return true;

        else if (cadenaResult is not null) return true;

        return false;
    }
    else
        return false;
}