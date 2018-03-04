using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {

    //GameObject diceImage;
    //Animator anim;

    //public Sprite[] dice;
    //public int rollNum;

    //private bool isRolling;
    //private bool diceRolled;

    public Button dice;
    public Animator anim;
    public Canvas can;
    public float animTime = 3.0f;
    public bool animated = false;

    float currentTime = 0f;


	// Use this for initialization
	void Start () {
        //nim = GetComponent<Animator>();
        // finds the object named "Dice" 
        //diceImage = GameObject.Find("Dice");

        //diceRolled = false;
        //isRolling = false;

        dice = GetComponent<Button>();
        anim.enabled = false;
        can.enabled = true;
        currentTime = Time.time;
	}

    // when button pressed
    public void Press()
    {
        dice.enabled = true;
        anim.enabled = true;
    }
	

	// Update is called once per frame
	void Update () {

        //if (Input.touchCount == 1)
        //{
        //  diceImage.GetComponent("Rolling");
        //anim.Play("Rolling");
        //isRolling = true;
        //}

    }

    public void TimeElapsed()
    {
        if (Time.time == animTime)
        {
            dice.enabled = false;
            anim.StopRecording();
        }
    }
}
