using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	[SerializeField] private float timeLeft;
	[SerializeField] private Text textObj;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Text gameOverScore;
	[SerializeField] private Text score;
	private bool gameEnded;
	void Start () {
		gameEnded = false;
	}

	// Update is called once per frame
	void Update () {
		this.timeLeft -= Time.deltaTime;
		this.textObj.text = this.timeLeft + "";
		if (timeLeft <= 0 && !this.gameEnded) {
			gameEnded = true;
			Debug.Log ("GAME ENDED");
			this.gameOver.SetActive (true);
			Time.timeScale = 0;
			this.gameOverScore.text = this.score.text;

		}

		if (gameEnded) {
			if (Input.GetKeyDown ("space")) {
				SceneManager.LoadScene ("Main");
				Time.timeScale = 1f;
			}
		}
	}
}
