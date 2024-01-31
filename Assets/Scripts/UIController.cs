using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text moneyUI;
    [SerializeField] Text faithUI;
    static private int money = 20;
    static private int faith = 100;

    static private int income = 10;

    static UIController uiControllerInstance;

    private void Awake()
    {
        uiControllerInstance = FindObjectOfType<UIController>();
        Refresh();
        StartCoroutine(AddResourcesCoroutine());
    }

    static public int GetMoney()
    {
        return money;
    }

    static public int GetFaith()
    {
        return faith;
    }

    static public void TakeFaith(int takenFaith)
    {
        faith -= takenFaith;
        uiControllerInstance.Refresh();
    }

    static public void TakeMoney(int takenMoney)
    {
        money -= takenMoney;
        uiControllerInstance.Refresh();
    }

    

    static public void AddIncome(int addingNumber)
    {
        income += addingNumber;
        Debug.Log("incomeAdded");
    }

    IEnumerator AddResourcesCoroutine()
    {
        while (true)
        {
            Debug.Log("CoroutineStarted");
            yield return new WaitForSeconds(20f);

            money += income;
            faith += income;

            Debug.Log("RefreshUI");
            Refresh();
        }
    }

    private void Refresh()
    {
        moneyUI.text = Convert.ToString(money);
        faithUI.text = Convert.ToString(faith);
    }
}