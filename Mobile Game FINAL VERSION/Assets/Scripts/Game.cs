using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private Player computer;
    private Player player1;

    // static variable that holds the value of the dice rolled -> triggered by button press
    private static int rollvalue;

    // variable that acts as a counter for tracking the number of rounds that have been played.
    private int numOfRoundsPlayed;

    // variable that holds maxiumum number of rounds for each game.
    public int MAX_NUMBER_OF_ROUNDS = 10;

    // boolean variable which holds the game state (finished or not).
    private bool gameFinished;

    // int variable that holds the value for the amount of money each player starts with.
    public int STARTING_MONEY_VALUE = 50;

    // int variable that holds the value for the amount of "victory points" (e.g. academic, social, health) each player starts with.
    public int STARTING_VICTORY_POINT_VALUE = 10;

    // references to the UI Text components which will display the money and various points for each player.
    public Text playerMoneyText;
    public Text computerMoneyText;
    public Text playerAcademicText;
    public Text computerAcademicText;
    public Text playerHealthText;
    public Text computerHealthText;
    public Text playerSocialText;
    public Text computerSocialText;

    // references to playercounter positions on the board
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;
    public GameObject square5;
    public GameObject square6;
    public GameObject square7;
    public GameObject square8;
    public GameObject square9;
    public GameObject square10;
    public GameObject square11;
    public GameObject square12;
    public GameObject square14;
    public GameObject square15;
    public GameObject square16;
    public GameObject square17;
    public GameObject square18;
    public GameObject square19;
    public GameObject square20;
    public GameObject square21;
    public GameObject square22;
    public GameObject square23;
    public GameObject square24;
    public GameObject square25;
    public GameObject squarehome;
    public GameObject squarestart;

    // references to computercounter positions on the board
    public GameObject computersquare1;
    public GameObject computersquare2;
    public GameObject computersquare3;
    public GameObject computersquare4;
    public GameObject computersquare5;
    public GameObject computersquare6;
    public GameObject computersquare7;
    public GameObject computersquare8;
    public GameObject computersquare9;
    public GameObject computersquare10;
    public GameObject computersquare11;
    public GameObject computersquare12;
    public GameObject computersquare14;
    public GameObject computersquare15;
    public GameObject computersquare16;
    public GameObject computersquare17;
    public GameObject computersquare18;
    public GameObject computersquare19;
    public GameObject computersquare20;
    public GameObject computersquare21;
    public GameObject computersquare22;
    public GameObject computersquare23;
    public GameObject computersquare24;
    public GameObject computersquare25;
    public GameObject computersquarehome;
    public GameObject computersquarestart;

    public GameObject[,] counterArray;

    // hashtables that hold the different effects for each attribute.
    public Hashtable academiceffects;
    public Hashtable healtheffects;
    public Hashtable socialeffects;

    // Use this for initialization
    void Start () {
        player1 = new Player
        {
            // set starting values
            money = STARTING_MONEY_VALUE,
            academicPoints = STARTING_VICTORY_POINT_VALUE,
            healthPoints = STARTING_VICTORY_POINT_VALUE,
            socialPoints = STARTING_VICTORY_POINT_VALUE
        };
        computer = new Player
        {
            // set starting values
            money = STARTING_MONEY_VALUE,
            academicPoints = STARTING_VICTORY_POINT_VALUE,
            healthPoints = STARTING_VICTORY_POINT_VALUE,
            socialPoints = STARTING_VICTORY_POINT_VALUE
        };

        // displaying player attribute values on the game scene
        SetMoneyText(computer, computerMoneyText);
        SetMoneyText(player1, playerMoneyText);
        SetAcademicText(computer, computerAcademicText);
        SetAcademicText(player1, playerAcademicText);
        SetHealthText(computer, computerHealthText);
        SetHealthText(player1, playerHealthText);
        SetSocialText(computer, computerSocialText);
        SetSocialText(player1, playerSocialText);

        square1.SetActive(false);
        square2.SetActive(false);
        square3.SetActive(false);
        square4.SetActive(false);
        square5.SetActive(false);
        square6.SetActive(false);
        square7.SetActive(false);
        square8.SetActive(false);
        square9.SetActive(false);
        square10.SetActive(false);
        square11.SetActive(false);
        square12.SetActive(false);
        square14.SetActive(false);
        square15.SetActive(false);
        square16.SetActive(false);
        square17.SetActive(false);
        square18.SetActive(false);
        square19.SetActive(false);
        square20.SetActive(false);
        square21.SetActive(false);
        square22.SetActive(false);
        square23.SetActive(false);
        square24.SetActive(false);
        square25.SetActive(false);
        squarestart.SetActive(false);

        computersquare1.SetActive(false);
        computersquare2.SetActive(false);
        computersquare3.SetActive(false);
        computersquare4.SetActive(false);
        computersquare5.SetActive(false);
        computersquare6.SetActive(false);
        computersquare7.SetActive(false);
        computersquare8.SetActive(false);
        computersquare9.SetActive(false);
        computersquare10.SetActive(false);
        computersquare11.SetActive(false);
        computersquare12.SetActive(false);
        computersquare14.SetActive(false);
        computersquare15.SetActive(false);
        computersquare16.SetActive(false);
        computersquare17.SetActive(false);
        computersquare18.SetActive(false);
        computersquare19.SetActive(false);
        computersquare20.SetActive(false);
        computersquare21.SetActive(false);
        computersquare22.SetActive(false);
        computersquare23.SetActive(false);
        computersquare24.SetActive(false);
        computersquare25.SetActive(false);
        computersquarestart.SetActive(false);

        // array that represents the gameboard of tiles
        counterArray = new GameObject[10,5] {
            {squarestart, square25, square24, square23, square22},
            {square1, null, null, null, square21},
            {square2, null, null, null, square20},
            {square3, null, null, null, square19},
            {square4, null, null, null, square18},
            {square5, null, null, null, square17},
            {square6, null, null, null, square16},
            {square7, null, null, null, square15},
            {square8, null, null, null, square14},
            {square9, square10, square11, square12, squarehome}
        };

        // the following are the various events and gains/losses that take place...
        academiceffects = new Hashtable();
        academiceffects.Add("1", 2);
        academiceffects.Add("2", -2);
        academiceffects.Add("3", 3);
        academiceffects.Add("4", -5);
        academiceffects.Add("5", 1);
        academiceffects.Add("6", -1);
        academiceffects.Add("7", 2);
        academiceffects.Add("8", -2);
        academiceffects.Add("9", 1);
        academiceffects.Add("10", -2);

        academiceffects.Add("1text", "You get high marks on a progress test. Well done!");
        academiceffects.Add("2text", "You get low marks on a progress test.");
        academiceffects.Add("3text", "You managed to get a 1:1 on an assignment!!");
        academiceffects.Add("4text", "You missed the deadline for an assignment.");
        academiceffects.Add("5text", "You caught up on all your lab work for the week.");
        academiceffects.Add("6text", "Your computer crashes and you lose your essay first draft. oh no!");
        academiceffects.Add("7text", "Your essay comes back with a good grade. Congrats!");
        academiceffects.Add("8text", "The people in your group project are slackers and get no work done.");
        academiceffects.Add("9text", "You found a free PDF of a book you need for class.");
        academiceffects.Add("10text", "You get caught tapping into a lecture and are sent to speak to head of your school.");

        healtheffects = new Hashtable();
        healtheffects.Add("1", -2);
        healtheffects.Add("2", 1);
        healtheffects.Add("3", -1);
        healtheffects.Add("4", 2);
        healtheffects.Add("5", -3);
        healtheffects.Add("6", 2);
        healtheffects.Add("7", -2);
        healtheffects.Add("8", 1);
        healtheffects.Add("9", -2);
        healtheffects.Add("10", 1);

        healtheffects.Add("1text", "You do an all nighter for a test");
        healtheffects.Add("2text", "Your parents send a food care package...no more takeout!");
        healtheffects.Add("3text", "Freshers flue strikes again.");
        healtheffects.Add("4text", "No lectures today = day in bed");
        healtheffects.Add("5text", "Cursed with food poisoning from stealing flatmate's food!");
        healtheffects.Add("6text", "Did a great workout at the campus gym.");
        healtheffects.Add("7text", "Extremely hungover!");
        healtheffects.Add("8text", "Got a free massage treatment from the sports therapy clinic");
        healtheffects.Add("9text", "Bad day for mental health");
        healtheffects.Add("10text", "Grabbed a some bargains on fresh fruit and veg at the store.");

        socialeffects = new Hashtable();
        socialeffects.Add("1", 3);
        socialeffects.Add("2", 1);
        socialeffects.Add("3", -1);
        socialeffects.Add("4", -2);
        socialeffects.Add("5", 2);
        socialeffects.Add("6", 2);
        socialeffects.Add("7", -2);
        socialeffects.Add("8", 1);
        socialeffects.Add("9", 1);
        socialeffects.Add("10", 1);

        socialeffects.Add("1text", "You had a blast at wednesday fed!");
        socialeffects.Add("2text", "Spent the night/morning at the fullmoon rave");
        socialeffects.Add("3text", "You're a bit behind on work...no nights out for you this week!");
        socialeffects.Add("4text", "Broke your phone on campus...no social media for you.");
        socialeffects.Add("5text", "Hung out in SU bar with first year friends.");
        socialeffects.Add("6text", "Sang your heart out at monday milk it!");
        socialeffects.Add("7text", "Got pulled into work so had to cancel plans.");
        socialeffects.Add("8text", "Saw a play at the Lakeside Theatre");
        socialeffects.Add("9text", "Skyped friends and family back home.");
        socialeffects.Add("10text", "Took advantage of student discounts in town.");

        Gameplay();
    }

    // Update is called once per frame
    // DO NOT PRINT OUT LOTS HERE OR UNITY WILL CRASH!!!!!!!!!!!!!!!!!!
    void Update()
    {
        // roll value is constantly updated
        rollvalue = DiceRoller.DiceTotal;
        // UNCOMMENT THE LINE OF CODE BELOW TO SEE DICE VALUE UPDATE!
        // outputs dice value once per frame, this output gets updated each time the roll dice button is pressed
        //Debug.Log("dice roll: " + rollvalue);
    }

    // methods that set/display the current values (money, points etc.)
    void SetMoneyText(Player p, Text t)
    {
        t.text = "Money: " + p.money.ToString();
    }
    void SetAcademicText(Player p, Text t)
    {
        t.text = "Academic: " + p.academicPoints.ToString();
    }
    void SetHealthText(Player p, Text t)
    {
        t.text = "Health: " + p.healthPoints.ToString();
    }
    void SetSocialText(Player p, Text t)
    {
        t.text = "Social: " + p.socialPoints.ToString();
    }

    // updates player's/counter's position 
    void UpdatePlayerPosition(Player p)
    {
        int[] currentposition = p.GetPosition();
        p.MovePlayer(rollvalue);
        int[] newposition = p.GetPosition();
        /*if (newposition[1] == 4)
        {
            if (newposition[0] == 8) { player84.SetActive(true); }
            else if (newposition[0] == 7) { player74.SetActive(true); }
            else if (newposition[0] == 6) { player64.SetActive(true); }
            else if (newposition[0] == 5) { player54.SetActive(true); }
            else if (newposition[0] == 4) { player44.SetActive(true); }
            else if (newposition[0] == 3) { player34.SetActive(true); }
            else if (newposition[0] == 2) { player24.SetActive(true); }

        }*/
        //Debug.Log("old position: " + currentposition[0] + currentposition[1]);
        //Debug.Log("new position: " + newposition[0] + newposition[1]);
    }

    // play method
    void Gameplay()
    {
        while (player1.myTurn) {
            UpdatePlayerPosition(player1);
            player1.myTurn = false;
        }
        UpdatePlayerPosition(computer);
        /*player1.myTurn = true;
        if (diceRoller.DiceTotal != 0)
        {
            int roll = diceRoller.DiceTotal;
            Debug.Log("moving " + roll + " places!");
            player1.MovePlayer(player1.GetPosition(), roll);
        }*/

        // if (diceButton.interactable) { diceButton.interactable = false; }
    }

    /*
     
     // if each player has taken the maximum number of actions per round (10 each) then the round is over.
     if (player1.numOfActions == MAX_NUMBER_OF_ACTIONS_PER_ROUND && computer.numOfActions == MAX_NUMBER_OF_ACTIONS_PER_ROUND) {
            numOfRoundsPlayed++;
        }

    // if maximum number of rounds (3) have been played then the game is finished.
    if (numOfRoundsPlayed == MAX_NUMBER_OF_ROUNDS) {
            gameFinished = true;
        }

     */


}
