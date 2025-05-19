using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour
{
    [SerializeField] PieceFallDetector pfd;
    public float speed = 0.6f;
    public Transform target;

    void Update()
    {
       
        Vector3 t;
        t.x = transform.eulerAngles.x;
        t.y = transform.eulerAngles.y;
        t.z = 0;
        transform.rotation = Quaternion.Euler(t); //Gör så att kameran inte snurrar runt på konstiga sätt.

        if (pfd.GameOver != false) //Om det är Game-Over så snurrar kameran runt det som är kvar av Jenga-Tornet
        {
            transform.RotateAround(target.position, transform.up, (speed/10));
        }
        else //Annars så snurrar kameran runt jenga-tornet
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.RotateAround(target.position, transform.right, speed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.RotateAround(target.position, transform.right, -speed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(target.position, transform.up, -speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(target.position, transform.up, speed);
            }

        } 
    }
}
