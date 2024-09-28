using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private void OnEnable()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    protected bool IsGameOver()
    {
        if (playerController != null)
        {
            return playerController.gameOver;
        }
        return false;
    }
}
