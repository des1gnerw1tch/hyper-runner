using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Handles bringing up Achievements UI window. Updates achievement UI elements when window is brought up
    /// </summary>
    public class AchievementsUIHelper : MonoBehaviour
    {
        private AchievementUIElement[] achievementUIElements;

        public static AchievementsUIHelper Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        private void Start()
        {
            achievementUIElements = FindObjectsOfType<AchievementUIElement>(true);
        }
        
        public void UpdateContent()
        {
            foreach (AchievementUIElement element in achievementUIElements)
            {
                element.UpdateContent();
            }
        }
    }
}
