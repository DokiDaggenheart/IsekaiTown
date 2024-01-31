using System.Collections.Generic;
using UnityEngine;

public class Hero {

    private Sprite heroSprite;

    public Sprite idleSprite; 
    public Sprite[] attackSprites;

    // Базовые характеристики
    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    // Параметры героя
    private int hp;
    private int attackDamage;
    private int carryingCapacity;
    private float reloadSpeedBonus;

    // Уровень и опыт
    private int level;
    private int experience;

    // Класс и черты
    private HeroClass heroClass;
    private List<HeroTrait> traits;

    public Hero(Sprite sprite) {
        traits = new List<HeroTrait>();
        heroSprite = sprite;
        level = 1;
        experience = 0;
    }

    // Методы для установки и получения значений характеристик

    public int Strength {
        get => strength;
        set { strength = value; UpdateHeroParameters(); }
    }

    public int Dexterity {
        get => dexterity;
        set { dexterity = value; UpdateHeroParameters(); }
    }

    public int Constitution {
        get => constitution;
        set { constitution = value; UpdateHeroParameters(); }
    }

    public int Intelligence {
        get => intelligence;
        set { intelligence = value; UpdateHeroParameters(); }
    }

    public int Wisdom {
        get => wisdom;
        set { wisdom = value; UpdateHeroParameters(); }
    }

    public int Charisma {
        get => charisma;
        set { charisma = value; UpdateHeroParameters(); }
    }

    public Sprite GetSprite()
    {
        return heroSprite;
    }

    private void UpdateHeroParameters() {
        hp = constitution * 5;
        carryingCapacity = 30 + (strength - 10) * 5;
        reloadSpeedBonus = (wisdom - 10) * 5;

        switch (heroClass) {
            case HeroClass.Warrior:
                attackDamage = 10 + (strength - 10) * 3;
                break;
            case HeroClass.Mage:
                attackDamage = 10 + (intelligence - 10) * 3;
                break;
            case HeroClass.Archer:
                attackDamage = 10 + (dexterity - 10) * 3;
                break;
        }
    }

    // Добавление и получение черт
    public void AddTrait(HeroTrait trait) {
        if (!traits.Contains(trait)) {
            traits.Add(trait);
        }
    }

    public List<HeroTrait> GetTraits() {
        return traits;
    }

     public HeroClass HeroClass {
        get => heroClass;
        set { heroClass = value; UpdateHeroParameters(); }
    }

    public int Level {
        get => level;
        set => level = Mathf.Max(1, value);
    }

    public int Experience {
        get => experience;
        set {
            experience = value;
            CheckLevelUp();
        }
    }

    private void CheckLevelUp() {
        while (experience >= 100) {
            level++;
            experience -= 100;
        }
    }

    public void AddExperience(int exp) {
        Experience += exp;
    }

    //Бой
    /*public int CalculateAttackDamage(Target target) {
        int baseDamage = attackDamage;

        if (traits.Contains(HeroTrait.Hunter) && target.IsAnimal) {
            baseDamage *= 2;
        }

        if (traits.Contains(HeroTrait.RiskTaker)) {
            baseDamage = (int)(baseDamage * 1.5f); 
        }

        return baseDamage;
    } */

    public int CalculateDamageTaken(int incomingDamage) {
        if (traits.Contains(HeroTrait.RiskTaker)) {
            incomingDamage = (int)(incomingDamage * 1.5f);
        }

        return incomingDamage;
    }

    public void SetAttackSprite(int attackIndex) {
        if (attackIndex >= 0 && attackIndex < attackSprites.Length) {
        }
    }

}
//Перечесления для классов и черт

public enum HeroClass {
    Warrior, Mage, Archer
}

public enum HeroTrait {
    RiskTaker, 
    NoHobbies,
    Hunter,   
    Agile  
}
