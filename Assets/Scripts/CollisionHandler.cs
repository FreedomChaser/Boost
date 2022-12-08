using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I'm the launchpad.");
                break;

            case "Finish":
                Debug.Log("I'm the finish pad.");
                break;

            default:
                Debug.Log("I kill you!");
                break;
        }
    }
}