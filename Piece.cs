using System;

namespace SourceCode;
public class Piece {
    public static List<List<List<List<int>>>> shapes = new List<List<List<List<int>>>>(); //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
    public int x;
    public int y;
    public int rotation;
    public TypeOfPiece type; //changer la valeur dans le constructeur (aléatoire)
    public List<List<List<int>>> shapeOfPiece; //changer la valeur dans le constructeur (aléatoire)
    

    public static void InitShapes() {

        //I 1
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,2}, new List<int>(){0,1}, new List<int>(){0,0},  new List<int>(){0,-1}}, 
            new List<List<int>>(){new List<int>(){2,0}, new List<int>(){1,0}, new List<int>(){0,0},  new List<int>(){-1,0}},
        });

        //J 2
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,1}, new List<int>(){0,0}, new List<int>(){0,-1},  new List<int>(){-1,-1}},
            new List<List<int>>(){new List<int>(){-1,0}, new List<int>(){0,0}, new List<int>(){1,0},  new List<int>(){1,-1}},
            new List<List<int>>(){new List<int>(){1,1}, new List<int>(){0,1}, new List<int>(){0,0},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){-1,1}, new List<int>(){-1,0}, new List<int>(){0,0},  new List<int>(){1,0}},
        });

        //L 3
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,1}, new List<int>(){0,0}, new List<int>(){0,-1},  new List<int>(){-1,1}},
            new List<List<int>>(){new List<int>(){-1,0}, new List<int>(){0,0}, new List<int>(){1,0},  new List<int>(){-1,-1}},
            new List<List<int>>(){new List<int>(){1,-1}, new List<int>(){0,1}, new List<int>(){0,0},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){1,1}, new List<int>(){-1,0}, new List<int>(){0,0},  new List<int>(){1,0}},
        });

        //Z 4
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){1,-1}, new List<int>(){0,-1}, new List<int>(){0,0},  new List<int>(){-1,0}},
            new List<List<int>>(){new List<int>(){1,0}, new List<int>(){0,0}, new List<int>(){1,1},  new List<int>(){0,-1}},
        });

        //S 5
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,1}, new List<int>(){1,0}, new List<int>(){0,0},  new List<int>(){1,-1}},
            new List<List<int>>(){new List<int>(){1,0}, new List<int>(){0,0}, new List<int>(){0,-1},  new List<int>(){-1,-1}},
        });

        //o 6
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){0,-1},  new List<int>(){1,-1}},
        });

        //T 7
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){-1,0},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){0,1},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){-1,0},  new List<int>(){0,1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){-1,0}, new List<int>(){0,1},  new List<int>(){0,-1}},
        });

    }

    public Piece(int x, int y) {
        this.x = (x / 2); //(Game.grid.width / 2);
        this.y = y;
        this.rotation = 0;

        this.type = RandomTypeOfPiece(); //il faudra changer (système d'aléatoire)

        // Console.WriteLine("type : " + (int)this.type);

        this.shapeOfPiece = shapes[(int)this.type-1];
    }

    public TypeOfPiece RandomTypeOfPiece() {
        Random rnd = new Random();
        int number  = rnd.Next(0, shapes.Count);


        return (TypeOfPiece)number+1;
    }

    public void TurnPiece(){

        int offsetRotation =  0;

        if (shapeOfPiece.Count == 4) {

            if (this.rotation == 3 ){
                offsetRotation = -3;

            } else {
                offsetRotation = 1;
            }

        } else if (shapeOfPiece.Count == 2) {

            if (this.rotation == 1 ) {
                offsetRotation = -1;


            } else {
                offsetRotation = 1;
            }

        } else {
            offsetRotation = 0;
        }

        Game.grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

        bool isMovable = Game.grid.VerifyNewPosition(0, 0, offsetRotation); //verif si on peux la apositionner à rotation + 1

        if(!isMovable) {
            Game.grid.AddToGrid(0, 0, 0); //on ajoute la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)


        } else {
            Game.grid.AddToGrid(0, 0, offsetRotation); //on ajoute la pièce à sa nouvelle position.

        }
    }

    public void ToSide(int dirX) {
        Console.WriteLine(dirX);

        Game.grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

        bool isMovable = Game.grid.VerifyNewPosition(dirX, 0, 0);

        if(!isMovable) {
            Game.grid.AddToGrid(0, 0, 0);
        } else {
            Game.grid.AddToGrid(dirX, 0, 0);
        }
    }

    public void Drop(int newDelay) {
        
        if (newDelay == 100){
            Game.score.drop = "soft";
            Game.score.Begin(this.y);

        } else if (newDelay == 0){
            Game.score.drop = "hard";
            Game.score.Begin(this.y);


        } else if (newDelay == 1000){
            Game.score.End(this.y);
            Game.score.drop = "null";

        }
        Game.delay = newDelay;
    }

}