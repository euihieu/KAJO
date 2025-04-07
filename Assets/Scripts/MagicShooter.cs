using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class magicShooter : MonoBehaviour
{
public float magicSpeed;  // taian nopeus
public new Rigidbody2D rigidbody2D;  // taian Rigidbody2D komponentti
public Transform playerTransform;  // Pelaajan transform (sijainti ja suunta)
[SerializeField] GameObject impact; // tuhoutumis effecti




     void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  // Hae rigidbody2D
        ShootMagic();  
        Debug.Log("start");
    }
    void ShootMagic()
    {
        // Tarkistetaan pelaajan suunta (käännä suunta riippuen siitä, onko pelaaja kääntynyt vasemmalle vai oikealle)
        Vector2 direction = playerTransform.right;  // Pelaajan suunta

        // Jos pelaaja katsoo vasemmalle, käännä suunta negatiiviseksi
        if (playerTransform.localScale.x < 0)
        {
            direction = -direction;
        }

        // Asetetaan rigidbodyn velocity liikkumaan pelaajan katsomaan suuntaan
        rigidbody2D.linearVelocity = direction * magicSpeed;  // Ammuksen nopeus ja suunta
        Debug.Log("ShootMagic");
    }
    //void OnTriggerEnter2D(Collider2D other) 
    //{
    //    if (other.CompareTag("TargetDummy"))
    //    {
    //    GameObject impactDestroyer = Instantiate(impact, transform.position, Quaternion.identity);
    //    Destroy(impactDestroyer,1f);
    //    Destroy(other.gameObject);
    //    Debug.Log("Destroy");
    //    }
    //}
    
}
