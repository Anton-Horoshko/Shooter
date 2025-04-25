using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform enemy;

    void Start()
    {
        
    }

    void Update()
    {
        Idle();
    }

    public void Idle()
    {
        enemy.transform.position += Random.onUnitSphere * 0.1f;
    }

}
