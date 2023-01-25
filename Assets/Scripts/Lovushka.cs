using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lovushka : MonoBehaviour
{
    float tempSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tempSpeed = other.gameObject.GetComponent<Control>().speed;
            other.gameObject.GetComponent<Control>().speed = other.gameObject.GetComponent<Control>().speed / 5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Control>().speed = tempSpeed;
    }
}
