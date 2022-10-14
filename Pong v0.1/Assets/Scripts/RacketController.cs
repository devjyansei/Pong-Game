using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float xBounds = 1.8f;
    public bool isAI;
    [SerializeField] bool isPlayer;
    [SerializeField] float aiSpeed;
    public float AiSpeed
    {
        get { return aiSpeed; }
        set { aiSpeed = value; }
    }
    //[SerializeField] BallController ballController;   // hangi yontem? singleton - tut surukle. Singleton nedir?

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (isPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            newPosition = transform.position + (horizontal * Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            float aiPosition = Mathf.Lerp(newPosition.x, BallController.instance.transform.position.x, aiSpeed * Time.deltaTime);
            newPosition.x = aiPosition;
           // newPosition.x = BallController.instance.transform.position.x;
           // newPosition.x  = ballController.transform.position.x;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -xBounds, xBounds);
        transform.position = newPosition;

    }
}
