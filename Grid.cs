using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SourceCode;
public class Grid {
    public List<List<int>> pieces = new List<List<int>>();

    public int width;
    public int height;

    public Piece actualPiece;
    public Piece nextPiece;

 
    
    public Grid(int width, int height) {
        this.actualPiece = new Piece();
        this.nextPiece = new Piece();
        this.width = width;
        this.height = height;


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
    public void AddToGrid(int offsetX, int offsetY, int offsetRotation) {

 
        for(int k = 0; k < actualPiece.shapeOfPiece[actualPiece.rotation].Count; k++) {

            int xBox = actualPiece.x+offsetX+actualPiece.shapeOfPiece[actualPiece.rotation+offsetRotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
            int yBox = actualPiece.y+offsetY+actualPiece.shapeOfPiece[actualPiece.rotation+offsetRotation][k][1];

            Console.WriteLine("new : " + xBox + " " + yBox);

            pieces[yBox][xBox] = (int)actualPiece.type;

        }

        actualPiece.x += offsetX;
        actualPiece.y += offsetY;
        actualPiece.rotation += offsetRotation;

    }

    public bool VerifyNewPosition(int offsetX, int offsetY, int offsetRotation) {
        
        for(int k = 0; k < actualPiece.shapeOfPiece[actualPiece.rotation].Count; k++) {

            int xOriginalBox = actualPiece.x+actualPiece.shapeOfPiece[actualPiece.rotation][k][0];
            int yOriginalBox = actualPiece.y+actualPiece.shapeOfPiece[actualPiece.rotation][k][1];

            int xBox = actualPiece.x+offsetX+actualPiece.shapeOfPiece[actualPiece.rotation+offsetRotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
            int yBox = actualPiece.y+offsetY+actualPiece.shapeOfPiece[actualPiece.rotation+offsetRotation][k][1];

            if(xBox < 0 || yBox < 0 || xBox >= width || yBox >= height) {
                return false;

            } else if((pieces[yBox][xBox] != 0)) { //vérifier si on ne fait pas de outOfRange

                return false;
            }
        }

        return true;
    }


    public void RemovePiece() {
        
        for(int k = 0; k < actualPiece.shapeOfPiece[actualPiece.rotation].Count; k++) {
            
            int xOriginalBox = actualPiece.x+actualPiece.shapeOfPiece[actualPiece.rotation][k][0];
            int yOriginalBox = actualPiece.y+actualPiece.shapeOfPiece[actualPiece.rotation][k][1];

            pieces[yOriginalBox][xOriginalBox] = (int)TypeOfPiece.EMPTY;

            Console.WriteLine("DELETE original : " + xOriginalBox + " " + yOriginalBox);

        }
    }

}
