using System;
using System.Linq;

class Program
{
    static void Main()
    {
        const int qtdeNumeros = 6;
        const int maxNumero = 60;

        int[] apostas = new int[qtdeNumeros];
        int[] sorteio = new int[qtdeNumeros];

        Console.WriteLine("Loteria - Escolha seus 6 números (1 a 60):");

        // Entrada da aposta do jogador
        for (int i = 0; i < qtdeNumeros; i++)
        {
            while (true)
            {
                Console.Write($"Número {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int numero) &&
                    numero >= 1 && numero <= maxNumero && !apostas.Contains(numero))
                {
                    apostas[i] = numero;
                    break;
                }
                else
                {
                    Console.WriteLine("Número inválido ou repetido. Tente novamente.");
                }
            }
        }

        // Sorteio aleatório sem repetição
        Random rand = new Random();
        int count = 0;
        while (count < qtdeNumeros)
        {
            int num = rand.Next(1, maxNumero + 1);
            if (!sorteio.Contains(num))
            {
                sorteio[count] = num;
                count++;
            }
        }

        // Contagem de acertos
        int acertos = apostas.Intersect(sorteio).Count();

        // Resultado
        Console.WriteLine("\nSua aposta: " + string.Join(", ", apostas));
        Console.WriteLine("Números sorteados: " + string.Join(", ", sorteio));
        Console.WriteLine($"Você acertou {acertos} número(s).");
        if (acertos == 6) Console.WriteLine("Parabéns! Você ganhou na loteria!");
        else if (acertos >= 4) Console.WriteLine("Muito bem! Você fez uma boa pontuação!");
        else Console.WriteLine("Não foi dessa vez. Tente novamente.");
    }
}

