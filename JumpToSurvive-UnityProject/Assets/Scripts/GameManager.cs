using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float speed = .1f;
	public int score = 0;
	public Text dynNumber;
	public GameObject startPanel;
	public GameObject endPanel;
	public Wilson wilson;
	public GameObject shoeLabel;
	public GameObject[] spawnPoints;
	public Disturbatore disturbatorePrefab;

	private bool giaStarted = false;

	void Update()
	{
		if (Input.GetKeyDown("r"))
			SceneManager.LoadScene("Main");
		else if (Input.GetKeyDown(KeyCode.Space) && !giaStarted) {
			giaStarted = true;
			startPanel.SetActive(false);
			wilson.gameObject.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void IncrementScore(int points)
	{
		score += points;
		shoeLabel.GetComponent<TextMesh>().text = score.ToString();
	}
	public void InstantiateNewDisturbatore()
	{
		GameObject randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Disturbatore newDisturbatore = (Disturbatore)Instantiate(disturbatorePrefab, randomSpawn.transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward));

		newDisturbatore.spawnOrigin = randomSpawn;
		newDisturbatore.velocityX = Random.Range(score % 10 + 1, score % 8 + 5);
		newDisturbatore.xDirection = (randomSpawn.transform.position.x < 0 ? "dx" : "sx");
	}

	public void SetScoreLabel()
	{
		dynNumber.text = score.ToString() + (score == 1 ? " rimbalzo" : " rimbalzi");
	}

	public void PromptEndMessage()
	{
		endPanel.SetActive(true);
	}
}
