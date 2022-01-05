using System.Collections;
using UnityEngine;

public class Fly : InterractableObject
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
        //collider.GetComponent<InteractionWithSubject>().Fly();
        Destroy(this.gameObject);

        yield break;
    }
}
