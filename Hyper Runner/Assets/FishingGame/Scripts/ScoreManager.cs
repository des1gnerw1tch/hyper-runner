using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI scoreNumberText; // the score text objet
	private int score; // the score of the game so far
	[SerializeField] private GameObject meter; // the meter game object
	[SerializeField] private float minWaitTime; // min wait time for next fish
	[SerializeField] private float maxWaitTime;

	// called on first frame
	private void Start () {
		this.score = 0;
		this.UpdateScore ();
		this.HideMeter ();
	}

	// updates score text, TODO: maybe add animation when score goes up? 
	void UpdateScore () {
		this.scoreNumberText.text = this.score + "";
	}

	// called when person caught fish, adds to score
	public void CaughtFish () {
		this.score += 10;
		this.HideMeter ();
		this.UpdateScore ();
	}

	// called when person catches trash, adds to score
	public void CaughtTrash () {
		this.score -= 30;
		this.HideMeter ();
		this.UpdateScore ();
	}

	// hides the meter after something is caught
	public void HideMeter () {
		this.meter.SetActive (false);
		StartCoroutine ("NextItem");
	}

	IEnumerator NextItem () {
		yield return new WaitForSeconds (Random.Range (this.minWaitTime, this.maxWaitTime));
		FindObjectOfType<AudioManager> ().Play ("splash");
		this.meter.SetActive (true);
		this.meter.GetComponent<FishingMeter> ().Init ();
	}
}
