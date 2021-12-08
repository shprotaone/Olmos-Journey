using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingZone : InterractableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));
            print("StoppingZone");
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        collider.GetComponent<InteractionWithSubject>().DecreaseSpeed();
        Destroy(this.gameObject);

        yield break;
    }
}


