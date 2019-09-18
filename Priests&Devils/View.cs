using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

public class View : MonoBehaviour
{

    SSDirector one;
    UserAction action;

    // Use this for initialization
    void Start()
    {
        one = SSDirector.GetInstance();
        action = SSDirector.GetInstance() as UserAction;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 30;
        if (one.state == State.Win)
        {
            if (GUI.Button(new Rect(350, 150, 300, 100), "WIN\n(click here to reset)"))
            {
                action.reset();
            }
        }
        if (one.state == State.Lose)
        {
            if (GUI.Button(new Rect(350, 150, 300, 100), "LOSE\n(click here to reset)"))
            {
                action.reset();
            }
        }

        if (GUI.Button(new Rect(450, 80, 100, 50), "GO"))
        {
            action.moveBoat();
        }
        if (GUI.Button(new Rect(350, 300, 75, 50), "LeftOFF"))
        {
            action.offBoatL();
        }
        if (GUI.Button(new Rect(550, 300, 75, 50), "RightOFF"))
        {
            action.offBoatR();
        }
        if (GUI.Button(new Rect(50, 130, 75, 50), "PriestsON"))
        {
            action.priestSOnSide();
        }
        if (GUI.Button(new Rect(200, 130, 75, 50), "DevilsON"))
        {
            action.devilSOnSide();
        }
        if (GUI.Button(new Rect(750, 130, 75, 50), "DevilsON"))
        {
            action.devilEOnSide();
        }
        if (GUI.Button(new Rect(900, 130, 75, 50), "PriestsON"))
        {
            action.priestEOnSide();
        }
    }
}