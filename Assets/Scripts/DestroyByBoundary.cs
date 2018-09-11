using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByBoundary : MonoBehaviour {
	public Text castle1text;
    public GameObject GameManager;
	public int health1 = 5;


	void Start()
	{
		castle1text = GameObject.Find ("Castle1Health").GetComponent<Text> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
		if (other.tag != "carrot")
			health1 -= 1;
	}
	void Update()
	{
		CheckGameOver ();
		castle1text.text = "Health: " + health1.ToString();
	}

	void CheckGameOver()
	{
        if (health1 <= 0)
        {
            GameManager.GetComponent<ChangeScene>().ChangeToScene("P2win");
			GameObject reset = GameObject.Find ("CharacterChooser");
			Destroy (reset);
        }
	}
}
