using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] float difXFromPlayer = 0f;
    [SerializeField] Transform player;
    [SerializeField] string trainSound;
    public bool trainBeforePlayer;
    
    // TODO: Script doesn't work well, in theory this would play a toot noise when the train is close to the player
    /*void Start()  {
      trainBeforePlayer = true;
    }

    void Update()
    {
      if ((transform.localPosition.x - player.position.x < difXFromPlayer) && trainBeforePlayer)  {
        trainBeforePlayer = false;
        //FindObjectOfType<AudioManager>().Play(trainSound);
        Debug.Log("Play train sound!");
      }

      if (transform.localPosition.x - player.position.x > difXFromPlayer && !trainBeforePlayer)  {
        trainBeforePlayer = true;
      }

    }*/
}
