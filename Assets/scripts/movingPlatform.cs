using UnityEngine;

public class movingPlatform : MonoBehaviour
{
   

    public float yv;
    public float xv;
    public float top;
    public float bottom;
    public float left;
    public float right;
    float yDirection = 1;
    float xDirection = 1;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= top)
        {
            yDirection = -1;
        }

        if (transform.position.y <= bottom)
        {
            yDirection = 1;
        }
        if (transform.position.x >= right)
        {
            xDirection = -1;
        }

        if (transform.position.x <= left)
        {
            xDirection = 1;
        }

        transform.Translate(xv * xDirection * Time.deltaTime, yv * yDirection * Time.deltaTime, 0);

        




    }
}
   
