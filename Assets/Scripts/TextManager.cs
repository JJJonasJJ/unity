using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textElement;
    [SerializeField] PieceFallDetector pfd;

    public int RoundNumber = 0;

    public void DisplayInfo()
    {
        if (pfd.GameOver == true) { textElement.text = ""; }

        else 
        { 
        textElement.text = "Round " + (RoundNumber + 1);
        textElement.textStyle = TMP_Style.NormalStyle;
        textElement.fontStyle = FontStyles.Bold;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Att s�tta physicsuppdateringen i en text-script �r kanske inte den b�sta iden men det fungerar, s�
        
        Time.timeScale = 10f;

        DisplayInfo();
    }
}
