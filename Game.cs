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

    public static async Task Round() { //il faudra trouver une autre solution pour le Delay

        Console.WriteLine("I launch the game !");

        var delay = 1000;

        while(!isEnd) {
            await Task.Delay(delay);

            int offsetX = 0;
            int offsetY = 1;
            int offsetRotation = 0;

            grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

            bool isMovable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

            if(!isMovable) {
                
                grid.AddToGrid(0, 0, 0); //on ajoute la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)


                grid.actualPiece = grid.nextPiece;
                grid.nextPiece = new Piece();

                offsetY = 0;
                offsetX = 0;

                Console.WriteLine("Fin de la pièce, début de la nouvelle");
            } else {
                offsetY = 1;
                offsetX = 0;


                Console.WriteLine("nouvelle position pour la pièce !");
                Console.WriteLine("size : " + grid.pieces.Count);
                Console.WriteLine("x and y : " + grid.actualPiece.x + " " + grid.actualPiece.y);
            }

            grid.AddToGrid(offsetX, offsetY, offsetRotation); //on ajoute la pièce à sa nouvelle position.

        }
    }
    
}