using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerNewScene : MonoBehaviour
{
    public GameObject endingScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ShowEndingScreen();
        }
    }

    void ShowEndingScreen()
    {
        endingScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
