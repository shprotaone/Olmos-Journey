using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBalance : MonoBehaviour
{
    [SerializeField] private Balance _balancePreset;

    public static float speed;
    public static float increaseSpeed;
    public static float distanceToUpDifficult;
    public static float movement;
    public static float jumpForce;
    public static float gravity;
    public static float gravityToDrop;

    public static int scoreMultiplyBonusValue;
    public static int coinMultiplyBonus;
    public static int[] chancesBonus;
    public static int[] chancesZones;
    public static int chanceZone;
    public static int chanceBonus;
    public static int speedBonusValue;
    public static int stopBonusValue;
    

    void Awake()
    {
        LoadPreset();
    }

    private void LoadPreset()
    {
        speed = _balancePreset.speed;
        increaseSpeed = _balancePreset.increaseSpeed;
        distanceToUpDifficult = _balancePreset.distanceToUpDifficult;
        movement = _balancePreset.steering;
        jumpForce = _balancePreset.jumpForce;
        gravity = _balancePreset.gravity;
        gravityToDrop = _balancePreset.gravityToDrop;
        scoreMultiplyBonusValue = _balancePreset.scoreMultiplyBonusValue;
        coinMultiplyBonus = _balancePreset.coinMultiplyBonus;

        chancesBonus = new int[] {
            _balancePreset.chanceEmpty,
            _balancePreset.chanceGiftType1,
            _balancePreset.chanceGiftType2,
            _balancePreset.chanceGiftType3,
            
            _balancePreset.magnetBonus,
            _balancePreset.multiplyBonus};

        chancesZones = new int[] {
            _balancePreset.speedingZone,
            _balancePreset.stoppingZone };

        speedBonusValue = _balancePreset.speedBonusValue;
        stopBonusValue = _balancePreset.stopBonusValue;
        chanceZone = _balancePreset.chanceZone;
        chanceBonus = _balancePreset.chanceBonus;
    }
}
