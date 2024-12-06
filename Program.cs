using System.Text;

namespace Home_Work_7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;


            char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

            char currentPlayer = 'X';
            bool gameRunning = true;
            int movesCount = 0;

            while (gameRunning)
            {
                Console.Clear();

                // Виведення ігрового поля
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
                    if (i < 2)
                        Console.WriteLine("---|---|---");
                }

                // Хід гравця
                Console.WriteLine($"\nГравець {currentPlayer}, ваш хід.");
                int move = -1;
                bool validMove = false;

                while (!validMove)
                {
                    Console.Write("Виберіть номер клітинки (1-9): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out move) && move >= 1 && move <= 9)
                    {
                        int row = (move - 1) / 3;
                        int col = (move - 1) % 3;

                        if (board[row, col] != 'X' && board[row, col] != 'O')
                        {
                            board[row, col] = currentPlayer;
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Ця клітинка вже зайнята. Спробуйте ще раз.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильний хід. Спробуйте ще раз.");
                    }
                }

                movesCount++;

                // Перевірка на виграш
                bool win = false;

                for (int i = 0; i < 3; i++)
                {
                    // Перевірка горизонталей і вертикалей
                    if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                        (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                    {
                        win = true;
                        break;
                    }
                }

                // Перевірка діагоналей
                if (!win &&
                    ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                     (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)))
                {
                    win = true;
                }

                if (win)
                {
                    Console.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
                        if (i < 2)
                            Console.WriteLine("---|---|---");
                    }
                    Console.WriteLine($"\nГравець {currentPlayer} виграв!");
                    gameRunning = false;
                    continue;
                }

                // Перевірка на нічию
                if (movesCount == 9)
                {
                    Console.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
                        if (i < 2)
                            Console.WriteLine("---|---|---");
                    }
                    Console.WriteLine("\nНічия!");
                    gameRunning = false;
                    continue;
                }

                // Зміна гравця
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
    }
}
