using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Warcaby
{


/*
  1 2 3 4 5 6 7 8 
 +-----------------+
A| | | | | | | | |
 | -+-+-+-+-+-+-+-+
B| | | | | | | | |
 | -+-+-+-+-+-+-+-+
C| | | | | | | | |
 | -+-+-+-+-+-+-+-+
D| | | | | | | | |
 +-----------------

*/


    class Board
    {
        private static Board _instance;
        private static int n; // n jest to długość boku plnszy w skoczkach
        private int[,] board_array;
        public List<Pawn> SetedPawns;
        public Pawn tmp_pawn;
        public int xd;
        public int yd;
        public int coordinate_x;
        public int coordinate_y;
        public string coordinate_left_or_right;


        private Board(int side_length)
        {
            n = side_length;
            board_array = new int[side_length, side_length];
        }



        public void PawnSet()
        {
            List<Pawn> pionki = new List<Pawn>();
            SetedPawns = new List<Pawn>();
            //x potem y
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    SetedPawns.Add(new Pawn(i, 1, false));
                }
                else
                {
                    SetedPawns.Add(new Pawn(i, 0, false));
                }
            }

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    SetedPawns.Add(new Pawn(i, n - 1, true));
                }
                else
                {
                    SetedPawns.Add(new Pawn(i, n - 2, true));
                }
            }

            /*
            SetedPawns.Add(new Pawn(0, 1, false));
            SetedPawns.Add(new Pawn(1, 0, false));
            SetedPawns.Add(new Pawn(2, 1, false));
            SetedPawns.Add(new Pawn(3, 0, false));
    
            SetedPawns.Add(new Pawn(0, n - 1, true));
            SetedPawns.Add(new Pawn(1, n - 2, true));
            SetedPawns.Add(new Pawn(2, n - 1, true));
            SetedPawns.Add(new Pawn(3, n - 2, true));
            */

            foreach (Pawn pionek in SetedPawns)
            {
                Console.Write("Pozycja x : ");
                Console.Write(value: pionek.x);
                Console.Write(" pozycja y : ");
                Console.Write(value: pionek.y);
                Console.WriteLine("");
            }
        }

        public void set_array(int[,] array_to_set)
        {
            board_array = array_to_set;
        }

        public Pawn pawn_on_position(int x_position, int y_position, List<Pawn> pionki)
        {
            foreach (Pawn pionek in pionki)
            {
                if ((pionek.x == x_position) && (pionek.y == y_position))
                {
                    return pionek;
                }
            }

            return null;
        }

        public static Board GetInstance(int side_length)
        {
            if (_instance == null)
            {
                _instance = new Board(side_length);
            }

            return _instance;
        }

        public void print_board()
        {
            //TODO: trzeba doda żeby się printowały numery wierszy i kolumn
            //Console.WriteLine("TO JEST BOARD! " + Convert.ToString(n));
            // do print board trzeba za każdym razem przekazywać listę pionków które mają być wyświetlone
            for (int y = 0; y < (n * 2 - 1); y++)
            {
                for (int x = 0; x < (n * 2 - 1); x++)
                {
                    if (y % 2 == 1)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        if (x % 2 == 1)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            if (x != 0)
                            {
                                xd = x / 2;
                            }
                            else
                            {
                                xd = 0;
                            }

                            if (y != 0)
                            {
                                yd = y / 2;
                            }
                            else
                            {
                                yd = 0;
                            }

                            tmp_pawn = pawn_on_position(xd, yd, SetedPawns);
                            if (tmp_pawn == null)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                switch (tmp_pawn.IsWhite)
                                {
                                    case true:
                                        Console.Write("W");
                                        break;
                                    case false:
                                        Console.Write("B");
                                        break;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("");
            }
        }

        public void GetCoordinates()
        {
            Console.WriteLine("Put x coordinates : ");
            coordinate_x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Put y coordinates : ");
            coordinate_y = Convert.ToInt32(Console.ReadLine());
            //TODO: trzeba sprawdzić czy koordynaty nie przekraczają szerokości tablicy i czy da się je zamienić na inta

            Console.WriteLine("Pawn should move left put l, should move right put r :");
            coordinate_left_or_right = Console.ReadLine();
            //TODO: trzeba sprawdzić czy w coordinate jest tylko litera "l" lub "r"
        }

    }
}