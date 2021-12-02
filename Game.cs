using System.ComponentModel.DataAnnotations;
namespace SourceCode;

public class Game {
    
    [Range(1, 30, ErrorMessage = "WTF BRO, POURQUOI AUTANT.")]
    public static int width { get; set;}
    [Range(1, 30, ErrorMessage = "WTF BRO, POURQUOI AUTANT.")]
    public static int height { get; set;}

    public static Grid grid;
    
    public static int score;

    

    public static void Init() {
        Console.WriteLine("Initialisation...");

        Console.WriteLine(width);
        grid = new Grid(width,height);

        

        score = 0;
    }

    public static void LaunchGame() {
        
    }
    
}
