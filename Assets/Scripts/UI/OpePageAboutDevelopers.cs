using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpePageAboutDevelopers : MonoBehaviour
{
    [SerializeField] private GameObject _aboutRaushanPage;
    [SerializeField] private GameObject _aboutDevelopersPage;

    private void OnMouseDown()
    {
        _aboutRaushanPage.SetActive(false);
        _aboutDevelopersPage.SetActive(true);
    }
}
