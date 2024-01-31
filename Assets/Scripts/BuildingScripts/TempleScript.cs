using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleScript : MonoBehaviour
{
    private HeroGenerator heroGenerator;
    [SerializeField] private GameObject heroPanelPrefab;
    [SerializeField] private GameObject mainHeroPanelPrefab;
    public List<GameObject> Heroes;
    public List<Sprite> Skins;
    [SerializeField] private GameObject UI;
    private bool activeness = false;
    int i = 0;

    private void Start()
    {
        heroGenerator = GetComponent<HeroGenerator>();
    }
    private void OnMouseDown()
    {
        UIOpen();
    }

    public void UIOpen()
    {
        UI.SetActive(!activeness);
        activeness = !activeness;
    }

    public void CreateHero()
    {
        if (100 <= UIController.GetFaith())
        {
            UIController.TakeFaith(100);
            Hero newChar;
            newChar = heroGenerator.GenerateRandomHero();
            GameObject newHero;
            newHero = Instantiate(heroPanelPrefab, mainHeroPanelPrefab.transform);
            //newHero.GetComponentInChildren<Image>().sprite = newChar.GetSprite();
            newHero.GetComponentInChildren<Text>().text = "Intelligence" + newChar.Intelligence + "," + "Strength" + newChar.Strength + "," + "Dexterity" + newChar.Dexterity + "," + "Constitution " + newChar.Constitution + "," + "Wisdom" + newChar.Wisdom + "," + "Charisma" + newChar.Charisma + ",";
            newHero.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, 166 * i);
            Heroes.Add(newHero);
            i++;
        }


    }
}
