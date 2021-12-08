using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingZone : InterractableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));            
            print("SpeedingZone");
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        collider.GetComponent<InteractionWithSubject>().IncreaseSpeed();    //понять как переделать на евенты
        Destroy(this.gameObject);
                                                                            //
        yield break;
    }
}
