using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    [SerializeField] private PlatformContainer _platform;
    [SerializeField] private Transform _platformContainer;
    
    private Transform _lastPlatform = null;
    private Vector3 _lastPlatformPosition;
    private Vector3 _offsetPlatform = new Vector3(0, 0, 7.5f);

    private bool isObstacle;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateFreePlatform();
        }

        for (int i = 0; i < 5; i++)
        {
            CreateNextPlatform();
        }
    }

    public void CreateNextPlatform()
    {
        if (isObstacle)
        {
            CreateFreePlatform();
            isObstacle = false;
        }
        else
        {
            CreateObstaclePlatform();
            isObstacle = false;
        }
    }

    private void CreateFreePlatform()
    {
        if(_lastPlatform == null)
        {
            _lastPlatformPosition = _platformContainer.position;
        }
        else
        {
            _lastPlatformPosition = _lastPlatform.GetComponent<PlatformDesription>().endPoint.position;
        }
        Vector3 instatiatePos = _lastPlatformPosition + _offsetPlatform;

        GameObject platform = Instantiate(_platform.platforms[0], instatiatePos, Quaternion.identity, _platformContainer);
        
        platform.GetComponent<GiftSpawner>().SpawnBonus();

        _lastPlatform = platform.transform;        
    }

    private void CreateObstaclePlatform()
    {
        _lastPlatformPosition = _lastPlatform.GetComponent<PlatformDesription>().endPoint.position;

        Vector3 instatiatePos = _lastPlatformPosition + _offsetPlatform;

        GameObject platform = Instantiate(_platform.platforms[PlatformSelector()], instatiatePos, Quaternion.identity, _platformContainer);

        platform.GetComponent<GiftSpawner>().SpawnBonus();

        _lastPlatform = platform.transform;
    }

    private int PlatformSelector()
    {
        int range = _platform.platforms.Length-1;

        return Random.Range(1, range);        
    }
}
