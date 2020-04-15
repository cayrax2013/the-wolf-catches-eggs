using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPageAboutRaushan : MonoBehaviour
{
    [SerializeField] private GameObject _aboutRaushanPage;
    [SerializeField] private GameObject _aboutDevelopersPage;

    private void OnMouseDown()
    {
        _aboutRaushanPage.SetActive(true);
        _aboutDevelopersPage.SetActive(false);
    }
}
