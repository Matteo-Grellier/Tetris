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

}
