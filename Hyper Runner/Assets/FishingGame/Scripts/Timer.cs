using MiniGames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishingGame.Scripts
{
	public class Timer : MonoBehaviour
	{
		[SerializeField] private float timeLeft;
		[SerializeField] private TextMeshProUGUI textObj;
		[SerializeField] private GameObject gameOver;
		[SerializeField] private TextMeshProUGUI gameOverScoreText;
		[SerializeField] private TextMeshProUGUI score;
		private bool gameEnded;

		private void Start()
		{
			gameEnded = false;
			MiniGameInputManager.Instance.OnStartExitGameInput.AddListener(ExitGameIfGameEnded);
			MiniGameInputManager.Instance.OnReelRod.AddListener(ExitGameIfGameEnded);
		}

		// Update is called once per frame
		void Update()
		{
			this.timeLeft -= Time.deltaTime;
			string roundedStr = timeLeft.ToString("0.0");
			this.textObj.text = roundedStr + "";
			if (timeLeft <= 0 && !this.gameEnded)
			{
				gameEnded = true;
				Debug.Log("GAME ENDED");
				this.gameOver.SetActive(true);
				Time.timeScale = 0;
				this.gameOverScoreText.text = "Score: " + this.score.text;

			}
		}

		private void ExitGameIfGameEnded()
		{
			if (gameEnded)
			{
				SceneManager.LoadScene("Menu");
				Time.timeScale = 1f;
			}
		}

		public bool IsGameOver() => gameEnded;
	}
}
