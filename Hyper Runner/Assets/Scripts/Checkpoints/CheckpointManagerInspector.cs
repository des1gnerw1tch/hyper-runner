using UnityEditor;
using UnityEngine;

namespace Checkpoints
{
    /// <summary>
    /// Custom inspector for the CheckpointManager class.
    /// </summary>
    [CustomEditor(typeof(CheckpointManager))]
    public class CheckpointManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            CheckpointManager checkpointManager = (CheckpointManager) target;
            
            
            
            if (GUILayout.Button("Find and Sort Checkpoints by X position"))
            {
                checkpointManager.UpdateCheckpoints();
                
                // Set dirty is interesting function. It marks this object as "dirty" so unity editor will allow you to save the changes.
                EditorUtility.SetDirty(target);
            }
        }
    }
}
