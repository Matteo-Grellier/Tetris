using System.Threading;

namespace SourceCode;
class Game {

    public static Grid grid;

    public static int score;

    public static bool isEnd = false;

    public static void Init() {
        Console.WriteLine("Initialisation...");

        Piece.InitShapes(); //il faudra absolument réinitialisé le tableau (car quand on recharge la page, cette méthode est appelé)

        grid = new Grid();

        score = 0;
    }

    public static async Task LaunchGame() {

        Console.WriteLine("I launch the game !");

        var delay = 1000;

        while(!isEnd) {
            await Task.Delay(delay);

            // Thread.Sleep(delay);

            bool isMovable = grid.VerifyNewPosition(grid.actualPiece.x, grid.actualPiece.y+1, grid.actualPiece.rotation);

            if(!isMovable) {
                grid.actualPiece = grid.nextPiece;
                grid.nextPiece = new Piece();

                // grid.actualPiece = new Piece();

                Console.WriteLine("Fin de la pièce, début de la nouvelle");
            } else {
                grid.actualPiece.y += 1;
                Console.WriteLine("nouvelle position pour la pièce !");
                Console.WriteLine("size : " + grid.pieces.Count);
                Console.WriteLine("x and y : " + grid.actualPiece.x + " " + grid.actualPiece.y);
            }


            grid.AddToGrid();

        }
    }
}
