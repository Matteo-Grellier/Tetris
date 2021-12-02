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
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){-1,0},  new List<int>(){0,1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){0,1},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){1,0}, new List<int>(){-1,0},  new List<int>(){0,-1}},
            new List<List<int>>(){new List<int>(){0,0}, new List<int>(){-1,0}, new List<int>(){0,1},  new List<int>(){0,-1}},

            
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


        Console.WriteLine("==========================");
        Console.WriteLine("shapes : " + shapes.Count);


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
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("buenos dos");

            if (this.rotation == 1 ) {
                offsetRotation = -1;
                Console.WriteLine("this.rotation = " + this.rotation);
                Console.WriteLine("offsetRotation = " + offsetRotation);


            } else {
                offsetRotation = 1;
                Console.WriteLine("ma quéééééééééééééé ?????????????????????");
            }

        } else {
            offsetRotation = 0;
        }



        // // 4 positions
        // if ( shapeOfPiece == shapes[1] || shapeOfPiece == shapes[2] || shapeOfPiece == shapes[6]) { 
        //     if (this.rotation == 3 ){
        //         offsetRotation = -3;

        //     } else {
        //         offsetRotation = 1;
        //     }

        // // 2 positions
        // } else if ( shapeOfPiece == shapes[0] || shapeOfPiece == shapes[3] || shapeOfPiece == shapes[4]) {
        //     if (this.rotation == 1 ){
        //         offsetRotation = -1;

        //     } else {
        //         offsetRotation = 1;
        //     }

        // // 1 positions
        // } else if ( shapeOfPiece == shapes[5] ) {
        //     offsetRotation = 0;

        // }

        // int offsetRotation = 1;

        Game.grid.RemovePiece(); //on enlève la pièce actuelle pour vérifier la nouvelle position (pour éviter les conflits).

        bool isMovable = Game.grid.VerifyNewPosition(0, 0, offsetRotation); //verif si on peux la apositionner à rotation + 1

        if(!isMovable) {
            Game.grid.AddToGrid(0, 0, 0); //on ajoute la pièce actuel à sa dernière position (avant de mettre la prochaine pièce)


        } else {
            Game.grid.AddToGrid(0, 0, offsetRotation); //on ajoute la pièce à sa nouvelle position.

        }
    }
}