using System.Text.RegularExpressions;

Console.WriteLine("Hola mundo");

string patronEnteroValConValor = @"^val _?[A-Za-z0-9]*: Int = [0-9]+$";

while (true)
{
    Console.Write("Ingrese un string: ");
    string valor = Console.ReadLine();

    if (Regex.IsMatch(valor, patronEnteroValConValor))
    {
        Console.WriteLine("Todo correcto");
        Console.WriteLine(valor);
    }
    else
        Console.WriteLine("Incorrecto");
}
