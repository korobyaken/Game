using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public GameObject DamagePrefab;
    private int MaxHealthPoints = 100;
    private int HealthPoints;

    public TMP_Text CoinsText;
    
    public int Coins = 0;
    public static int CoinsKoef = 1;
    void Start()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void GetDamage(int damage)
    {
        DamagePrefab.GetComponentInChildren<TMP_Text>().text = damage.ToString();
        DamagePrefab.transform.LookAt(transform);//GetComponent<LookAtConstraint>().AddSource(transform.LookAt());//.SetSource(0, gameObject.transform);
        Instantiate(DamagePrefab, this.gameObject.transform.position + new Vector3(0, 1 ,0), gameObject.transform.rotation);
        if (HealthPoints <= damage)
        {
            HealthPoints = 0;
            DeathLogic();
        }
        else
        {
            HealthPoints -= damage;
        }
    }

    private void DeathLogic()
    {
        Perehod.Lose();
    }

    public void AddCoin()
    {
        Coins += 1 * CoinsKoef;
        CoinsText.text = $"Coins: {Coins}";
        PlayerPrefs.SetInt("coins", Coins);
    }
}
