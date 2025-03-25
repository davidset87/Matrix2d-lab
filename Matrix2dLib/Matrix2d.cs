namespace Matrix2dLib
{
    public class Matrix2d : IEquatable<Matrix2d>
    {
        int a, b, c, d; // prywatne pola
        /*
         -----
        | a b |
        | c d |
        */

        // Konstruktor
        public Matrix2d(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2d() : this(1, 0, 0, 1) { }

        public static Matrix2d Id => new Matrix2d(1, 0, 0, 1);  // Macierz jednostkowa
        public static Matrix2d Zero => new Matrix2d(0, 0, 0, 0); // Macierz zerowa

        public override string ToString() => $"[[{a}, {b}], [{c}, {d}]]"; // Reprezentacja tekstowa macierzy

        public bool Equals(Matrix2d other)
        {
            if (other is null) return false;
            return a == other.a &&
                   b == other.b &&
                   c == other.c &&
                   d == other.d;
        }

        public override bool Equals(object obj) => Equals(obj as Matrix2d); // Porównanie obiektów

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b, c, d); // Generowanie kodu hash
        }

        public static bool operator ==(Matrix2d left, Matrix2d right) => left.Equals(right);
        public static bool operator !=(Matrix2d left, Matrix2d right) => !left.Equals(right);

        public static Matrix2d operator +(Matrix2d left, Matrix2d right) =>
            new Matrix2d(left.a + right.a, left.b + right.b, left.c + right.c, left.d + right.d); // Dodawanie macierzy

        public static Matrix2d operator -(Matrix2d left, Matrix2d right) =>
            new Matrix2d(left.a - right.a, left.b - right.b, left.c - right.c, left.d - right.d); // Odejmowanie macierzy

        public static Matrix2d operator *(int k, Matrix2d macierz) =>
            new Matrix2d(k * macierz.a, k * macierz.b, k * macierz.c, k * macierz.d); // Mnożenie macierzy przez liczbę

        public static Matrix2d operator *(Matrix2d macierz, int k) => k * macierz; // Mnożenie macierzy przez liczbę

        public static Matrix2d operator -(Matrix2d macierz) =>
            new Matrix2d(-macierz.a, -macierz.b, -macierz.c, -macierz.d); // Zmiana znaków macierzy

        public static Matrix2d Transpose(Matrix2d m) => new Matrix2d(m.a, m.c, m.b, m.d); // Transpozycja macierzy

        public static explicit operator int[,](Matrix2d m) =>
            new int[2, 2] { { m.a, m.b }, { m.c, m.d } }; // Rzutowanie na tablicę

        // Obliczanie wyznacznika
        public static int Determinant(Matrix2d m) => m.a * m.d - m.b * m.c; // Wyznacznik macierzy 2x2

        // Metoda instancji do obliczania wyznacznika
        public int Det() => Determinant(this); // Wyznacznik dla obiektu

        // Parse string do obiektu Matrix2d
        public static Matrix2d Parse(string str)
        {
            // Czyszczenie łańcucha, aby upewnić się, że ma odpowiedni format
            str = str.Replace(" ", "").Replace("[[", "").Replace("]]", "");

            // Rozdzielanie wierszy macierzy
            var rows = str.Split("],[");

            if (rows.Length != 2) throw new FormatException("Niepoprawny format macierzy."); // Sprawdzenie, czy jest 2 wiersze

            // Pobieranie wartości wierszy
            var row1 = rows[0].Split(",");
            var row2 = rows[1].Split(",");

            if (row1.Length != 2 || row2.Length != 2) throw new FormatException("Niepoprawny format macierzy."); // Sprawdzenie, czy są 2 wartości w każdym wierszu

            try
            {
                // Parsowanie wartości na liczby całkowite
                int a = int.Parse(row1[0]);
                int b = int.Parse(row1[1]);
                int c = int.Parse(row2[0]);
                int d = int.Parse(row2[1]);

                return new Matrix2d(a, b, c, d); // Zwracanie nowego obiektu Matrix2d
            }
            catch (FormatException)
            {
                throw new FormatException("Błąd podczas analizy wartości macierzy."); // Obsługa błędów w analizie wartości
            }
        }
    }
}
