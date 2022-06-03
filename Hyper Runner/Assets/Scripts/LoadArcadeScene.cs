using InteractableArcade;
using UnityEngine;

// This loads the arcade scene setup once scene entered. If the scene is entered from a previous arcade game
// scene, it should play respective animation and it should put player in respective spot...
public class LoadArcadeScene : MonoBehaviour {
    [SerializeField] private Transform startGamePos; // where player should start when game starts
    [SerializeField] private GameObject player; // player of the game
    [SerializeField] private GameObject playerCam;
    [SerializeField] private FirstPersonCameraController playerCamHolder;

    private GameObject machineCam;
    public static string sceneFrom; // what level did the player come from? 

    void Start() {
        
        if (sceneFrom != null)
        {
            arcadeMachine[] arcadeMachines = FindObjectsOfType<arcadeMachine>();
            foreach (arcadeMachine machine in arcadeMachines)
            {
                if (machine.GetSceneToLoad() == sceneFrom)
                {
                    //this.player.transform.position = machine.GetMachineSpawnPosition();
                    //this.player.transform.rotation = machine.GetSpawnRotation();
                    machine.ExitArcadeMachine(player.transform);
                    this.player.SetActive(false);
                    this.playerCam.SetActive(false);
                    machineCam = machine.GetAnimCam();
                    return;
                }
            }
        }
        
    }

    // when after exiting game, once animation camera is done animating, this is called
    // Called in panCamOFfMachine.cs
    public void PanCamOffMachineFinished() {
        this.machineCam.SetActive(false);
        this.playerCam.SetActive(true);
        this.player.SetActive(true);
    }
}
