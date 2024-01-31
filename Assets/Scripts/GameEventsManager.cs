using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    private bool gameIsOver = false;
    SpawnGameEvent spawnGameEvent;
    [SerializeField] private List<GameEvent> gameEvents;

    private void Start()
    {
        StartCoroutine(SpawnEventCoroutine());
        spawnGameEvent = GetComponent<SpawnGameEvent>();
    }

    private IEnumerator SpawnEventCoroutine()
    {
        while (!gameIsOver)
        {
            yield return new WaitForSeconds(20f);
            spawnGameEvent.SpawnEvent(GetRandomGameEvent());
        }
    }

    private GameEvent GetRandomGameEvent()
    {
        int index = Random.Range(0, gameEvents.Count);
        return gameEvents[index];
    }
}
