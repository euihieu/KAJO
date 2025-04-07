using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int PlHealth; //pelaaja
    [SerializeField] int PlAttack; //pelaajan hyökkäys
    [SerializeField] int EnHealth; //vihollinen
    [SerializeField] int EnAttack; // vihollisen hyökkäys
    [SerializeField] private Slider healthBar;
    [SerializeField] GameObject PlayerObject;


    private void HealthSystemExit() 
   {
     Destroy(gameObject);
   }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
         PlHealth -= EnAttack;
         UpdateHealthBar();
        }
        if (PlHealth <= 0)
        {
        HealthSystemExit();
        }
    }
    // Päivittää terveyspalkin
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (int)PlHealth;  // Päivitetään UI:n terveyspalkki
        }
    }
}