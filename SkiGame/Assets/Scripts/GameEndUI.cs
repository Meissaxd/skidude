using System;
using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Image crossfade;
    [SerializeField] private int nextLevelindex = 0;
    [SerializeField] private Leaderboard leaderboard;
    void Start()
    {
        gameOverMenu.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    public void RetryLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        FlagEvents.raceEnd += EnableGameOverUI;
        FlagEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        FlagEvents.raceEnd -= EnableGameOverUI;
        FlagEvents.Quit -= Quit;
    }

    public void QuitButton()
    {
        FlagEvents.CallQuit();
    }

    private void EnableGameOverUI()
    {
        gameOverMenu.SetActive(true);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelindex);
    }

    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        Application.Quit();

    }
}