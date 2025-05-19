using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFallDetector : MonoBehaviour
{
    public bool GameOver = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.yellow) { } //kollar om piecen är selectad eller inte. Är den selectad så är det giltigt att den faller av tornet.
        else
        {

            if (collision.gameObject.CompareTag("Piece")) //Är piecen inte selectad så är det inte giltigt och då så blir det game over.
            {
                
                    GameOver = true;

            }
        }
    }

}
