// ! not static !
public class Score{

    private static int[] difficultyEasy = {2, 100,300,500,1000};
    private static int[] difficultyNormal = {4, 250,750,1250,2500};
    private static int[] difficultyHard = {6, 500,1500,2500,5000};
    private static int[] difficultyExtreme = {8, 1000,3000,5000,10000};
    private static int[] difficultyPurpl = {4, 250,750,1250,2500};

    //en private !
    private static int[] selectedDifficulty;

    public int begin = 0;
    public int end = 0;

    public string drop = "null"; //null, soft, hard, 


    //player score
    public int score;

    public Score(int difficulty){

        // int[] selectedDifficulty;

        score = 0;

        LaunchDifficulty(difficulty);

    }


    //at the beginning of the game, set the difficulty
    public static void LaunchDifficulty(int difficulty){
        
        switch(difficulty){
            case 1:
                selectedDifficulty = difficultyEasy;
                break;
            case 2:
                selectedDifficulty = difficultyNormal;
                break;
            case 3:
                selectedDifficulty = difficultyHard;
                break;
            case 4:
                selectedDifficulty = difficultyExtreme;
                break;
            case 5:
                selectedDifficulty = difficultyPurpl;
                break;
            default:
                selectedDifficulty = difficultyEasy;
                break;
        }
    }

    //to launch when lines are destroyed, augment score depending on the difficulty and number of lines destroyed
    public void LinesPoints(int numberOfLines){
        score += selectedDifficulty[numberOfLines];
    }

    public void Begin(int yvalue){
        this.begin = yvalue;
    }

    public void End(int endYvalue){
        if (this.drop == "soft"){
            SoftDrop(endYvalue);

        } else if (this.drop == "hard"){
            HardDrop(endYvalue);

        }
    }

    //to launch every line when sofdropping
    public void SoftDrop(int endYvalue){
        int dif = endYvalue - this.begin;
        this.score += 2 * dif;
        Console.WriteLine("******************************************");
        Console.WriteLine("(soft) dif = " + dif);
        Console.WriteLine("(soft) score added = " + 2 * dif);
        Console.WriteLine("(soft) score = " + this.score);

    }

    //to launch when harddrop
    public void HardDrop(int endYvalue){
        int dif = endYvalue - this.begin;
        this.score += selectedDifficulty[0] * dif;
        Console.WriteLine("==========================================");
        Console.WriteLine("(hard) dif = " + dif);
        Console.WriteLine("(soft) score added = " + selectedDifficulty[0] * dif);
        Console.WriteLine("(hard) score = " + score);
    }

}