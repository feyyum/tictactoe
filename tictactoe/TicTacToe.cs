using System;

namespace tictactoe
{
    public class TicTacToe
    {
        private static String _first_player = "Birinci Oyuncu";
        private static String _second_player = "İkinci Oyuncu";
        
        private static String[] _values = new String[9];
        private static String[] _moves = {"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2" , "C3"};
        private static int _move_count = 0;

        public static void Start()
        {
            _values = new string[] {"X", null, null, null, "O", null, null, null, "X"};
            _move_count = 0;
            Console.WriteLine("Tic-Tac-Toe oyununa hoşgeldiniz!");
            ShowTable();
            Console.WriteLine("\t \t \t \t Created by Can and Feyyaz with love <3.");
            TakeNames();
            _values = new String[9];
            MakeMove();
        }
        
        private static void ShowTable()
        {
            Console.WriteLine("     1       2        3  ");
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"A    {(_values[0] == null ? " " : _values[0])}   |   " +
                              $"{(_values[1] == null ? " " : _values[1])}   |   {(_values[2] == null ? " " : _values[2])}   ");
            Console.WriteLine("  _______|_______|_______");
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"B    {(_values[3] == null ? " " : _values[3])}   |   " +
                              $"{(_values[4] == null ? " " : _values[4])}   |   {(_values[5] == null ? " " : _values[5])}   ");
            Console.WriteLine("  _______|_______|_______");
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"C    {(_values[6] == null ? " " : _values[6])}   |   " +
                              $"{(_values[7] == null ? " " : _values[7])}   |   {(_values[8] == null ? " " : _values[8])}   ");
            Console.WriteLine("         |       |       ");
        }

        private static void MakeMove()
        {
            bool isPrimary = true;
            if (_move_count % 2 != 0) isPrimary = false;
            
            if (isPrimary)
            {
                Console.WriteLine($"{_first_player} adlı oyuncunun hamlesi: ");
            }
            else
            {
                Console.WriteLine($"{_second_player} adlı oyuncunun hamlesi: ");
            }
            string input = Console.ReadLine().ToUpper().Trim();
            Console.Write("\n");
            
            if (Array.Exists(_moves, e => e == input))
            {
                // Save move -> Conditional -> _move_count
                SaveMove(input, isPrimary == true ? "X" : "O");
                // Show Table
                ShowTable();
                // Check Win Situtation
                // If continue _move_count++ -> MakeMove() **Conditional
                bool won = WinCheck();
                if (won)
                {
                    YouWon(isPrimary ? _move_count/2+1 : _move_count/2, isPrimary ? _first_player : _second_player);
                }
                else
                {
                    if (IsFullFilled()) Draw(_move_count);
                    MakeMove();
                }
            }
            else
            {
                Console.WriteLine("Hamle geçersiz lütfen tekrar dene!");
                Console.Write("\n");
                MakeMove();
            }
        }

        private static void SaveMove(string location, string value)
        {
            int locationIndex = Array.IndexOf(_moves, location);
            if (_values[locationIndex] != null)
            {
                Console.WriteLine("Hamle yapmak istediğin yer dolu, lütfen tekrar dene!");
                Console.Write("\n");
                MakeMove();
                return;
            }
            _values[locationIndex] = value;
            _move_count++;
        }

        private static bool WinCheck()
        {
            bool result =
                (_values[0] == _values[1] && _values[1] == _values[2]) && _values[0] != null
                || _values[3] == _values[4] && _values[4] == _values[5] && _values[3] != null
                || _values[6] == _values[7] && _values[7] == _values[8] && _values[6] != null
                || _values[0] == _values[3] && _values[3] == _values[6] && _values[0] != null
                || _values[1] == _values[4] && _values[4] == _values[7] && _values[1] != null
                || _values[2] == _values[5] && _values[5] == _values[8] && _values[2] != null
                || _values[0] == _values[4] && _values[4] == _values[8] && _values[0] != null
                || _values[2] == _values[4] && _values[4] == _values[6] && _values[2] != null;
            return result;
        }

        private static bool IsFullFilled()
        {
            bool res = Array.Exists(_values, el => el == null);
            return !res;
        }

        private static void YouWon(int count, string winner)
        {
            Console.Write("\n");
            Console.WriteLine($"Tebrikler {winner}, oyunu {count} hamlede kazandın!");
            string res = Controller();
            if (res == "R")
            {
                Start();   
            }
            else if (res == "Q")
            {
                Environment.Exit(0);
            }
        }
        
        private static void Draw(int count)
        {
            Console.Write("\n");
            Console.WriteLine($"Oyun bitti, berabere kaldınız! Toplam {count} hamle yapıldı.");
            string res = Controller();
            if (res == "R")
            {
                Start();   
            }
            else if (res == "Q")
            {
                Environment.Exit(0);
            }
        }

        private static void TakeNames()
        {
            Console.Write("\n");
            Console.Write("Birinci oyuncunun ismi: ");
            string f_name = Console.ReadLine().ToUpper().Trim();
            _first_player = f_name == String.Empty ? "Birinci Oyuncu" : f_name;
            Console.Write("İkinci oyuncunun ismi: ");
            string s_name = Console.ReadLine().ToUpper().Trim();
            _second_player = s_name == String.Empty ? "İkinci Oyuncu" : s_name;
            Console.Write("\n");
        }

        private static string Controller()
        {
            Console.Write("\n");
            Console.WriteLine("Tekrar oynamak için r tuşuna basın, çıkmak için q tuşuna basın.");
            string res = Console.ReadLine().ToUpper().Trim();
            if (res != "Q" && res != "R")
            {
                Controller();
            }
            return res;
        }

    }
}