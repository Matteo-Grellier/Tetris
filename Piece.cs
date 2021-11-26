namespace SourceCode;
class Piece {
    public static List<List<List<List<int>>>> shapes = new List<List<List<List<int>>>>(); //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
    public int x;
    public int y;
    public int rotate;
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
        this.rotate = 0;

        this.type = TypeOfPiece.I; //il faudra changer (système d'aléatoire)
    }
}