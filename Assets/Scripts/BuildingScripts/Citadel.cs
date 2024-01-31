using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citadel : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private bool activeness = false;

    private void OnMouseDown()
    {
        UIOpen();
    }

    public void UIOpen()
    {
        UI.SetActive(!activeness);
        activeness = !activeness;
    }
}
