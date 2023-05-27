using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// For the SpinNWin machine, this maps a material to its corresponding multiplier. 
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpinNWinMaterialToRewardContainerScriptableObject", order = 1)]
    public class SpinNWinMaterialToReward : ScriptableObject
    {
        [System.Serializable]
        private struct MaterialToTokenReward
        {
            public Material mat;
            public int tokenMultiplier;
            
            public MaterialToTokenReward(Material mat, int tokenMultiplier)
            {
                this.mat = mat;
                this.tokenMultiplier = tokenMultiplier;
            }
        }

        [SerializeField] private List<MaterialToTokenReward> materialsToReward;
        
        public int? GetMultiplierFromMaterial(Material mat)
        {
            Debug.Log(mat.name);
            foreach (MaterialToTokenReward reward in materialsToReward)
            {
                if (mat.name == (reward.mat.name + " (Instance)"))
                {
                    return reward.tokenMultiplier;
                }
            }
            Debug.LogError("Material was not found in SpinNWinMaterialToReward scriptable object.");
            return null;
        }
    }

    
}
