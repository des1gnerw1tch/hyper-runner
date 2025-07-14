namespace SaveFileSystem
{
    /**
     * Data for a level. Will store high score for now, wonder what else we could store here?
     */
    [System.Serializable]
    public class LevelData
    {
        public LevelGrade highScore;
        public bool isBossLevelBeaten;

        public LevelData()
        {
            highScore = LevelGrade.NeverCompleted;
            isBossLevelBeaten = false;
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
