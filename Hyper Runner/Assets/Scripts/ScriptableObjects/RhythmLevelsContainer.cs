using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// Holds the scenes of all of the rhythm levels in the game.
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RhythmLevelContainerScriptableObject", order = 1)]
    public class RhythmLevelsContainer : ScriptableObject
    {
        [SerializeField] private List<string> rhythmLevels;

        public List<string> GetAllRhythmLevelScenes() => new List<string>(rhythmLevels);
    }
}
