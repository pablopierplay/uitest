using System;
using UnityEngine;
using UnityEngine.UI;

public class TextBinder : MonoBehaviour
{
    public ViewModel ViewModel;

    private void Awake()
    {
        ViewModel.OnViewModelChanged += OnModelChange;
        OnModelChange();
    }

    private void OnModelChange()
    {
        GetComponent<Text>().text = ViewModel.Value.ToString();
    }
}