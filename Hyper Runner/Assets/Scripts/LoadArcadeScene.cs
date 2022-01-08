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
    [SerializeField] private FirstPersonCameraController playerCamHolder;

    public static string sceneFrom; // what level did the player come from? 
    // Start is called before the first frame update
    void Start() {
        if (sceneFrom != null && sceneFrom.Equals("Lvl_Nightlife")) {
            this.player.transform.position = new Vector3(machine1Pos.position.x, machine1Pos.position.y,
                machine1Pos.position.z);

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
        this.playerCamHolder.RotatePlayer(this.machine1Pos);
    }
}
