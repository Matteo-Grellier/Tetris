using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace SourceCode;

public class Game {

    private static int _height = 20;
    private static int _width = 10;
    
    [Required]
    public static int width { get => _width; set {_width = value;}}
    [Required]
    public static int height { get => _height; set {_height = value;}}

    public static Grid grid;
    public static int difficultyDelay = 1000;
    public static Score score;
    public static int choosenDifficulty = 0;
    public static int delay;

    public static bool isEnd = false;


    public static void Init() {
        Console.WriteLine("Initialisation...");

        Piece.InitShapes(); //il faudra absolument réinitialisé le tableau (car quand on recharge la page, cette méthode est appelé) 
        
        delay = difficultyDelay;

        score = new Score(choosenDifficulty);

        grid = new Grid(width, height);
        Console.WriteLine(delay);

        // Score.score = 0;
    }

    // public static async Task Round() { //il faudra trouver une autre solution pour le Delay

    //     Console.WriteLine("I launch the game !");

    //     // var delay = 1000;

    //     while(!isEnd) {
    //         await Task.Delay(delay);

    //         int offsetX = 0;
    //         int offsetY = 1;
    //         int offsetRotation = 0;

    //         grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

    //         bool isMovable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

    //         if(!isMovable) {


    //             Game.score.End(grid.actualPiece.y);

    //             Game.delay = difficultyDelay;
    //             Game.score.drop = "null";

                
    //             grid.AddToGrid(0, 0, 0); //on ajoute la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)
    //             grid.IsCompleteLine();

    //             grid.actualPiece = grid.nextPiece;
    //             grid.nextPiece = new Piece(grid.width, 2);

    //             offsetY = 0;
    //             offsetX = 0;

    //             // Console.WriteLine("Fin de la pièce, début de la nouvelle");
    //         } else {
    //             offsetY = 1;
    //             offsetX = 0;


    //             // Console.WriteLine("nouvelle position pour la pièce !");
    //             // Console.WriteLine("size : " + grid.pieces.Count);
    //             // Console.WriteLine("x and y : " + grid.actualPiece.x + " " + grid.actualPiece.y);
    //         }

    //         //ici
    //         bool isPosable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

    //         if (isPosable){
    //             grid.AddToGrid(offsetX, offsetY, offsetRotation); //on ajoute la pièce à sa nouvelle position.

    //         } else {
    //             isEnd = true; 
    //             Console.WriteLine("HAHA NOOB YOU FAILLLLLLED");

    //         }
            

    //     }
    // }

    public static void Round() { //il faudra trouver une autre solution pour le Delay

        Console.WriteLine("I launch the game !");

        // var delay = 1000;

            int offsetX = 0;
            int offsetY = 1;
            int offsetRotation = 0;

            grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

            bool isMovable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

            if(!isMovable) {


                Game.score.End(grid.actualPiece.y);

                Game.delay = difficultyDelay;
                Game.score.drop = "null";

                
                grid.AddToGrid(0, 0, 0); //on ajoute la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)
                grid.IsCompleteLine();

                grid.actualPiece = grid.nextPiece;
                grid.nextPiece = new Piece(grid.width, 2);

                offsetY = 0;
                offsetX = 0;

                // Console.WriteLine("Fin de la pièce, début de la nouvelle");
            } else {
                offsetY = 1;
                offsetX = 0;


                // Console.WriteLine("nouvelle position pour la pièce !");
                // Console.WriteLine("size : " + grid.pieces.Count);
                // Console.WriteLine("x and y : " + grid.actualPiece.x + " " + grid.actualPiece.y);
            }

            //ici
            bool isPosable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

            if (isPosable){
                grid.AddToGrid(offsetX, offsetY, offsetRotation); //on ajoute la pièce à sa nouvelle position.

            } else {
                isEnd = true; 
                Console.WriteLine("HAHA NOOB YOU FAILLLLLLED");

            }
    }
    
}
