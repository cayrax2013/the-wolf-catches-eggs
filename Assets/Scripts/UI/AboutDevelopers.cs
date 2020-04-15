using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutDevelopers : MonoBehaviour
{
    [SerializeField] private GameObject _menuAboutDevelopers;
    [SerializeField] private GameObject _mainMenu;

    public void OpenMenuAboutDevelopers()
    {
        _menuAboutDevelopers.SetActive(true);
    }

    public void OpenMainMenu()
    {
        _menuAboutDevelopers.SetActive(false);
    }
}
