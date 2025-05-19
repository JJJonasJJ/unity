using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;
    [SerializeField] PieceFallDetector pfd;

    public int RoundNumber = 0;

    public void DisplayInfo() //Visar vilken runda som det �r
    {
        if (pfd.GameOver == true) { textElement.text = ""; } //G�r s� att man inte kan se rundnummeret om n�gon har vunnit

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
