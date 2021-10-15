using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This loads the arcade scene setup once scene entered. If the scene is entered from a previous arcade game
// scene, it should play respective animation and it should put player in respective spot...
public class LoadArcadeScene : MonoBehaviour {
    [SerializeField] private Transform startGamePos; // where player should start when game starts

    [SerializeField] private Transform machine1Pos; // first machine position to spawn player at
    [SerializeField] private GameObject machine1Cam;

    [SerializeField] private Animator machine1CamAnimation; // first machine exit animation 

    [SerializeField] private GameObject player; // player of the game
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject playerCamHolder;

    public static string sceneFrom; // what level did the player come from? 
    // Start is called before the first frame update
    void Start() {
        if (sceneFrom != null && sceneFrom.Equals("Lvl_Nightlife")) {
            this.player.transform.position = new Vector3(machine1Pos.position.x, machine1Pos.position.y,
                machine1Pos.position.z);

            //TODO: ROTATION DOES NOT WORK 
            // to Fix, all rotation stuff should be set in FirstPersonCameraController

            /*this.player.transform.eulerAngles = new Vector3(machine1Pos.eulerAngles.x, machine1Pos.eulerAngles.y,
                machine1Pos.eulerAngles.z);
            this.playerCamHolder.transform.eulerAngles = new Vector3(machine1Pos.eulerAngles.x, machine1Pos.eulerAngles.y,
                machine1Pos.eulerAngles.z);*/

            /*this.player.transform.rotation = Quaternion.Euler(0, 180, 0);
            this.playerCamHolder.transform.rotation = Quaternion.Euler(0, 180, 0);*/

            this.player.SetActive(false);
            this.playerCam.SetActive(false);
            this.machine1Cam.SetActive(true);
            this.machine1CamAnimation.SetTrigger("PanOutOfMachine");
        }
    }

    // when after exiting game, once animation camera is done animating, this is called
    // Called in panCamOFfMachine.cs
    public void PanCamOffMachineFinished() {
        this.machine1Cam.SetActive(false);
        this.playerCam.SetActive(true);
        this.player.SetActive(true);

    }
}
