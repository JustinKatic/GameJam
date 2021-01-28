using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPos : MonoBehaviour
{
    Vector3 startPos;
    GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        startPos = player.transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = startPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
