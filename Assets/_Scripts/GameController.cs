using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController I = null;
    private int _collectedFruits = 0;

    public GameObject loseGamePanel;
    public GameObject startGamePanel;
    public Player player;

    public int currentLevel;

    public void Awake()
    {
        if (I == null)
            I = this;
        else if (I != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_collectedFruits == 3)
        {
            NextGame();
            _collectedFruits = 0;
        }
    }

    public void UpdateCollectedFruits () => _collectedFruits++;

    public void LoseGame ()
    {
        loseGamePanel.SetActive(true);
    }

    public void NextGame ()
    {

    }

    public void OnPlayGame ()
    {
        startGamePanel.SetActive(false);
    }

    public void PauseGame ()
    {
        player.Freeze(true);
    }

    public void ResumeGame ()
    {
        player.Freeze(false);
    }
}

