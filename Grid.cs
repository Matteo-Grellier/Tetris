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

        this.width = width;
        this.height = height;
        
        this.actualPiece = new Piece(width, 2);
        this.nextPiece = new Piece(width, 2);


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

            if(xBox < 0 || yBox < 0 || xBox >= width || yBox >= height) { //vérifier si on ne fait pas de outOfRange
                return false;

            } else if((pieces[yBox][xBox] != 0)) { 
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

    public void IsCompleteLine() {

        int bufferSize = 0;

        for(int i = 0; i < this.height; i++) {

            bufferSize = 0;

            for(int j = 0; j < this.width; j++) {

                if(pieces[i][j] != (int)TypeOfPiece.EMPTY) {
                    bufferSize += 1;
                } else {
                    bufferSize = 0;
                }

                if(bufferSize >= this.width) {
                    this.DownAllPieces(i);
                }
            }
        }
    }

    public void DownAllPieces(int index) {
        this.pieces.RemoveAt(index);
        
        List<int> line = new List<int>();

        for(int j = 0; j < this.width; j++) {
            line.Add((int)TypeOfPiece.EMPTY);
        }

         pieces.Insert(0, line);
    }

}
