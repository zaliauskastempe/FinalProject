using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public GameObject Game;
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (Game.GetComponent<GameController>().won == true)
        {
            scrollSpeed = scrollSpeed -0.0025f;
        }

    }
}