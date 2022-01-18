using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private DropSpawner _bonusSpawner;
    private ZoneSpawner _zoneSpawner;

    private bool _bonus;
    private bool _zone;
    private int _chance;
    private int _chanceZone;

    public void Start()
    {
        _bonus = new RandomLogic().TrueFalseRandomizer(LoadBalance.chanceBonus);
        _zone = new RandomLogic().TrueFalseRandomizer(LoadBalance.chanceZone);

        _bonusSpawner = GetComponent<DropSpawner>();
        _zoneSpawner = GetComponent<ZoneSpawner>();

        _chance = new RandomLogic().SumForRandomSystem(LoadBalance.chancesBonus);
        _bonusSpawner.InstantiateBonus(_chance);

        if (_zoneSpawner != null)
        {
            if (_zone)
            {
                _chanceZone = new RandomLogic().SumForRandomSystem(LoadBalance.chancesZones);
                _zoneSpawner.InstantiateZone(_chanceZone);
            }
        }

    }
}
