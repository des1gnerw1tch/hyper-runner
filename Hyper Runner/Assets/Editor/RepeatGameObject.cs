using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class RepeatGameObject : EditorWindow
    {
        private GameObject objToRepeat;
        private float spaceBetweenRepeats; // 0 indicates gameobjects will be perfectly back to back
        private SpriteRenderer objSprite;
        private int numberOfRepeats;
        
        [MenuItem("Custom/RepeatGameObject")]
        public static void ShowWindow()
        {
            GetWindow<RepeatGameObject>("Repeat GameObject");
        }

        // Code for the window
        private void OnGUI()
        {
            GUILayout.Label("Will repeat a GameObject across the X axis");
            GUILayout.Label("Object to repeat must have SpriteRenderer");
            
            objToRepeat = (GameObject) EditorGUILayout.ObjectField("Object to repeat", objToRepeat, typeof(GameObject));
            spaceBetweenRepeats = EditorGUILayout.FloatField("Space between repeats", spaceBetweenRepeats);
            numberOfRepeats = EditorGUILayout.IntField("Number of repeats", numberOfRepeats);
            
            if (GUILayout.Button("Apply to scene"))
            {
                float width;
                if (objToRepeat.TryGetComponent(out SpriteRenderer sprite))
                {
                    width = sprite.bounds.size.x;
                }
                else
                {
                    Debug.LogError("Object to repeat did not have SpriteRenderer");
                    return;
                }
                
                
                for (int i = 0; i < numberOfRepeats; i++)
                {
                    Vector3 pos = new Vector3 (objToRepeat.transform.position.x + (width * (i + 1)) + spaceBetweenRepeats, 
                        objToRepeat.transform.position.y, 0);
                    GameObject newObj = Instantiate(objToRepeat, pos, Quaternion.identity);
                    newObj.name = objToRepeat.name + "(" + (i + 1) + ")";
                }
                Debug.Log("Objects generated.");
            }
        }
    }
}
