using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{

    // string variable that will hold value of player's name
    // would be used in future implementation whereby the "EnterName" page functionality would be working
    public string playername;

    // public variables that are associated with the player character (e.g. money and "victory points").
    public int money;
    public int academicPoints;
    public int socialPoints;
    public int healthPoints;

    // variable that acts as a counter for number of turns a player has taken. 
    // each player can only take 10 actions each round.
    public int numOfActions;

    // boolean variable to determine whos turn it is.
    public bool myTurn;

    // int[,] array that holds the players current position (1 = player)
    int[,] playerposition = new int[10, 5] {
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1}
    };

    // method returns player's name.
    string getName()
    {
        return playername;
    }

    // method to get position of player in the int array of the board grid 
    // output can be thouht of as coordinates (e.g. [9,4] = row 10, column 5)
    public int[] GetPosition()
    {
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                if (playerposition[r, c] == 1)
                {
                    return new int[] { r, c };
                }

            }
        }
        return null;
    }

    // method that moves the position of the player/computer counter in the array
    // accounts for the fact that only some areas can be moved to and direction may change.
    // debug.log lines commented out due to only needing use when testing.
    public void MovePlayer(int diceroll) {
        int numTimesMoved = 0;
        int[] position = GetPosition();
        while (numTimesMoved != diceroll)
        {
            if (position[0] == 0 && position[1] > 0)
            {
                playerposition[position[0], position[1]] = 0;
                position[1]--;
                playerposition[position[0], position[1]] = 1;
                numTimesMoved++;
               // Debug.Log("Player position: " + GetPosition());
            }
            if (position[0] < 9 && position[1] == 0)
            {
                playerposition[position[0], position[1]] = 0;
                position[0]++;
                playerposition[position[0], position[1]] = 1;
                numTimesMoved++;
                //Debug.Log("Player position: " + GetPosition());
            }
            if (position[0] == 9 && position[1] < 4)
            {
                playerposition[position[0], position[1]] = 0;
                position[1]++;
                numTimesMoved++;
                playerposition[position[0], position[1]] = 1;
                //Debug.Log("Player position: " + GetPosition());
            }
            if (position[0] > 0 && position[1] == 4)
            {
                playerposition[position[0], position[1]] = 0;
                position[0]--;
                numTimesMoved++;
                playerposition[position[0], position[1]] = 1;
                //Debug.Log("Player position: " + GetPosition());
            }
        }
    }
}
