using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : InterractableObject
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
        int index = Randomizer();
        collider.GetComponent<InteractionWithSubject>().Gift(index);
        print(index);
        Destroy(this.gameObject);
        
        yield return null;
    }
    private int Randomizer()
    {
        int result = Random.Range(0, 3);
        return result;
    }
}
