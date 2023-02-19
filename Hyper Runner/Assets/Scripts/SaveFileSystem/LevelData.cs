namespace SaveFileSystem
{
    /**
     * Data for a level. Will store high score for now, wonder what else we could store here?
     */
    [System.Serializable]
    public class LevelData
    {
        public LevelGrade highScore;

        public LevelData()
        {
            highScore = LevelGrade.NeverCompleted;
        }
    }

    public enum LevelGrade
    {
        P,
        A,
        B,
        C,
        F,
        NeverCompleted
    }
}
