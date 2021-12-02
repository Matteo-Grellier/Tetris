namespace SourceCode;

class Menu {

    
    public static void Play() {
        Game.Init();

        Piece.InitShapes();

        Game.LaunchGame();
    }

    public static void Options() {

    }

    public static void Credits() {

    }

    public static void Quit() {
        
    }
}