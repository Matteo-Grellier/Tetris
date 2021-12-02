using System;

namespace SourceCode;
class Piece {
    public static List<List<List<List<int>>>> shapes = new List<List<List<List<int>>>>(); //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
    public int x;
    public int y;
    public int rotation;
    public TypeOfPiece type; //changer la valeur dans le constructeur (aléatoire)
    public List<List<List<int>>> shapeOfPiece; //changer la valeur dans le constructeur (aléatoire)

    public static void InitShapes() {
        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){0,2}, new List<int>(){0,1}, new List<int>(){0,0}, new List<int>(){0,-1}}, 
            new List<List<int>>(){new List<int>(){2,0}, new List<int>(){1,0}, new List<int>(){0,0}, new List<int>(){-1,0}}
        });

        shapes.Add(new List<List<List<int>>>() {
            new List<List<int>>(){new List<int>(){-1,1}, new List<int>(){-1,0}, new List<int>(){0,0},  new List<int>(){1,0}},
            new List<List<int>>(){new List<int>(){1,1}, new List<int>(){0,1}, new List<int>(){0,0},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){1,-1}, new List<int>(){0,-1}, new List<int>(){0,0},  new List<int>(){-1,0}},
            new List<List<int>>(){new List<int>(){0,1}, new List<int>(){0,0}, new List<int>(){0,-1},  new List<int>(){-1,-1}},
        });
    }

    public Piece() {
        this.x = 2;
        this.y = 2;
        this.rotation = 0;

        this.type = RandomTypeOfPiece(); //il faudra changer (système d'aléatoire)

        Console.WriteLine("type : " + (int)this.type);

        this.shapeOfPiece = shapes[(int)this.type-1];
    }

    public TypeOfPiece RandomTypeOfPiece() {
        Random rnd = new Random();
        int number  = rnd.Next(0, shapes.Count);

        Console.WriteLine("shapes : " + shapes.Count);

        return (TypeOfPiece)number+1;
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

}