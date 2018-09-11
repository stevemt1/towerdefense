using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyByBoundary2 : MonoBehaviour {
	public Text castle2text;
    public GameObject GameManager;
	public int health2 = 5;


	void Start()
	{
		castle2text = GameObject.Find ("Castle2Health").GetComponent<Text> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
		if (other.tag != "carrot")
			health2 -= 1;
	}
	void Update()
	{
		CheckGameOver ();
		castle2text.text = "Health: " + health2.ToString();
	}

    void CheckGameOver()
    {
        if (health2 <= 0)
        {
            GameManager.GetComponent<ChangeScene>().ChangeToScene("P1win");
			GameObject reset = GameObject.Find ("CharacterChooser");
			Destroy (reset);
        }
	}

}
