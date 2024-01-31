using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnGameEvent : MonoBehaviour
{
    [SerializeField] private int offset = 109;
    public GameObject mainObject;
    private List<GameObject> choiceButtons;
    private List<string> usedChoices = new List<string>();
    public GameObject buttonPrefab;
    Transform mainTransform;

    private void Start()
    {
        mainTransform = mainObject.GetComponent<Transform>();
    }

    public void SpawnEvent(GameEvent gameEvent)
    {
        choiceButtons = new List<GameObject>();
        mainObject.SetActive(true);
        int i = 0;
        mainObject.GetComponentInChildren<Text>().text = gameEvent.eventDescription;

        while (i < 3 || i < gameEvent.choicesText.Count)
        {
            GameObject newButton = Instantiate(buttonPrefab, mainTransform);
            newButton.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, offset * i);
            choiceButtons.Add(newButton);
            int index = Random.Range(0, gameEvent.choicesText.Count);
            Debug.Log(index);
            choiceButtons[i].GetComponentInChildren<Text>().text = gameEvent.choicesText[index];

            choiceButtons[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                if(index == 666)
                {
                    Quit();
                }
                DisableButtons();
            });
            i++;
        }
    }

    private void DisableButtons()
    {
        List<GameObject> buttonsToRemove = new List<GameObject>(choiceButtons);

        foreach (GameObject button in buttonsToRemove)
        {
            Destroy(button);
            choiceButtons.Remove(button);
        }
        mainObject.SetActive(false);
    }

    private void Quit()
    {
        Application.Quit();
    }
}



