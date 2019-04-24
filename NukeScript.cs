using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    public GameObject explosionnuke;
    public Vector3 spawnValues;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private int i;
    // Start is called before the first frame update

    void Start()
    {
        i = 0;
        StartCoroutine(Waiter());
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    IEnumerator Waiter()
    {
        for (i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(explosionnuke, spawnPosition, Quaternion.identity);
            Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(explosionnuke, spawnPosition2, Quaternion.identity);
            Vector3 spawnPosition3 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(explosionnuke, spawnPosition3, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (i == 50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") ||  other.CompareTag("PowerUp") || other.CompareTag("Player") || other.CompareTag("Effect"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }


        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);

    }
}


