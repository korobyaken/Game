using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapkan : MonoBehaviour
{
    public GameObject gp;
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GetDamage(20);
        }
    }
}
