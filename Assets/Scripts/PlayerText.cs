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

        if (pfd.GameOver == true) //Om det är Game-Over
        {
            textElement.text = "PLAYER " + (((textManager.RoundNumber + 1) % 2) + 1) + " WINS!"; //Då så vinner spelaren vars tur det inte är
        }
        else
        {
            if (textManager.RoundNumber % 2 == 0) //gör så att varranan runda går till varranan spelare
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

