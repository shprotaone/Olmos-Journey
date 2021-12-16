using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : InterractableObject
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
        collider.GetComponent<InteractionWithSubject>().MagnetActivate();
        Destroy(this.gameObject);

        yield return null;
    }
}
