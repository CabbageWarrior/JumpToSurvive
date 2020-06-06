using UnityEngine;
using System.Collections;

public class Wilson : MonoBehaviour
{
	public GameManager gameManager;
	public Shoe shoe;
	public float power;
	
	private Rigidbody2D go_rb2D;
	private CircleCollider2D go_collider;
	private AudioSource go_audioSource;

	// Use this for initialization
	void Start()
	{
		go_rb2D = gameObject.GetComponent<Rigidbody2D>();
		go_collider = gameObject.GetComponent<CircleCollider2D>();
		go_audioSource = gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Destroyer":
				Kill();
				break;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Collider2D collider = collision.collider;

		switch (collider.gameObject.tag)
		{
			case "Player":
				Vector2 deltaCollision = (Vector2)go_collider.bounds.center - collision.contacts[0].point;
				Vector2 forceAxisProportion = deltaCollision / (go_collider.radius * 2);

				go_audioSource.Play();

				go_rb2D.AddForce(forceAxisProportion * power, ForceMode2D.Impulse);

				gameManager.IncrementScore(1);

				gameManager.InstantiateNewDisturbatore();
				break;
		}
	}

	public void Kill() {
		go_rb2D.isKinematic = true;
		shoe.SetDestroyed();
		gameManager.SetScoreLabel();
		gameManager.PromptEndMessage();
		Destroy(gameObject);
	}
}
