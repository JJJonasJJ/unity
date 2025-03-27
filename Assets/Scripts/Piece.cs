using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour, ISelectable
{
    [SerializeField] TextManager textManager;
    
    public GameObject GameObject => gameObject;
    bool isSelected = false;
    public AudioClip clip;

  
    public void Select()
    {

        if (GetComponent<Renderer>().material.color == Color.yellow)
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            this.isSelected = false;
            GameObject.SetActive(false);

        }
        else if (GameObject.activeSelf)
        {

            this.isSelected = true;
            this.GetComponent<Renderer>().material.color = Color.yellow;

        }
        else {}
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true && this.isSelected)
        {
            if (this.transform.parent.transform.rotation.y >= 0.6f && this.transform.parent.transform.rotation.y <= 0.8f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.14f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 0.14f, transform.position.y, transform.position.z);
            }
        }


        
    }
    

    public void Deselect() {
        this.isSelected = false;
        GameObject.SetActive (false);
        textManager.RoundNumber++;

    }

}
