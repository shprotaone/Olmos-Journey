using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _gift;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _force;
    [SerializeField] private float y;
    [SerializeField] private float z;

    private bool _launch;


    public void LaunchGift(Transform shootPoint)
    {
        if (!_launch)
        {
            GameObject gift = Instantiate(_gift, shootPoint);
            gift.GetComponent<Rigidbody>().AddForce(new Vector3(0, y, z) * _force);
            _launch = true;
        }       
    }
}
