using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private SpawnGameEvent spawnGameEvent;
    [SerializeField] private GameEvent gameEvent;

    private void Start()
    {
        spawnGameEvent = GetComponent<SpawnGameEvent>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnGameEvent.SpawnEvent(gameEvent);
        }
    }
    
}
