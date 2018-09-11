using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {
    public GameObject canvas;
    private int player1;
    private int player2;

    //public GameObject p1frame;
    //public GameObject p2frame;

    public Image p1_jinnie;
    public Image p1_michelle;
    public Image p1_steven;
    public Image p1_valerie;
    public Image p2_jinnie;
    public Image p2_michelle;
    public Image p2_steven;
    public Image p2_valerie;

    // Use this for initialization
    void Start () {
        player1 = GameObject.Find("CharacterChooser").GetComponent<ChooseCharacter>().player1;
        player2 = GameObject.Find("CharacterChooser").GetComponent<ChooseCharacter>().player2;
        DrawCharacterFrame();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void DrawCharacterFrame()
    {
        p1_michelle.enabled = false;
        p1_steven.enabled = false;
        p1_valerie.enabled = false;
        p1_jinnie.enabled = false;

        p2_michelle.enabled = false;
        p2_steven.enabled = false;
        p2_valerie.enabled = false;
        p2_jinnie.enabled = false;
        switch(player1)
        {
            case 1:
                p1_michelle.enabled = true;
                break;
            case 2:
                p1_steven.enabled = true;
                break;
            case 3:
                p1_valerie.enabled = true;
                break;
            case 4:
                p1_jinnie.enabled = true;
                break;
        }
        switch(player2)
        {
            case 1:
                p2_michelle.enabled = true;
                break;
            case 2:
                p2_steven.enabled = true;
                break;
            case 3:
                p2_valerie.enabled = true;
                break;
            case 4:
                p2_jinnie.enabled = true;
                break;
        }
    }
}
