using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
   

    float yv = 2;
    public float top = 10;
    public float bottom = -10;
    float direction = 1;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= top)
        {
            direction = -1;
        }

        if (transform.position.y <= bottom)
        {
            direction = 1;
        }

        transform.Translate(0, yv * direction * Time.deltaTime, 0);




    }
}
   
