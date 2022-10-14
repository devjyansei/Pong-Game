using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    public static BallController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void OnMyStart()
    {
        FreezeBall();
        rb.AddForce(Vector2.up * speed);
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Racket"))
        {
            RacketController racketController = other.transform.GetComponent<RacketController>(); // çarptýðýmýz raketi alýyoruz.

            float horizontalDirection = (transform.position.x - racketController.transform.position.x) / other.collider.bounds.extents.x; // 0.5 e bölüyoruz.(2 ile çarpýyor) 

            float verticalDirection = racketController.isAI ? -1 : 1; // Eðer isAI isaretliyse -1, degilse 1 degerini verir.
         
            rb.AddForce(new Vector2(horizontalDirection,verticalDirection).normalized * speed);
        }


        if (other.gameObject.CompareTag("PlayerGoal"))
        {
           
            GameManager.instance.GameOver();
            FreezeBall();


        }
        if (other.gameObject.CompareTag("EnemyGoal"))
        {
            GameManager.instance.Score++;
            GameManager.instance.UpdateScore();
            GameManager.instance.StartGame();
            
        }



    }
    void FreezeBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

}
