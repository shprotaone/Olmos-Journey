using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private GameObject _gift;

    private void Start()
    {
        _gift = this.gameObject;
    }

    private void Update()
    {
        _gift.transform.Rotate(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ScoreSystem>().CatchUpPoint();
            other.GetComponent<ScoreSystem>().GiftCounter();
            Destroy(this.gameObject);
        }
    }
}
