using System;

namespace ASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 32;
            while (i <= 126)
            {
                char caractere = Convert.ToChar(i);
                Console.Write(caractere);
                i++;
            }
        }
    }
}
