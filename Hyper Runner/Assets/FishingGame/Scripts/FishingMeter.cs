using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMeter : MonoBehaviour {


	[SerializeField] private ScoreManager scoreManager;
	[SerializeField] private MeterTagger meterTagger;
	[SerializeField] private GameObject fishImage; // image of fish next to meter
	[SerializeField] private GameObject trashImage; // image of trash next to meter
	[SerializeField] private Animator catchAnimator;
	[SerializeField] private Animator missAnimator;
	private bool isFish; // whether or not catch is a fish or a peice of trash

	// On first frame update
	void Start () {
		Init ();
	}

	// initializes variables
	public void Init () {
		float seed = Random.Range (0, 100);
		if (seed < 70) {
			this.isFish = true;
		} else {
			this.isFish = false;
		}

		if (this.isFish) {
			this.fishImage.SetActive (true);
			this.trashImage.SetActive (false);
		} else {
			this.trashImage.SetActive (true);
			this.fishImage.SetActive (false);
		}

		this.meterTagger.Init ();
	}

	// this is called when item is caught
	public void ItemCaught () {
		if (this.isFish) {
			FindObjectOfType<AudioManager> ().Play ("positive");
			this.catchAnimator.SetTrigger ("pop");
			this.scoreManager.CaughtFish ();
		} else {
			FindObjectOfType<AudioManager> ().Play ("negative");
			this.missAnimator.SetTrigger ("pop");
			this.scoreManager.CaughtTrash ();
		}
	}
}
