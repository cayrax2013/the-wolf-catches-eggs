﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
