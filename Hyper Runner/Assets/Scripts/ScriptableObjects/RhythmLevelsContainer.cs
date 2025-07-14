using System.Collections.Generic;
using UnityEngine;
using CustomDataTypes;

namespace ScriptableObjects
{
    /// <summary>
    /// Holds the scenes of all of the rhythm levels in the game.
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RhythmLevelContainerScriptableObject", order = 1)]
    public class RhythmLevelsContainer : ScriptableObject
    {
        [SerializeField] private List<string> rhythmLevelsSceneNames;
        
        // Boss fights correspond directly with rhythm levels, in order. 
        [SerializeField] private List<string> bossFightsSceneNames;

        private BidirectionalDictionary<string, string> rhythmLevelToBossFight;

        private void OnEnable()
        {
            rhythmLevelToBossFight = new BidirectionalDictionary<string, string>(this.rhythmLevelsSceneNames, this.bossFightsSceneNames);
        }

        public List<string> GetAllRhythmLevelScenes() => new List<string>(rhythmLevelsSceneNames);

        public string GetRhythmLevelNameFromBossFightName(string rhythmLevelSceneName)
        {
            return rhythmLevelToBossFight.getKeyFromValue(rhythmLevelSceneName);
        }

        public string GetBossFightNameFromRhythmLevelName(string bossFightSceneName)
        {
            return rhythmLevelToBossFight.getValueFromKey(bossFightSceneName);
        }
    }
}
