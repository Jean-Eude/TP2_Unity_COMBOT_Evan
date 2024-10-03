using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinsBehaviour : MonoBehaviour
{
    private AudioSource collisionSound;
    public GameObject worldObject;
    
    void Start() {

        collisionSound = GameObject.Find("World").GetComponent<AudioSource>();
        worldObject = GameObject.Find("World");
    }

    void OnTriggerEnter(Collider other) {
    	worldObject.SendMessage("AddHit");

        if (other.CompareTag("Player")) {

            if (collisionSound) {
                collisionSound.Play(); 
            }

            Destroy(gameObject, 0);
        }
    }
}

