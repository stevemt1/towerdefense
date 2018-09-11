using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour {


	public float health;
	public GameObject red;
	public GameObject red2;
	public GameObject red3;
	public GameObject red4;
	public GameObject red5;

	// Use this for initialization
	void Start () {
		red.SetActive (true);
		red2.SetActive (false);
		red3.SetActive (false);
		red4.SetActive (false);
		red5.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		health = gameObject.transform.parent.GetComponent<Enemy> ().health;
		CheckHealth (health);


	}


	void CheckHealth(float health)
	{
		if (health >= 5) {
			red.SetActive (true);
			red2.SetActive (false);
			red3.SetActive (false);
			red4.SetActive (false);
			red5.SetActive (false);
		}
		if (health >= 4 && health < 5) {
			red2.SetActive (true);
			red.SetActive (false);
			red3.SetActive (false);
			red4.SetActive (false);
			red5.SetActive (false);
		}
		if (health >= 3 && health < 4) {
			red3.SetActive (true);
			red2.SetActive (false);
			red.SetActive (false);
			red4.SetActive (false);
			red5.SetActive (false);
		}
		if (health >= 2 && health < 3) {
			red4.SetActive (true);
			red2.SetActive (false);
			red3.SetActive (false);
			red.SetActive (false);
			red5.SetActive (false);
		}
		if (health >= 1 && health < 2) {
			red5.SetActive (true);
			red2.SetActive (false);
			red3.SetActive (false);
			red4.SetActive (false);
			red.SetActive (false);
		}
	}
}
