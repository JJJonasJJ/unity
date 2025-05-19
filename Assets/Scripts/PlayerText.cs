using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;
    [SerializeField] TextManager textManager;
    [SerializeField] PieceFallDetector pfd;

    public void DisplayText()
    {

        if (pfd.GameOver == true) //Om det �r Game-Over
        {
            textElement.text = "PLAYER " + (((textManager.RoundNumber + 1) % 2) + 1) + " WINS!"; //D� s� vinner spelaren vars tur det inte �r
        }
        else
        {
            if (textManager.RoundNumber % 2 == 0) //g�r s� att varranan runda g�r till varranan spelare
            {
                textElement.text = "Player 1's Turn";
            }
            else
            {
                textElement.text = "Player 2's Turn";
            }
        }
    }

    void Start()
    {
        textElement.textStyle = TMP_Style.NormalStyle;
        textElement.fontStyle = FontStyles.Bold;
    }

    void Update()
    { 
        DisplayText();
    }
}

