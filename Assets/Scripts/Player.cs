using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public GameObject damagePrefab;
    private int maxHealthPoints = 100;
    private int healthPoints;
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    public void GetDamage(int damage)
    {
        damagePrefab.GetComponentInChildren<TMP_Text>().text = damage.ToString();
        damagePrefab.transform.LookAt(transform);//GetComponent<LookAtConstraint>().AddSource(transform.LookAt());//.SetSource(0, gameObject.transform);
        Instantiate(damagePrefab, this.gameObject.transform.position + new Vector3(0, 1 ,0), gameObject.transform.rotation);
        if (healthPoints <= damage)
        {
            healthPoints = 0;
            DeathLogic();
        }
        else
        {
            healthPoints -= damage;
        }
    }

    private void DeathLogic()
    {
        Perehod.Lose();
    }
}
