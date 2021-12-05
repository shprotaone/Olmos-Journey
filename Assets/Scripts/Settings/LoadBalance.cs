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
    public static float divideFirstLayerBackground;
    public static float divideSecondLayerBackground;
    public static float divideThirdLayerBackground;
    public static float divideFourLayerBackground;
    public static float scoreMultiplyBonus;
    public static float coinMultiplyBonus;
    public static int chanceEmpty;
    public static int chanceGiftType1;
    public static int chanceGiftType2;
    public static int chanceGiftType3;
    public static int chanceBonusType1;
    public static int chanceBonusType2;
    public static int chanceBonusType3;
    public static int chanceCoinOrBonus;

    void Awake()
    {
        LoadPreset();
    }

    private void LoadPreset()
    {
        speed = _balancePreset.speed;
        increaseSpeed = _balancePreset.increaseSpeed;
        distanceToUpDifficult = _balancePreset.distanceToUpDifficult;
        movement = _balancePreset.movement;
        jumpForce = _balancePreset.jumpForce;
        gravity = _balancePreset.gravity;
        gravityToDrop = _balancePreset.gravityToDrop;
        divideFirstLayerBackground = _balancePreset.divideFirstLayerBackground;
        divideSecondLayerBackground = _balancePreset.divideSecondLayerBackground;
        divideThirdLayerBackground = _balancePreset.divideThirdLayerBackground;
        divideFourLayerBackground = _balancePreset.divideFourLayerBackground;
        scoreMultiplyBonus = _balancePreset.scoreMultiplyBonus;
        coinMultiplyBonus = _balancePreset.coinMultiplyBonus;
        chanceEmpty = _balancePreset.chanceEmpty;
        chanceGiftType1 = _balancePreset.chanceGiftType1;
        chanceGiftType2 = _balancePreset.chanceGiftType2;
        chanceGiftType3 = _balancePreset.chanceGiftType3;
        chanceBonusType1 = _balancePreset.chanceBonusType1;
        chanceBonusType2 = _balancePreset.chanceBonusType2;
        chanceBonusType3 = _balancePreset.chanceBonusType3;
        chanceCoinOrBonus = _balancePreset.chanceCoinOrBonus;
        print("In Game Update Activated");
    }

    public void InGame()
    {
        LoadPreset();
    }
}
