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
        Debug.Log(Time.time);

        //starts recursion of placing dance moves
        StartCoroutine(StartDanceMove(danceMoves[i].timeDelay));
      }
    }

    // instantiates the newest dance move,
    IEnumerator StartDanceMove(float delay)  {
        yield return new WaitForSeconds(delay);
        Vector3 loc = new Vector3(player.position.x, player.position.y, 0);
        Instantiate(danceMoves[i].dancePopup, loc, Quaternion.identity);
        i++;
        if (i < danceMoves.Length)  {
          StartCoroutine(StartDanceMove(danceMoves[i].timeDelay));
        }
    }
}
