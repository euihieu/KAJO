
using UnityEngine;
public class EnemyTwo : MonoBehaviour
{
    [SerializeField] Transform B;
    [SerializeField] Transform A;
    [SerializeField] float EnemyMovementSpeed;
    private bool movementTrueFalse;
   ////////////////////////////////////////////////////////////////////////////

    [SerializeField] GameObject EnemyTWO;
    [SerializeField] GameObject Impact;
    [SerializeField] int EnHealth; //vihollinen
    [SerializeField] int PlAttack; //pelaajan hyökkäys
    SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        EnemyMovement();
    }
    private void EnemyMovement()
    {
        if (movementTrueFalse)
        {
            transform.position = Vector3.MoveTowards(transform.position,B.position , EnemyMovementSpeed * Time.deltaTime);
            if (transform.position == B.position)
            {movementTrueFalse = false;}
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, A.position , EnemyMovementSpeed * Time.deltaTime);
            if(transform.position == A.position)
            {movementTrueFalse = true;}
        }
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
            Destroy(EnemyTWO);
            GameObject impactDestroyer = Instantiate(Impact, transform.position, Quaternion.identity);
            Destroy(impactDestroyer,1f);
        }
    }
}