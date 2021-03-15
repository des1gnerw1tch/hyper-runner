using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour
{
    [SerializeField] private sunsetManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private DanceMove[] danceMoves;

    [SerializeField] private Transform player;
    int i = 0;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        levelManager.SetPlayerMode("Rhythm");
        levelManager.playerCamMoveSpeed = playerFloatingSpeed;
        levelManager.UpdateSpeeds();

        //starts recursion of placing dance moves
        StartCoroutine(StartDanceMove(danceMoves[i].timeDelay));
      }
    }

    // instantiates the newest dance move,
    IEnumerator StartDanceMove(float delay)  {
        yield return new WaitForSeconds(delay);
        Vector3 loc = new Vector3(player.position.x + 10, player.position.y, 0);
        Instantiate(danceMoves[i].dancePopup, loc, Quaternion.identity);
        i++;
        if (i < danceMoves.Length)  {
          StartCoroutine(StartDanceMove(danceMoves[i].timeDelay));
        }
    }

    void Update() {
      if (Input.GetKeyDown("up") || Input.GetKey("down")) {
        UpdateValidDanceKeys();
      }
    }

    //Makes sure that only 1 dance key is okay to press at one time
    void UpdateValidDanceKeys() {
      danceObject[] objs = FindObjectsOfType<danceObject>();
      if (objs.Length != 0) {
        danceObject closest = objs[0];
        foreach (danceObject obj in objs) {
          if (obj.gameObject.GetComponent<Transform>().position.x < closest.GetComponent<Transform>().position.x) {
            closest = obj;
          }
        }
        closest.active = true;
      }
    }
}
