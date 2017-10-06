using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.WinGame();
        }
    }
}
