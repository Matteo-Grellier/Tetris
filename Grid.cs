using System;
using System.Collections.Generic;

namespace SourceCode;
class Grid {

    public List<List<int>> pieces = new List<List<int>>();

    public int width;
    public int height;

    public Piece actualPiece;
    public Piece nextPiece;

    public Grid() {
        this.actualPiece = new Piece();
        this.nextPiece = new Piece();
        this.width = 10;
        this.height = 20;

        InitGrid();
    }

    private void InitGrid() {

        for(int i = 0; i < this.height; i++) {
            List<int> column = new List<int>();

            for(int j = 0; j < this.width; j++) {
                column.Add((int)TypeOfPiece.EMPTY);
            }

            pieces.Add(column);
        }
    }

    public void AddToGrid() {
                
        for(int k = 0; k < actualPiece.shapeOfPiece[actualPiece.rotation].Count; k++) {
            // if(j+actualPiece.x == Piece.shapes[0][0][0][k]) {
            //     grid[i][j+actualPiece.x] = (int)actualPiece.type;
            // }

            int xPiece = actualPiece.x+actualPiece.shapeOfPiece[actualPiece.rotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]

            int yPiece = actualPiece.y+actualPiece.shapeOfPiece[actualPiece.rotation][k][1];

            if(xPiece >= 0 && yPiece >= 0 && xPiece < width && yPiece < height) { //&& la valeur de la case de la grid = 0
                pieces[yPiece][xPiece] = (int)actualPiece.type;
            } else {
                return;     //pour que ca marche, il faudra peut etre un new tableau.
            }

        }

    }

    // public bool IsMovableDown() {
    //     int requestedY = actualPiece.y + 1;

    //     for(int i = 0; i < pieces.Count; i++) {

    //     }
    // }

    public bool VerifyNewPosition(int requestedX, int requestedY, int requestedRotation) {
        for(int k = 0; k < actualPiece.shapeOfPiece[actualPiece.rotation].Count; k++) {

            int xPiece = actualPiece.x+actualPiece.shapeOfPiece[actualPiece.rotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]

            int yPiece = actualPiece.y+actualPiece.shapeOfPiece[actualPiece.rotation][k][1];

            // if(xPiece >= 0 && yPiece >= 0 && xPiece < width && yPiece < height) { //&& la valeur de la case de la grid = 0
            //     pieces[xPiece][yPiece] = (int)actualPiece.type;
            // } else {
            //     return;     //pour que ca marche, il faudra peut etre un new tableau.
            // }

            if(xPiece < 0 || yPiece < 0 || xPiece >= width || yPiece >= height) {
                return false;
            }
            // } else if(pieces[yPiece][xPiece] != 0) { //vérifier si on ne fait pas de outOfRange
            //     return false;
            // }
        }

        return true;
    }

}
