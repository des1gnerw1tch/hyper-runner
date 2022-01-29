using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class RepeatGameObject : EditorWindow
    {
        [SerializeField] private GameObject objToRepeat;

        [SerializeField] private float spaceBetweenRepeats;

        [SerializeField] private SpriteRenderer objSprite;
        [SerializeField] private int numberOfRepeats;
        
        [MenuItem("Custom/RepeatGameObject")]
        public static void ShowWindow()
        {
            GetWindow<RepeatGameObject>("Repeat GameObject");
        }

        // Code for the window
        private void OnGUI()
        {
            GUILayout.Label("Will repeat a GameObject across the X axis");
            if (GUILayout.Button("Apply to scene"))
            {
                float width = objSprite.bounds.size.x;
                for (int i = 0; i < numberOfRepeats; i++)
                {
                    Vector3 pos = new Vector3 (objToRepeat.transform.position.x + (width * (i + 1)) + spaceBetweenRepeats, 
                        objToRepeat.transform.position.y, 0);
                    GameObject newObj = Instantiate(objToRepeat, pos, Quaternion.identity);
                    newObj.name = objToRepeat.name + "(" + i + 1 + ")";
                }
                Debug.Log("Objects generated.");
            }
        }
    }
}
