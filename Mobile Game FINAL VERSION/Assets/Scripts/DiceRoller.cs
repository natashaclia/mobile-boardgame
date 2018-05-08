using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * this class handles the functionality of the Dice game object.
 * the class is implemented so that when the "Roll Dice!" button is clicked on, the RollTheDiceButton()
 * method will be called and a random number will be generated as the resulting dice roll value. 
 * 
 * depending on the dice value, the corresponding Sprite will be displayed via the "diceImage" game object.
 */

public class DiceRoller : MonoBehaviour {

    // int value that holds randomly generated dice value (between 1 and 6).
    public static int DiceTotal;

    // variables to represents a Sprite object for use in 2D gameplay.
    public Sprite DiceImage1;
    public Sprite DiceImage2;
    public Sprite DiceImage3;
    public Sprite DiceImage4;
    public Sprite DiceImage5;
    public Sprite DiceImage6;


    // SpriteRenderer component to render the assigned Sprite, based on random value generated.
    private SpriteRenderer sp;

    // method returns the dice value generated
    public int getDiceTotal()
    {
        return DiceTotal;
    }

    // RollTheDice() method will be called when dice is pressed (like a button).
    public void RollTheDice()
    {
        // set DiceTotal value to being a random number between 1 and 7
        // the value 7 is not included in the possible values.
        DiceTotal = UnityEngine.Random.Range(1, 7);
        sp = GetComponent<SpriteRenderer>();

        if (DiceTotal == 1)
        {
            sp.sprite = DiceImage1;

        }
        if (DiceTotal == 2)
        {
            sp.sprite = DiceImage2;
        }
        if (DiceTotal == 3)
        {
            sp.sprite = DiceImage3;
        }
        if (DiceTotal == 4)
        {
            sp.sprite = DiceImage4;
        }
        if (DiceTotal == 5)
        {
            sp.sprite = DiceImage5;
        }
        if (DiceTotal == 6)
        {
            sp.sprite = DiceImage6;
        }
        // displays dice value in the unity console.
        Debug.Log("Rolled: " + DiceTotal);
    }


}
