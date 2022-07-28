Console.WriteLine("--- Anel De Coração ---\n");

int n = 0, dificuldade = 1;
for (int i = 0; i < 10; i++)
{
    n += dificuldade++;
    Console.Write($"{n} ");
}
