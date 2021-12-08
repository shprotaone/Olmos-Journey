using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private CoinSpawner _coinSpawner;
    private BonusSpawner _bonusSpawner;
    private ZoneSpawner _zoneSpawner;

    private bool _bonus;
    private bool _zone;
    private int _chance;
    private int _chanceZone;

    private void Start()
    {
        _bonus = new RandomLogic().TrueFalseRandomizer();
        _zone = new RandomLogic().TrueFalseRandomizer();

        _coinSpawner = GetComponent<CoinSpawner>();
        _bonusSpawner = GetComponent<BonusSpawner>();
        _zoneSpawner = GetComponent<ZoneSpawner>();

        if (!_bonus)
        {
            _chance = new RandomLogic().SumForRandomSystem(LoadBalance.chancesCoin);
            _coinSpawner.InstantiateCoin(_chance);
        }
        else
        {
            _chance = new RandomLogic().SumForRandomSystem(LoadBalance.chancesBonus);
            _bonusSpawner.InstantiateBonus(_chance);
        }

        if (_zone)
        {
            _chanceZone = new RandomLogic().SumForRandomSystem(LoadBalance.chancesZones);
            _zoneSpawner.InstantiateZone(_chanceZone);
        }
    }
}
