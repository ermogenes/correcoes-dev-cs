using System.Security.Cryptography;

Console.WriteLine("--- Gerador de Senhas ---\n");

const int QuantidadeDeSenhas = 10;
const int TamanhoDaSenha = 15;

const string CaracteresEspeciais = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
const string CaracteresAlfabeticosMinusculos = "abcdefghijklmnopqrstuvwxyz";
const string CaracteresAlfabeticosMaiusculos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const string CaracteresNumericos = "0123456789";

const string CaracteresValidos = CaracteresAlfabeticosMinusculos
    + CaracteresAlfabeticosMaiusculos
    + CaracteresNumericos
    + CaracteresEspeciais;

for (int qtd = 0; qtd < QuantidadeDeSenhas; qtd++)
{
    var caracteresSorteados = new char[TamanhoDaSenha];
    for (int posicao = 0; posicao < TamanhoDaSenha; posicao++)
    {
        int posicaoSorteada = RandomNumberGenerator.GetInt32(0, CaracteresValidos.Length);
        caracteresSorteados[posicao] = CaracteresValidos[posicaoSorteada];
    }

    string senha = String.Join("", caracteresSorteados);
    Console.WriteLine(senha);
}
