﻿Console.WriteLine();

string[,] imagem ={
  { " "," "," "," "," "," ","_","_"," "," "," "," "," "," "," " },
  { " ","w"," "," ","c","(",".",".",")","o"," "," "," ","("," " },
  { " "," ","\\","_","_","(","-",")"," "," "," "," ","_","_",")" },
  { " "," "," "," "," "," ","/","\\"," "," "," ","("," "," "," " },
  { " "," "," "," "," ","/","(","_",")","_","_","_",")"," "," " },
  { " "," "," "," "," ","w"," ","/","|"," "," "," "," "," "," " },
  { " "," "," "," "," "," ","|"," ","\\"," "," "," "," "," "," " },
  { " "," "," "," "," ","m"," "," ","m"," "," "," "," "," "," " }
};

for (int i = 0; i <= imagem.GetUpperBound(0); i++)
{
    for (int j = 0; j <= imagem.GetUpperBound(1); j++)
    {
        Console.Write(imagem[i, j]);
    }
    Console.WriteLine();
}

Console.WriteLine();