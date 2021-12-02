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

}