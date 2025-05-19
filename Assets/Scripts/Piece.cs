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

        if (GetComponent<Renderer>().material.color == Color.yellow) //Kollar om objectet redan �r selectad och om det �r det
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position); //Spelar roligt ljudklipp
            this.isSelected = false; //g�r biten icke-selectad
            GameObject.SetActive(false); //g�r biten icke-aktiv
            if (transform.position.y < 0) { //skapar en kollapsande bit om biten �r l�ngt ner
                Instantiate(breakableBrick, transform.position, transform.rotation);
            }
        }
        else if (GameObject.activeSelf) //om biten inte har blivit selectad tidigare
        {

            this.isSelected = true; //g�r biten selectad
            this.GetComponent<Renderer>().material.color = Color.yellow; //g�r biten gul s� man kan se vilken bit som �r selectad

        }
        else {}
    }

    public void Deselect() //N�r biten deselectas s� blir den icke aktiv, och det blir n�sta spelares tur
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
        if (Input.GetKey(KeyCode.Space) == true && this.isSelected) //Om space-bar trycks ner s� flyttas den selectade biten p� sig.
        {                                                           //Den r�r sig i tv� olika riktningar, baserat p� rotationen den b�rjade med (den kan endast ha tv� olika rotationer).
            if (this.transform.parent.transform.rotation.y >= 0.6f && this.transform.parent.transform.rotation.y <= 0.8f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.14f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 0.14f, transform.position.y, transform.position.z);
            }
        }

        if (transform.position.y < -10 && transform.position.y > -13) //om den faller nedanf�r plattformet tornet st�r p� s� har den vid dessa koordinater en chans att
        {                                                             //bytas ut mot en breakableBrick, som fragmenteras p� golvet (f�r att f�rb�ttra prestanda s�
                                                                      //�r det inte garanterat att det skapas en break.Br., samt s� h�nder det medans den faller mot golvet
                                                                      //s� att denna kod inte k�rs f�r evigt.)
            int l = UnityEngine.Random.Range(0, 11);                  

            if (l == 5)
            {
                Instantiate(breakableBrick, transform.position, transform.rotation);
                GameObject.SetActive(false);
                
            }
        }


    }


}
