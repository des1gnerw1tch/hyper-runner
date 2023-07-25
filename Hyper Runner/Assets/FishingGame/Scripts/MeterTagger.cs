using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterTagger : MonoBehaviour {
	[SerializeField] private float speedMin;  // min speed of tagger object
	[SerializeField] private float speedMax;
	private float speed;
	private bool catchable; // is this item catchable
	[SerializeField] private FishingMeter meter;
	[SerializeField] private ScoreManager scoreManager;

	// Update is called once per frame
	void Update () {
		Vector2 move =
			new Vector2 (this.transform.position.x + this.speed * Time.deltaTime, this.transform.position.y);
		this.transform.position = move;

		if (Input.GetKeyDown ("space")) {
			if (this.catchable) {
				Debug.Log ("Strike!");
				this.meter.ItemCaught ();
			} else {
				Debug.Log ("Missed");
				FindObjectOfType<AudioManager> ().Play ("nuetral");
				this.scoreManager.HideMeter ();
			}

		}
	}

	// when hits a hit box
	private void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("edge")) {
			this.speed = this.speed * -1f;
		}

		if (other.CompareTag ("strike")) {
			this.catchable = true;
		}
	}

	// when exits a hit box
	private void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("strike")) {
			this.catchable = false;
		}
	}

	// randomizes speed of this tagger object and sets catchable to false
	public void Init () {
		this.speed = Random.Range (this.speedMin, this.speedMax);
		this.catchable = false;
	}
}
