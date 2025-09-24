using System;
using System.Collections.Generic;

namespace Jogo_da_Velha
{
    class Program
    {
        static int vitoriasX = 0;
        static int vitoriasO = 0;
        static int empates = 0;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("|---------------------------------------|");
                Console.WriteLine("|   BEM VINDO AO MELHOR JOGO DA VELHA   |");
                Console.WriteLine("|---------------------------------------|");
                Console.WriteLine("1. Jogador vs Jogador");
                Console.WriteLine("2. Jogador vs Computador (Fácil)");
                Console.WriteLine("3. Jogador vs Computador (Difícil)");
                Console.WriteLine("4. Exibir Ranking");
                Console.WriteLine("0. Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        IniciarJogoPvP();
                        break;
                    case "2":
                        IniciarJogoCPUFacil();
                        break;
                    case "3":
                        IniciarJogoCPUDificil();
                        break;
                    case "4":
                        ExibirRanking();
                        break;
                    case "0":
                        sair = true;
                        Console.WriteLine("Saindo do jogo. Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione ENTER para tentar novamente...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void IniciarJogoPvP()
        {
            string[,] matriz = new string[3, 3];
            string turno = "X";
            List<string> indexNumeros = new List<string>();
            int index = 1, tentativas = 1;
            bool houveGanhador = false;

            ImprimirTituloJogo();
            index = AlimentarMatriz(matriz, indexNumeros, index);
            ImprimirMatriz(matriz);

            EscolherPosicaoJogada(turno);
            string jogada = Console.ReadLine();
            Console.Clear();

            while (tentativas < 9)
            {
                ImprimirTituloJogo();
                SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                ImprimirMatriz(matriz);

                if (VerificarVitoria(matriz))
                {
                    ImprimirMensagemFimJogoGanhador(turno);
                    if (turno == "X") vitoriasX++;
                    else vitoriasO++;
                    houveGanhador = true;
                    break;
                }

                turno = turno == "X" ? "O" : "X";
                Console.WriteLine();

                EscolherPosicaoJogada(turno);
                jogada = Console.ReadLine();
                while (!indexNumeros.Contains(jogada))
                {
                    Console.WriteLine();
                    Console.Write("Jogada invalida. Tente Novamente: ");
                    jogada = Console.ReadLine();
                }
                tentativas++;
                Console.Clear();
            }
            if (!houveGanhador && tentativas == 9)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);
                ImprimirMensagemImpate();
                empates++;
            }
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        static void IniciarJogoCPUFacil()
        {
            string[,] matriz = new string[3, 3];
            List<string> indexNumeros = new List<string>();
            int index = 1, tentativas = 1;
            bool houveGanhador = false;
            string turno = "X";

            ImprimirTituloJogo();
            index = AlimentarMatriz(matriz, indexNumeros, index);
            

            Console.WriteLine("\nVocê é o [X] — o computador é [O].");

            string jogada = "";
            while (tentativas <= 9)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);

                if (turno == "X")
                {
                    EscolherPosicaoJogada(turno);
                    jogada = Console.ReadLine();
                    while (!indexNumeros.Contains(jogada))
                    {
                        Console.Write("Jogada inválida. Tente novamente: ");
                        jogada = Console.ReadLine();
                    }
                    SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                }
                else // vez do computador (fácil)
                {
                    Console.WriteLine("\nComputador pensando...");
                    System.Threading.Thread.Sleep(500);
                    jogada = indexNumeros[rnd.Next(indexNumeros.Count)];
                    SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                    Console.WriteLine($"Computador jogou na posição {jogada}.");
                    System.Threading.Thread.Sleep(600);
                }

                if (VerificarVitoria(matriz))
                {
                    ImprimirTituloJogo();
                    ImprimirMatriz(matriz);
                    ImprimirMensagemFimJogoGanhador(turno);
                    if (turno == "X") vitoriasX++;
                    else vitoriasO++;
                    houveGanhador = true;
                    break;
                }

                tentativas++;
                turno = (turno == "X") ? "O" : "X";
                Console.Clear();
            }
            if (!houveGanhador)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);
                ImprimirMensagemImpate();
                empates++;
            }
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        // ----------- MODO DIFÍCIL -----------
        static void IniciarJogoCPUDificil()
        {
            string[,] matriz = new string[3, 3];
            List<string> indexNumeros = new List<string>();
            int index = 1, tentativas = 1;
            bool houveGanhador = false;
            string turno = "X"; // Jogador sempre começa

            ImprimirTituloJogo();
            index = AlimentarMatriz(matriz, indexNumeros, index);
            

            Console.WriteLine("\nVocê é o [X] — o computador é [O].");

            string jogada = "";
            while (tentativas <= 9)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);

                if (turno == "X")
                {
                    EscolherPosicaoJogada(turno);
                    jogada = Console.ReadLine();
                    while (!indexNumeros.Contains(jogada))
                    {
                        Console.Write("Jogada inválida. Tente novamente: ");
                        jogada = Console.ReadLine();
                    }
                    SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                }
                else // vez do computador (difícil)
                {
                    Console.WriteLine("\nComputador pensando...");
                    System.Threading.Thread.Sleep(600);
                    jogada = MelhorJogadaCPU(matriz, indexNumeros);
                    SubstituirValorNaSuaRespectivaCasa(matriz, turno, indexNumeros, jogada);
                    Console.WriteLine($"Computador jogou na posição {jogada}.");
                    System.Threading.Thread.Sleep(700);
                }

                if (VerificarVitoria(matriz))
                {
                    ImprimirTituloJogo();
                    ImprimirMatriz(matriz);
                    ImprimirMensagemFimJogoGanhador(turno);
                    if (turno == "X") vitoriasX++;
                    else vitoriasO++;
                    houveGanhador = true;
                    break;
                }

                tentativas++;
                turno = (turno == "X") ? "O" : "X";
                Console.Clear();
            }
            if (!houveGanhador)
            {
                ImprimirTituloJogo();
                ImprimirMatriz(matriz);
                ImprimirMensagemImpate();
                empates++;
            }
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        // AI para CPU difícil
        static string MelhorJogadaCPU(string[,] matriz, List<string> indexNumeros)
        {
            // 1. GANHAR se possível
            foreach (var pos in indexNumeros)
            {
                string[,] teste = (string[,])matriz.Clone();
                SimulaJogada(teste, pos, "O");
                if (VerificarVitoria(teste)) return pos;
            }
            // 2. BLOQUEAR jogador
            foreach (var pos in indexNumeros)
            {
                string[,] teste = (string[,])matriz.Clone();
                SimulaJogada(teste, pos, "X");
                if (VerificarVitoria(teste)) return pos;
            }
            // 3. Centro
            if (indexNumeros.Contains("5")) return "5";
            // 4. Cantos
            var cantos = new List<string> { "1", "3", "7", "9" };
            foreach (var canto in cantos)
                if (indexNumeros.Contains(canto))
                    return canto;
            // 5. Aleatório (se nada acima)
            return indexNumeros[rnd.Next(indexNumeros.Count)];
        }
        static void SimulaJogada(string[,] matriz, string pos, string simbolo)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (matriz[i, j] == pos)
                        matriz[i, j] = simbolo;
        }

        static void ExibirRanking()
        {
            Console.WriteLine("\n------ RANKING ------");
            Console.WriteLine($"Jogador X: {vitoriasX} vitórias");
            Console.WriteLine($"Computador/Jogador O: {vitoriasO} vitórias");
            Console.WriteLine($"Empates:   {empates}");
            Console.WriteLine("---------------------");
            Console.WriteLine("Pressione ENTER para voltar ao menu.");
            Console.ReadLine();
        }

        // ----------- Funções auxiliares -----------
        private static void ImprimirTituloJogo()
        {
        }
        private static int AlimentarMatriz(string[,] matriz, List<string> indexNumeros, int index)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            return index;
        }
        private static void ImprimirMatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                    Console.Write($" [{matriz[i, j]}] ");
                Console.WriteLine();
            }
        }
        private static void ImprimirMensagemFimJogoGanhador(string turno)
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Fim de Jogo!!!");
            Console.WriteLine("--------------");
            if (turno == "O")
                Console.WriteLine("\nO ganhador foi o [O] (Computador ou Jogador 2)!");
            else
                Console.WriteLine($"\nParabéns!!! O ganhador é [{turno}].");
        }
        private static void EscolherPosicaoJogada(string turno)
        {
            Console.Write($"\nVocê quer jogar [{turno}] em qual posição? ");
        }
        private static void ImprimirMensagemImpate()
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Fim de Jogo!!!");
            Console.WriteLine("--------------");
            Console.WriteLine($"\nQue triste!!! Ninguém ganhou.");
        }
        private static void SubstituirValorNaSuaRespectivaCasa(string[,] matriz, string turno, List<string> indexNumeros, string jogada)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == jogada && indexNumeros.Contains(jogada))
                    {
                        matriz[i, j] = turno;
                        indexNumeros.Remove(jogada);
                    }
        }
        private static bool VerificarVitoria(string[,] matriz)
        {
            // Linhas
            for (int i = 0; i < 3; i++)
                if (matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2])
                    return true;
            // Colunas
            for (int j = 0; j < 3; j++)
                if (matriz[0, j] == matriz[1, j] && matriz[1, j] == matriz[2, j])
                    return true;
            // Diagonais
            if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2])
                return true;
            if (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                return true;
            return false;
        }
    }
}