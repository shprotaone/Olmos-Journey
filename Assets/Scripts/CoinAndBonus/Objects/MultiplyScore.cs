using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyScore : InterractableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));
        }
    }

    public override IEnumerator Action(Collider collider)
    {
        collider.GetComponent<InteractionWithSubject>().MultiplyCoin();       //понять как переделать на евенты

        yield break;
    }
}
