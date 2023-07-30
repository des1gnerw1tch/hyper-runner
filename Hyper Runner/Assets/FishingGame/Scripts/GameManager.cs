using UnityEngine;

namespace FishingGame.Scripts
{
	public class GameManager : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			FindObjectOfType<AudioManager>().Play("theme");
			FindObjectOfType<AudioManager>().Play("welcome");
		}
	}
}
