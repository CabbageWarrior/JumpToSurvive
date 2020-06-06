using UnityEngine;
using System.Collections;

public class Shoe : MonoBehaviour
{

	public float speed;
	public float xMin;
	public float xMax;
	public float secondsBeforeDestroy;
	public GameObject shoeBox;
	private float movex = 0f;
	private Rigidbody2D go_rb2D;
	private Animator go_animator;
	private AudioSource go_audioSource;

	private bool isDestroyed = false;

	public void SetDestroyed()
	{
		isDestroyed = true;
		shoeBox.SetActive(false);
		go_audioSource.Play();
		go_animator.Play("ShoeExplosion");
		go_rb2D.velocity = new Vector2(0f, 0f);
		Destroy(gameObject, secondsBeforeDestroy);
	}
	/*public bool GetDestroyed()
	{
		return isDestroyed;
	}*/


	void Start()
	{
		go_rb2D = gameObject.GetComponent<Rigidbody2D>();
		go_animator = gameObject.GetComponent<Animator>();
		go_audioSource = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!isDestroyed)
		{
			movex = Input.GetAxis("Horizontal");

			if (go_rb2D.position.x < xMin)
				go_rb2D.MovePosition(new Vector2(xMin, go_rb2D.position.y));
			else if (go_rb2D.position.x > xMax)
				go_rb2D.MovePosition(new Vector2(xMax, go_rb2D.position.y));
			else
				go_rb2D.velocity = new Vector2(movex * speed, 0);
		}
	}
}
