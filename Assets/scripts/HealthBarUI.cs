using UnityEngine;
using UnityEngine.UI;


public class HealthBarUI : MonoBehaviour
{
    public float health1, maxHealth1, width, height;



    [SerializeField] private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth2)
    {
        maxHealth1 = maxHealth2;
    }

    public void SetHealth(float health2)
    {
        health1 = health2;
        float newWidth = (health1 / maxHealth1) * width;
        healthBar.sizeDelta = new Vector2(newWidth, height);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
