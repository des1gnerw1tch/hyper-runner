using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

//Modified by Kristian Helle Jespersen
//June 2011

// Modified by Zachary Walker-Liang
// August 2021

namespace Editor
{
    public class ReplaceGameObjects : ScriptableWizard
    {
        public bool copyValues = true;
        public GameObject[] NewType;
        public GameObject[] OldObjects;

        [MenuItem("Custom/Replace GameObjects")]


        static void CreateWizard()
        {
            ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
        }

        void OnWizardCreate()
        {
            //Transform[] Replaces;
            //Replaces = Replace.GetComponentsInChildren<Transform>();

            foreach (GameObject go in OldObjects)
            {
                GameObject newObject;
                int rand = Random.Range(0, NewType.Length);
                newObject = (GameObject) PrefabUtility.InstantiatePrefab(NewType[rand]);
                newObject.SetActive(go.activeSelf); // will disable new prefab object if needed
                newObject.transform.position = go.transform.position;
                newObject.transform.rotation = go.transform.rotation;
                newObject.transform.parent = go.transform.parent;

                DestroyImmediate(go);

            }

            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());

        }
    }
}