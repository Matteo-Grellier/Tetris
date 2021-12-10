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

    public static Grid nextPieceGrid;
    public static int difficultyDelay = 1000;
    public static Score score;
    public static int choosenDifficulty = 2;
    public static int delay;

    public static bool isEnd = false;


    public static void Init() {
        Console.WriteLine("Initialisation...");

        Piece.InitShapes(); //Initialisation du tableau de Pieces. 
        
        delay = difficultyDelay;
        isEnd = false; //on met isEnd à false (utile lors d'un retour en jeu via le bouton 'Retry' ou 'Play')

        score = new Score(choosenDifficulty); //Initialisation du Score (en fonction de la difficulté).
        grid = new Grid(width, height); //Initialisation de la grille
        
        nextPieceGrid = new Grid(6, 6); //création d'une grille pour la prochaine pièce
        nextPieceGrid.actualPiece = grid.nextPiece; //on définit la pièce actuelle de cette grille comme étant la prochaine pièce du jeu
        nextPieceGrid.nextPiece = null; //il n'y a pas de prochaine pièce (puisque c'est la grille de la prochaine pièce)
        nextPieceGrid.AddToGrid(-(grid.width/2)+2,0,0); //On place la pièce en fonction de la position dans la grille 'nextPieceGrid' (et pas en fonction de la grille 'grid')
    }

    public static void Round() {

            int offsetX = 0;
            int offsetY = 1;
            int offsetRotation = 0;

            grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

            bool isMovable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation);

            if(!isMovable) {

                Game.score.End(grid.actualPiece.y);

                Game.delay = difficultyDelay;
                Game.score.drop = "null";
                
                grid.AddToGrid(0, 0, 0); //on remet la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)
                grid.IsCompleteLine();

                grid.actualPiece = grid.nextPiece;
                grid.nextPiece = new Piece(grid.width, 2);

                nextPieceGrid.RemovePiece(); //On enlève l'ancienne 'prochaine pièce'
                nextPieceGrid.actualPiece = grid.nextPiece;
                nextPieceGrid.AddToGrid(-(grid.width/2)+2,0,0); //décalage sur le x : on enlève la taille de la grille/2 pour remettre à 0 les coordonnées, puis on ajoute 2 pour recentrer.
                grid.actualPiece.x = grid.width/2; //On remet le x à la position central de la grille (modifier lors de l'affichage de la prochaine pièce)
                
                offsetY = 0;
                offsetX = 0;
            } else {
                offsetY = 1;
                offsetX = 0;
            }

            //ici
            bool isPosable = grid.VerifyNewPosition(offsetX, offsetY, offsetRotation); //Vérification de si la NOUVELLE pièce est ajoutable (donc vérification de la fin du jeu).

            if (isPosable){
                grid.AddToGrid(offsetX, offsetY, offsetRotation); //on ajoute la pièce à sa nouvelle position.
            } else {
                isEnd = true; 
                Console.WriteLine("Game Over");
            }
    }
    
}
