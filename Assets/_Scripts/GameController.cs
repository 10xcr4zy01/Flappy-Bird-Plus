using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController I = null;

    public GameObject[] map;

    public GameObject loseGamePanel;
    public GameObject startGamePanel;
    public GameObject nextGamePanel;
    public Player player;

    private int _currentLevel = 0;
    private int _collectedFruits = 0;

    public void Awake()
    {
        if (I == null)
            I = this;
        else if (I != this)
            Destroy(gameObject);
    }
    private void Update()
    {
        if (_collectedFruits == 3)
        {
            _currentLevel++;
            WinRound(_currentLevel);
        }
    }

    public void UpdateCollectedFruits() => _collectedFruits++;

    public void WinRound (int currentlevel)
    {
        _collectedFruits = 0;
        PauseGame();
        player.SetDefaulPosition();
        nextGamePanel.SetActive(true);

        if (_currentLevel < 3)
            ChangeMap(_currentLevel);
        else if (_currentLevel >= 3)
        {
            WinGame();
        }
    }

    public void WinGame ()
    {

    }
    public void LoseGame()
    {
        PauseGame();
        loseGamePanel.SetActive(true);
    }
    public void PauseGame()
    {
        player.Freeze(true);
    }

    public void ResumeGame()
    {
        player.Freeze(false);
    }


    public void ChangeMap(int level)
    {
        switch (level)
        {
            case 0:
                map[0].SetActive(false);
                map[1].SetActive(true);
                map[2].SetActive(false);
                break;
            case 1:
                map[0].SetActive(false);
                map[1].SetActive(true);
                map[2].SetActive(false);
                break;
            case 2:
                map[0].SetActive(false);
                map[1].SetActive(false);
                map[2].SetActive(true);
                break;

        }
    }

    #region BUTTON METHDOS
    public void OnPlayAgain()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void OnPlayGame()
    {
        startGamePanel.SetActive(false);
        nextGamePanel.SetActive(false);
    }

    #endregion
}

