using UnityEngine;
using System.Collections;

public class HangmanController : MonoBehaviour {

	public GameObject head;
	public GameObject torso;
	public GameObject arms;
	public GameObject legs;
	
	private int tries;
	private GameObject[] parts;

	public bool isDead {
		get { return tries < 0; }
	}

	// Use this for initialization
	void Start () {
		parts = new GameObject[] { legs, arms, torso, head };
		reset();
	}
	
	public void punish() {
		//Debug.Log ("Punishing Player");
		if (tries > 0) {
			parts[tries--].SetActive(true);
		}
	}

	public void reset() {
		if (parts == null)
			return;

		tries = parts.length - 1;
		foreach (GameObject g in parts) {
			g.SetActive(false);
		}
	}
}
