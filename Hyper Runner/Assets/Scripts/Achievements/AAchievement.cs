using UnityEngine;

namespace Achievements
{
    /// <summary>
    /// Base class for all achievements to be made in the game. Achievements should have data, and also should have some type of listener to
    /// update the achievement data when progress is made. 
    /// </summary>
    public abstract class AAchievement : MonoBehaviour
    {
        [SerializeField] private AchievementData data;

        public AchievementData GetAchievementData() => data;

    }
}
