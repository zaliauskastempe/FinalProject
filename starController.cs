using UnityEngine;
using System.Collections;

public class starController : MonoBehaviour
{
    public GameObject Game;
    private ParticleSystem ps;
    //public float hSliderValue = 5.0f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        if (Game.GetComponent<GameController>().won == true)
        {
            main.simulationSpeed = main.simulationSpeed+0.03f;
        }
       // ps.emission.rateOverTime = 5.0f; //But this doesn't?
    }


}