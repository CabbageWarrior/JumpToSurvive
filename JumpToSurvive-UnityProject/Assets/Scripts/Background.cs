using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public GameManager gameManager;

	private Renderer rend;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * gameManager.speed / 2, 0);

		rend.material.mainTextureOffset = offset;
	}
}
