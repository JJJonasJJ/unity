using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFallDetector : MonoBehaviour
{
    public bool GameOver = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.yellow) { } //kollar om piecen �r selectad eller inte. �r den selectad s� �r det giltigt att den faller av tornet.
        else
        {

            if (collision.gameObject.CompareTag("Piece")) //�r piecen inte selectad s� �r det inte giltigt och d� s� blir det game over.
            {
                
                    GameOver = true;

            }
        }
    }

}
