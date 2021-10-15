using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This loads the arcade scene setup once scene entered. If the scene is entered from a previous arcade game
// scene, it should play respective animation and it should put player in respective spot...
public class LoadArcadeScene : MonoBehaviour {
    private Transform startGamePos; // where player should start when game starts

    private Transform machine1Pos; // first machine position to spawn player at
    private GameObject machine1Cam;
    private Animator machine1ExitAnimation; // first machine exit animation 

    private GameObject player; // player of the game
    private GameObject playerCam;

    public static string sceneFrom; // what level did the player come from? 
    // Start is called before the first frame update
    void Start() {
        /*if (sceneFrom.Equals("Lvl_Nightlife")) {
            this.player.transform.position = new Vector3(machine1Pos.position.x, machine1Pos.position.y,
                machine1Pos.position.z);
            this.playerCam.SetActive(false);
            this.machine1Cam.SetActive(true);
        }*/
    }

    // Update is called once per frame
    void Update() {

    }
}
