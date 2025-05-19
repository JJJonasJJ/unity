using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour, ISelectable
{
    [SerializeField] TextManager textManager;
    public GameObject GameObject => gameObject;
    public GameObject breakableBrick;
    public AudioClip clip;
    bool isSelected = false;

    public void Select()
    {

        if (GetComponent<Renderer>().material.color == Color.yellow) //Kollar om objectet redan är selectad och om det är det
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position); //Spelar roligt ljudklipp
            this.isSelected = false; //gör biten icke-selectad
            GameObject.SetActive(false); //gör biten icke-aktiv
            if (transform.position.y < 0) { //skapar en kollapsande bit om biten är långt ner
                Instantiate(breakableBrick, transform.position, transform.rotation);
            }
        }
        else if (GameObject.activeSelf) //om biten inte har blivit selectad tidigare
        {

            this.isSelected = true; //gör biten selectad
            this.GetComponent<Renderer>().material.color = Color.yellow; //gör biten gul så man kan se vilken bit som är selectad

        }
        else {}
    }

    public void Deselect() //När biten deselectas så blir den icke aktiv, och det blir nästa spelares tur
    {
        this.isSelected = false;
        GameObject.SetActive(false);
        textManager.RoundNumber++;
        if (transform.position.y < 0)
        {
            Instantiate(breakableBrick, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true && this.isSelected) //Om space-bar trycks ner så flyttas den selectade biten på sig.
        {                                                           //Den rör sig i två olika riktningar, baserat på rotationen den började med (den kan endast ha två olika rotationer).
            if (this.transform.parent.transform.rotation.y >= 0.6f && this.transform.parent.transform.rotation.y <= 0.8f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.14f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 0.14f, transform.position.y, transform.position.z);
            }
        }

        if (transform.position.y < -10 && transform.position.y > -13) //om den faller nedanför plattformet tornet står på så har den vid dessa koordinater en chans att
        {                                                             //bytas ut mot en breakableBrick, som fragmenteras på golvet (för att förbättra prestanda så
                                                                      //är det inte garanterat att det skapas en break.Br., samt så händer det medans den faller mot golvet
                                                                      //så att denna kod inte körs för evigt.)
            int l = UnityEngine.Random.Range(0, 11);                  

            if (l == 5)
            {
                Instantiate(breakableBrick, transform.position, transform.rotation);
                GameObject.SetActive(false);
                
            }
        }


    }


}
