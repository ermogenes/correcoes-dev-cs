using System.Security.Cryptography;

const int PROCURANDO = 0;
const int ATACANDO = 1;
const int FUGINDO = 2;
const int MORTO = 4;

const double Fps = 2;

Console.WriteLine("--- Simulação de IA de NPC ---\n");

int estado = PROCURANDO;
int estadoAnterior = PROCURANDO;
string descricaoEstado = "";
string descricaoEstadoAnterior = "";

bool inimigoProximo = false;
bool ferido = false;
bool eliminado = false;

int transicoes = 0;

while (estado != MORTO)
{
    estadoAnterior = estado;
    transicoes++;

    // Simular acontecimentos (em vez de disponibilizar "controles do jogo" ao jogador)
    switch (estado)
    {
        case PROCURANDO:
            if (RandomNumberGenerator.GetInt32(0, 2) == 0) ferido = false;
            if (RandomNumberGenerator.GetInt32(0, 2) == 0) inimigoProximo = true;
            break;
        case ATACANDO:
            if (RandomNumberGenerator.GetInt32(0, 2) == 0)
            {
                ferido = true;
                if (RandomNumberGenerator.GetInt32(0, 2) == 0) eliminado = true;
            }
            if (RandomNumberGenerator.GetInt32(0, 2) == 0) inimigoProximo = false;
            break;
        case FUGINDO:
            if (RandomNumberGenerator.GetInt32(0, 4) == 0) eliminado = true;
            if (RandomNumberGenerator.GetInt32(0, 4) == 0) ferido = false;
            if (RandomNumberGenerator.GetInt32(0, 2) == 0) inimigoProximo = false;
            break;
    }

    // Atualizar estado do NPC em resposta aos acontecimentos ("IA do NPC")
    if (eliminado)
        estado = MORTO;
    else if (estado == PROCURANDO && !ferido && inimigoProximo)
        estado = ATACANDO;
    else if (estado == ATACANDO)
    {
        if (!inimigoProximo)
            estado = PROCURANDO;
        else if (ferido)
            estado = FUGINDO;
    }
    else if (estado == FUGINDO && !ferido)
        estado = PROCURANDO;

    // Exibir situação atual ("gráfico do jogo")
    switch (estadoAnterior)
    {
        case PROCURANDO: descricaoEstadoAnterior = "Procurando"; break;
        case ATACANDO: descricaoEstadoAnterior = "Atacando"; break;
        case FUGINDO: descricaoEstadoAnterior = "Fugindo"; break;
        case MORTO: descricaoEstadoAnterior = "Morto"; break;
    }
    switch (estado)
    {
        case PROCURANDO: descricaoEstado = "Procurando"; break;
        case ATACANDO: descricaoEstado = "Atacando"; break;
        case FUGINDO: descricaoEstado = "Fugindo"; break;
        case MORTO: descricaoEstado = "Morto"; break;
    }

    Console.WriteLine($"-- #{transicoes,3} {descricaoEstadoAnterior,10}: Ferido = {(ferido ? "S" : "N")}, InimigoProximo = {(inimigoProximo ? "S" : "N")}, Eliminado = {(eliminado ? "S" : "N")} => {descricaoEstado}");

    // Aguardar tempo especificado de quadros por segundo ("FPS")
    Thread.Sleep(Convert.ToInt32(1000 / Fps));
}

Console.WriteLine($"\nO NPC sobreviveu por {transicoes - 1} transições.");
