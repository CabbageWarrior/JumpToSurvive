using UnityEngine;
using System.Collections;

public class Disturbatore : MonoBehaviour
{
	public GameManager gameManager;
	
	public string xDirection;
	public float velocityX;
	public GameObject spawnOrigin;
	private Rigidbody2D rb2D;

	void Start()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		rb2D.MovePosition(rb2D.position + (new Vector2(velocityX * (xDirection == "dx" ? 1 : -1), 0)) * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Spawn":
				if (other.gameObject != spawnOrigin)
				{
					Destroy(gameObject);
				}
				break;
		}
	}
}
