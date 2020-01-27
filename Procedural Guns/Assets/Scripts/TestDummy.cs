using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{

    public float health = 100;

    void Update()
    {
        if (health <= 0)
            Die();
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
