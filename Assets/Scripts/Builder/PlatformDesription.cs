using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDesription : MonoBehaviour
{
    [SerializeField] private PlatformTypes _types;
    private WorldController _worldController;
    
    public PlatformTypes Type { get { return _types; } }

    public Transform centerPoint;
    public Transform endPoint;    

    private void Start()
    {
        _worldController = GetComponentInParent<WorldController>();
        if (_worldController != null)
        {
            _worldController.OnPlatformMovement += AddPlatform;
        }
        else
        {
            print("WorldControllerNotFound");
        }       
    }

    private void AddPlatform()
    {
        if(transform.position.z < _worldController.MinZ)
        {
            _worldController.CreatePlatform();
            DeletePlatform();
        }
    }

    private void DeletePlatform()
    {
        Destroy(this.gameObject);
        _worldController.OnPlatformMovement -= AddPlatform;
    }
}
