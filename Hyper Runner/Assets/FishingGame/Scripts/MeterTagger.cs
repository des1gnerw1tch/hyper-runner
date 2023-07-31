using MiniGames;
using UnityEngine;

namespace FishingGame.Scripts
{
	public class MeterTagger : MonoBehaviour
	{
		[SerializeField] private float speedMin; // min speed of tagger object
		[SerializeField] private float speedMax;
		private float speed;
		private bool catchable; // is this item catchable
		[SerializeField] private FishingMeter meter;
		[SerializeField] private ScoreManager scoreManager;

		private void Start() => MiniGameInputManager.Instance.OnReelRod.AddListener(ReelRod);

		// Update is called once per frame
		private void Update()
		{
			Vector2 move =
				new Vector2(this.transform.position.x + this.speed * Time.deltaTime, this.transform.position.y);
			this.transform.position = move;
		}

		private void ReelRod()
		{
			if (this.catchable)
			{
				Debug.Log("Strike!");
				this.meter.ItemCaught();
			}
			else
			{
				Debug.Log("Missed");
				FindObjectOfType<AudioManager>().Play("nuetral");
				this.scoreManager.HideMeter();
			}
		}

		// when hits a hit box
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("edge"))
			{
				this.speed = this.speed * -1f;
			}

			if (other.CompareTag("strike"))
			{
				this.catchable = true;
			}
		}

		// when exits a hit box
		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.CompareTag("strike"))
			{
				this.catchable = false;
			}
		}

		// randomizes speed of this tagger object and sets catchable to false
		public void Init()
		{
			this.speed = Random.Range(this.speedMin, this.speedMax);
			this.catchable = false;
		}
	}
}
