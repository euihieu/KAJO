using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    //public HealthSystem script; // kutsutaan health scripti
    //pelaajan Transform.position paikka.
    [SerializeField] Transform playerPosition;

    //vihollisen Rigidbody componentti liikkuvuuden arvojen tunnistamiseen.
    [SerializeField] Rigidbody2D enemyRb; 

    //vihollisen seuraamis nopeus.
    [SerializeField] float EnemySpeed;

    //tässä kutsumme vielä BasicEnemy objectia jotta pystymme tuhomaan sen
    [SerializeField] GameObject BasicEnemy;
    //vihollisen tuhoamis effectti
    [SerializeField] GameObject Impact;
    //-----------------------------------------------------------------------------------
    [SerializeField] int EnHealth; //vihollinen
    [SerializeField] int PlAttack; //pelaajan hyökkäys
     //-----------------------------------------------------------------------------------

    //tässä haluamme löytää SpriteRenderin oman ominaisuuden Flip, joka kääntää Spriten toisinpäin:)
    SpriteRenderer spriteRend;
    

    void Start()
    {
        //Flip varten. tässä vielä varmistamme SpriteRendererin käyttöön oton ennen muiden funtioiden käyttöön ottoja 
        //start ajaa ensimmäisen framen yhden kerran ja lakkaa toimimasta tämän jälkeen
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //tässä kutsumme itse tekemää funktiota C# kielen omaan Update metodiin. 
        //Updaten oma ominaisuus päivittää enemyMovementAndFlip funktiotamme joka framella, mitä pelin aikana käydään läpi.   
        enemyMovementAndFlip();
    }

    private void enemyMovementAndFlip() 
    {
        //tässä kutsumme vihollisen seuraamaan pelaajaa käyttäen.
        Vector2 direction = (playerPosition.position - transform.position).normalized;
        enemyRb.linearVelocity = direction * EnemySpeed;
        //tässä otamme direction nimisen vector2 arvon ja käytämme sitä transform.flip.xAxien kanssa vaihtamaan Spriten suuntaa,
        //väitteellä tosi vai ei:)
        if (direction.x > 0)
        {spriteRend.flipX = true;}

        else if (direction.x < 0) 
        {spriteRend.flipX = false;}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MagicBall")
        {
            EnHealth -= PlAttack;
            GameObject impactDestroyer = Instantiate(Impact, transform.position, Quaternion.identity);
            Destroy(impactDestroyer,1f);
            spriteRend.color = Color.red;//vaihdetaan enemy objectin väriä
        } // lasketaan vihollisen elämät pelaajan hyökkäyksestä
        //"lisää viholliselle Health arvon"

        if (collision.gameObject.CompareTag("MagicBall") && EnHealth <= 0)
        {
            
            Destroy(gameObject);
            Destroy(BasicEnemy);
            GameObject impactDestroyer = Instantiate(Impact, transform.position, Quaternion.identity);
            Destroy(impactDestroyer,1f);
        }
    }
}