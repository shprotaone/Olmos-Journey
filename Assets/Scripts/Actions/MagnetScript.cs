using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    [SerializeField] private GameObject _coinDetector;
    public Transform PlayerTransform { get; private set; }

    void Start()
    {
        PlayerTransform = gameObject.GetComponentInParent<Transform>();
    }

   public IEnumerator MagnetActivate()
    {
        _coinDetector.SetActive(true);
        print("MagnetActivate");
        yield return new WaitForSeconds(10f);
        print("Disactivate");
        _coinDetector.SetActive(false);
    }

    //в будущем добавить наложение при сборе 2х бонусов Магнита

}
