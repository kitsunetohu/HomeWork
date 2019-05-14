using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float   health;      // Enemy's HP
    private float damageRate;

    void Start() {
        // Temp
        health     = 100;
        damageRate = 50;
    }

    void Update() {
    }

    public void GetDamage() {
        health -= damageRate * Time.deltaTime;
        if(health < 0)
            this.Death();
    }

    private void Death() {
        gameObject.SendMessage("KilledEnemy");
        Destroy(gameObject);
    }
}
