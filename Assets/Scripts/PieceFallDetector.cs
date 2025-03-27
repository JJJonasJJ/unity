using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFallDetector : MonoBehaviour
{
    public bool GameOver = false;

    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.yellow) { }
        else
        {

            if (collision.gameObject.CompareTag("Piece"))
            {
                
                    GameOver = true;
                    Debug.Log("Worked!!!");

            }
        }
    }

}
