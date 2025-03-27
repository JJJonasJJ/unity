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

        if (pfd.GameOver == true)
        {
            textElement.text = "PLAYER " + (((textManager.RoundNumber + 1) % 2) + 1) + " WINS!";

        }
        else
        {
            if (textManager.RoundNumber % 2 == 0)
            {
                textElement.text = "Player 1's Turn";
            }

            else
            {
                textElement.text = "Player 2's Turn";
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        textElement.textStyle = TMP_Style.NormalStyle;
        textElement.fontStyle = FontStyles.Bold;
    }

    // Update is called once per frame
    void Update()
    {


        DisplayText();
    }
}

