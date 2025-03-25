using Matrix2dLib;

var m = new Matrix2d();
Console.WriteLine(m); // Wyświetlanie macierzy

var m1 = new Matrix2d(1, 2, 3, 4);
Console.WriteLine(m1); // Wyświetlanie macierzy m1

var m2 = Matrix2d.Transpose(m1); // Transpozycja macierzy m1
Console.WriteLine("Transpozycja m1: " + m2);

var m3 = (int[,])m2; // Rzutowanie na tablicę
Console.WriteLine($"Macierz 2D jako tablica: [{m3[0, 0]}, {m3[0, 1]}], [{m3[1, 0]}, {m3[1, 1]}]");

var m4 = Matrix2d.Parse("[[5, 6], [7, 8]]"); // Parsowanie stringa do obiektu Matrix2d
Console.WriteLine("Macierz m4: " + m4);

var determinant = m1.Det(); // Obliczanie wyznacznika
Console.WriteLine($"Wyznacznik macierzy m1: {determinant}");

var m5 = -m1; // Zastosowanie operatora unitarnego
Console.WriteLine("Macierz m5 (odwrotność m1): " + m5);
