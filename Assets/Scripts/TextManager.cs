using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;
    [SerializeField] PieceFallDetector pfd;

    public int RoundNumber = 0;

    public void DisplayInfo() //Visar vilken runda som det är
    {
        if (pfd.GameOver == true) { textElement.text = ""; } //Gör så att man inte kan se rundnummeret om någon har vunnit

        else 
        { 
        textElement.text = "Round " + (RoundNumber + 1);
        textElement.textStyle = TMP_Style.NormalStyle;
        textElement.fontStyle = FontStyles.Bold;
        }


    }

    void Update()
    {
        DisplayInfo();
    }
}
