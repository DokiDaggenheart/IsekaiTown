using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*public class BattleManager : MonoBehaviour {
    private List<Hero> heroesInBattle;
    private int currentHeroIndex = 0;

    void Start() {
        heroesInBattle = FindObjectsOfType<Hero>().OrderByDescending(hero => hero.GetAgility()).ToList();
        currentHeroIndex = 0;
    }

    void Update() {
        if (IsHeroTurn()) {
            // Тут нужно действие прописать чтобы ии делал
        }
        else{
            // Ход противника ИИ
        }
    }

    private bool IsHeroTurn() {
        return currentHeroIndex < heroesInBattle.Count;
    }

    public void PerformAction(HeroActionType actionType, Hero target) {
        Hero currentHero = heroesInBattle[currentHeroIndex];

        switch (actionType) {
            case HeroActionType.Attack:
                currentHero.PerformAttack(target);
                break;
            case HeroActionType.Support:
                currentHero.PerformSupportAction(target);
                break;
            case HeroActionType.SpecialAttack:
                currentHero.PerformSpecialAttack(target);
                break;
        }

        GoToNextHero();
    }

    private void GoToNextHero() {
        currentHeroIndex = (currentHeroIndex + 1) % heroesInBattle.Count;
    }
}

public enum HeroActionType { Attack, Support, SpecialAttack }
*/