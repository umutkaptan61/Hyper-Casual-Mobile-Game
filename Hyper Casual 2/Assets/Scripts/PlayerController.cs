using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool isPlayerDead;
    private GameManager gameManager;
    public ParticleSystem deadEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        isPlayerDead = false;
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        //Mobil i�in bunu yazar�z
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)         //Touchcount ekranda ka� parmak oldu�unu tespit eder.Ekrana bast���m�z anda 1 tane olacak ve y�n de�i�ecek.Input.GetTouch(0) ekranda bir parmak var demektir.
        {
            ChangeDirection();
            PlayerStop();
        }*/

        if (!isPlayerDead)
        {
            RayCastDedector();

            if (Input.GetKeyDown("space"))
            {
                ChangeDirection();
                PlayerStop();
            }

            else
            {
                return;
            }
        }
       
    }

    private void RayCastDedector()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position , Vector3.down ,out hit))
        {
            MovePlayer();
        }

        else
        {
            PlayerStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false) ;
            gameManager.LevelEnd();
            Instantiate(deadEffect,this.transform.position, Quaternion.identity);
        }
    }

    private enum CurrentDirection         //Y�nleri tutan bir enum veri tipi yazd�k.Right 0 , left 1 olur burada.
    {
        right,
        left
    }

    private void ChangeDirection()       //Dokunuldu�unda righti left yapmak, lefti right yapmak i�in bir fonksiyon yazd�k.
    {
        
        if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }

        else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);    //Forcemode ile 4 farkl� �e�itte kuvvet uygulayabiliriz.Velocity change'de k�tleye bakmadan ani y�n de�i�imi yapt�rabiliriz.
        }

        else if (cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()     //Her y�n de�i�iminde karakter durup di�er tarafa g�� uygulanacak.
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }
}
