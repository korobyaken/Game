using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("DownMove");
    }

    IEnumerator DownMove()
    {
        if (gameObject.transform.position.y < -2)
        {
            Destroy(gameObject);
        }
        while (true)
        {
            Vector3 downVector = new Vector3(0, -1, 0) * Time.deltaTime;
            this.transform.position += downVector;
            yield return null;
            
        }
    }
}
