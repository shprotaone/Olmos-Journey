using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _gift;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private CurrentGameDataContainer _dataContainer;
    [SerializeField] private float _force;
    [SerializeField] private float y;
    [SerializeField] private float z;

    private bool _launch;

    private void Start()
    {
        if(!_dataContainer.firstGift)
        SpawnFirstGift();
    }

    public void LaunchGift(Transform shootPoint)
    {
        if (!_launch && _dataContainer.firstGift)
        {
            GameObject gift = Instantiate(_gift, shootPoint);
            gift.GetComponent<Rigidbody>().AddForce(new Vector3(0, y, z) * _force);
            _launch = true;
        }       
    }

    public void SpawnFirstGift()
    {
        GameObject gift = Instantiate(_gift, _shootPoint);
        gift.GetComponent<Rigidbody>().isKinematic = true;
    }
}
