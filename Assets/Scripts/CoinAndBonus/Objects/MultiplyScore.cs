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
        print("Multiply bonus Activated");
        collider.GetComponent<InteractionWithSubject>().MultiplyCoin();       //понять как переделать на евенты
        Destroy(this.gameObject);

        yield break;
    }
}
