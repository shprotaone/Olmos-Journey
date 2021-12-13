using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private PlatformTypes _types;
    private WorldController _worldController;
    private SpawnerController _spawnerController;
    
    public PlatformTypes Type { get { return _types; } }

    public Transform centerPoint;
    public Transform endPoint;

    private void Awake()
    {
        _worldController = GetComponentInParent<WorldController>();
        

        if (_worldController != null)
        {
            _worldController.OnPlatformMovement += AddPlatform;
        }
    }

    private void Start()
    {
        _spawnerController = gameObject.GetComponent<SpawnerController>();
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
