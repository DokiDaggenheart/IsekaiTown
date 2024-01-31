using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] int income = 5;

    private void Start()
    {
        UIController.AddIncome(income);
    }
}
