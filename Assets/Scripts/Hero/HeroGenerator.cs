using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGenerator : MonoBehaviour {
    public Hero GenerateRandomHero() {
        Hero newHero = new Hero(GenerateRandomSkin());

        AssignRandomAttributes(newHero);
        AssignRandomClass(newHero);
        AssignRandomTraits(newHero);

        return newHero;
    }

    private void AssignRandomAttributes(Hero hero) {
        hero.Strength = RollDice();
        hero.Dexterity = RollDice();
        hero.Constitution = RollDice();
        hero.Intelligence = RollDice();
        hero.Wisdom = RollDice();
        hero.Charisma = RollDice();
    }
    // 3*D6)
    private int RollDice() {
        return Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
    }

    private void AssignRandomClass(Hero hero) {
        hero.HeroClass = (HeroClass)Random.Range(0, 3);
    }

    private void AssignRandomTraits(Hero hero) {
        for (int i = 0; i < 3; i++) {
            HeroTrait randomTrait = (HeroTrait)Random.Range(0, System.Enum.GetValues(typeof(HeroTrait)).Length);
            hero.AddTrait(randomTrait);
        }
    }

    private Sprite GenerateRandomSkin()
    {
        Sprite skin = GetComponent<TempleScript>().Skins[Random.Range(0, GetComponent<TempleScript>().Skins.Count)];
        return skin;
    }
}
