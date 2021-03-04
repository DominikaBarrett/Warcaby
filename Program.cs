namespace Warcaby
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Pawn tmp_pawn;
            Game game = new Game();

            int n = game.Start();
            Board board_instance = Board.GetInstance(n);
            board_instance.PawnSet();
            board_instance.print_board();
            board_instance.GetCoordinates();
            tmp_pawn = board_instance.pawn_on_position(board_instance.coordinate_x, board_instance.coordinate_y, board_instance.SetedPawns);

            game.TryToMakeMove(tmp_pawn);
        }
    }
}