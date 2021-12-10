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

        int actualRotation = actualPiece.rotation%actualPiece.shapeOfPiece.Count; //Rotation actuelle (le modulo permet de ne pas dépasser la taille du tableau)
        int requestRotation = (actualPiece.rotation+offsetRotation)%actualPiece.shapeOfPiece.Count; //Rotation demandée 

 
        for(int k = 0; k < actualPiece.shapeOfPiece[actualRotation].Count; k++) {

            int xBox = actualPiece.x+offsetX+actualPiece.shapeOfPiece[requestRotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
            int yBox = actualPiece.y+offsetY+actualPiece.shapeOfPiece[requestRotation][k][1];

            pieces[yBox][xBox] = (int)actualPiece.type;

        }

        //On ajoute les valeurs de décalage pour mettre la position à jour
        actualPiece.x += offsetX;
        actualPiece.y += offsetY;
        actualPiece.rotation += offsetRotation;

    }

    public bool VerifyNewPosition(int offsetX, int offsetY, int offsetRotation) {

        int actualRotation = actualPiece.rotation%actualPiece.shapeOfPiece.Count; //Rotation actuelle (le modulo permet de ne pas dépasser la taille du tableau)
        int requestRotation = (actualPiece.rotation+offsetRotation)%actualPiece.shapeOfPiece.Count; //Rotation demandée
        
        for(int k = 0; k < actualPiece.shapeOfPiece[actualRotation].Count; k++) {

            int xOriginalBox = actualPiece.x+actualPiece.shapeOfPiece[actualRotation][k][0];
            int yOriginalBox = actualPiece.y+actualPiece.shapeOfPiece[actualRotation][k][1];

            int xBox = actualPiece.x+offsetX+actualPiece.shapeOfPiece[requestRotation][k][0];  //[type of figure][rotationVal][pour parcourir les cases (pour trouver leur x et y)][x ou y]
            int yBox = actualPiece.y+offsetY+actualPiece.shapeOfPiece[requestRotation][k][1];

            if(xBox < 0 || yBox < 0 || xBox >= width || yBox >= height) { //vérifier si on ne fait pas de outOfRange
                return false;

            } else if((pieces[yBox][xBox] != 0)) { 
                return false;
                
            }
        }

        return true;
    }


    public void RemovePiece() {

        int actualRotation = actualPiece.rotation%actualPiece.shapeOfPiece.Count; //Rotation actuelle (le modulo permet de ne pas dépasser la taille du tableau)
        
        for(int k = 0; k < actualPiece.shapeOfPiece[actualRotation].Count; k++) {
            
            int xOriginalBox = actualPiece.x+actualPiece.shapeOfPiece[actualRotation][k][0];
            int yOriginalBox = actualPiece.y+actualPiece.shapeOfPiece[actualRotation][k][1];

            pieces[yOriginalBox][xOriginalBox] = (int)TypeOfPiece.EMPTY;
        }
    }

    //Vérifie si la ligne est complète.
    public void IsCompleteLine() {

        int bufferSize = 0; //pour compter le nombre de case prise.

        //score
        int numberOfLines = 0;

        for(int i = 0; i < this.height; i++) { //Ligne par ligne

            bufferSize = 0;

            for(int j = 0; j < this.width; j++) { //Itération sur une ligne de chaque case.

                if(pieces[i][j] != (int)TypeOfPiece.EMPTY) {
                    bufferSize += 1;
                } else {
                    bufferSize = 0;
                }

                if(bufferSize >= this.width) { //Si le nombre de case sur la ligne est égale à la largeur.
                    this.DownAllPieces(i);
                    numberOfLines += 1;
                }
            }
        }

        if (numberOfLines > 0) {
            Game.score.LinesPoints(numberOfLines);
        }

    }

    //Permet de descendre toutes les pièces du haut.
    public void DownAllPieces(int index) {
        this.pieces.RemoveAt(index); //On enlève la ligne qui est pleine
        
        List<int> line = new List<int>();

        for(int j = 0; j < this.width; j++) {
            line.Add((int)TypeOfPiece.EMPTY);
        }
        pieces.Insert(0, line); //On ajoute au tableau, une nouvelle ligne vide (tout en haut).
    }

}
