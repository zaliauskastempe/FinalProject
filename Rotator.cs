using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float speed = 10f;
    private GameObject Player;
    private GameObject Shield;
    public GameObject Explosion;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        Shield = GameObject.FindWithTag("Shield");
    }

    void Update()
    {
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
        
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(Vector3.back * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            if (tag == "PowerUp")
                {
                    Player.GetComponent<PlayerController>().bomb++;
                    Instantiate(Explosion, other.transform.position, other.transform.rotation);
                }
            else if (tag == "ShieldPowerUp")
            {
                Shield.SetActive(true);
                Instantiate(Explosion, other.transform.position, other.transform.rotation);    
            }
            Destroy(gameObject);
        }
       
    }

}


