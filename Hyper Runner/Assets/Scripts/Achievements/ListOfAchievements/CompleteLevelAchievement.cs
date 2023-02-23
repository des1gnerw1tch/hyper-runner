using SaveFileSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Achievements.ListOfAchievements
{
    /**
     * An Achievement that deals with completing a level. Will check to complete achievement when a scene is loaded. 
     */
    public class CompleteLevelAchievement : AAchievement
    {
        // Scene name of the rhythm level to complete. This scene string should be in the RhythmLevelsContainer. 
        [SerializeField] private string rhythmLevelToComplete;
        [SerializeField] private LevelGrade minimumGradeToScore;
        public void Start()
        {
            CheckIfCompleted();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (achievement.completed)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                return;
            }
            
            CheckIfCompleted();
        }

        private void CheckIfCompleted()
        {
            LevelGrade? grade = GameDataManager.Instance.GetLevelHighScore(rhythmLevelToComplete);
            if (grade.HasValue && grade <= minimumGradeToScore)
            {
                CompleteAchievement();
            }
        }
    }
}
