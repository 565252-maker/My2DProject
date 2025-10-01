using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    float xv, yv;
  
  

   
   



    void Start()
    {
        xv = 1;
        rb = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {

        

      

         gameObject.transform.Translate(xv * 0.05f,yv,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        xv = 0;
    }
    
}
