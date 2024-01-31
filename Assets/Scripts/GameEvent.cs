using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/GameEvent", order = 1)]
public class GameEvent : ScriptableObject
{
    public string eventDescription;
    public List<string> choicesText = new List<string>();
    public int eventID;

    public void Choice(int choiceID)
    {
        
    }
}
