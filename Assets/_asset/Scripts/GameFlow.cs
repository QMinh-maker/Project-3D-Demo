using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    public void OnPlayerDied()
    {
        StopGame();
        gameOverPanel.SetActive(true);
    }

    public void OnMissionComplete()
    {
        StopGame();
        gameWinPanel.SetActive(true);
    }
   private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
}
