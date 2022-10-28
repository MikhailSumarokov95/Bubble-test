using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gun; 
    public bool IsPaused { get; private set; }

    public void Start()
    {
        StartMenu();
    }

    public void StartMenu()
    {
        gun.SetActive(false);
    }

    public void StartGame()
    {
        gun.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1);
        IsPaused = false;
    }
}
