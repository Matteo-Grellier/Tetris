// ! not static !
public class Score{

    private static int[] difficultyEasy = {1, 100,300,500,1000};
    private static int[] difficultyNormal = {2, 250,750,1250,2500};
    private static int[] difficultyHard = {4, 500,1500,2500,5000};
    private static int[] difficultyExtreme = {6, 1000,3000,5000,10000};
    private static int[] difficultyPurpl = {2, 250,750,1250,2500};

    //en private !
    private static int[] selectedDifficulty;

    //player score
    public static int score;

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
    public static void LinesPoints(int numberOfLines){
        score += selectedDifficulty[numberOfLines];
    }

    //to launch every line when sofdropping
    public static void SoftDrop(){
        score += selectedDifficulty[0];
    }

    //to launch when harddrop
    public static void HardDrop(int startLine, int stopLine){
        score += (stopLine - startLine) * 2;
    }

}