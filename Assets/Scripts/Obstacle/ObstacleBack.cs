using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBack : Obstacle
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().CanTurn = true;
            other.GetComponent<PlayerController>().ReturnPosition();

            GetDamage(other);
            EffectActivate(other);
        }
    }
}
