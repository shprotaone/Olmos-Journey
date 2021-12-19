using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingZone : InterractableObject
{
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
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
        collider.GetComponent<InteractionWithSubject>().IncreaseSpeed();

        if(_source != null)
        {
            _source.Play();
        }
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
                                                                            
        yield break;
    }
}
