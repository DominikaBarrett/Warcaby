using System;
using System.Collections.Generic;
using System.Text;

namespace Warcaby
{
    

    class Game
    {
        private static Game _instance;

        public Game get_instance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }

            return _instance;
        }

        public int Start()
        {
            Console.WriteLine("Game begins");
            // należy pobrać wielkość planszy board_size między 4 a 20 i utworzyć instancję board z parametrem
            Console.WriteLine("Put width of board size between 4-20");
            int n = Convert.ToInt32(Console.ReadLine());
            //TODO: check if n is between 4 and 20 and is int
            return n;
        }

        public void Round()
        {
        }

        public void TryToMakeMove(Pawn pawn)
        {

        }

        public void CheckForWinnerOrDraw()
        {

        }
    }
}