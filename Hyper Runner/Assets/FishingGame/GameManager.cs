using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// Start is called before the first frame update
	void Start () {
		Debug.Log("Hello?");
		FindObjectOfType<AudioManager> ().Play ("theme");
		FindObjectOfType<AudioManager> ().Play ("welcome");
	}
}
