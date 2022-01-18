using UnityEngine;

[CreateAssetMenu(fileName = "BalanceSettings", menuName = "CreateNewBalanceFile", order = 53)]
public class Balance : ScriptableObject
{
    [Header("Movement")]
    [Range(0f, 50f)]
    public float speed;
    [Range(5, 50)]
    public float steering;
    [Range(10, 50)]
    public float jumpForce;
    [Range(10, 50)]
    public float gravity;
    [Range(20, 100)]
    public float gravityToDrop;
    [Header("GameBalance")]
    [Range(0f, 10)]
    public float increaseSpeed;
    [Range(-500, 500)]
    public float distanceToUpDifficult;
    public int scoreMultiplyBonusValue;
    public int coinMultiplyBonus;
    public int speedBonusValue;
    public int stopBonusValue;

    [Header("RandomSystem")]
    [Range(0, 200)]
    public int chanceEmpty;
    [Range(0, 100)]
    public int chanceGiftType1;
    [Range(0, 100)]
    public int chanceGiftType2;
    [Range(0, 100)]
    public int chanceGiftType3;
    [Range(0, 100)]
    public int magnetBonus;
    [Range(0, 100)]
    public int multiplyBonus;
    [Range(0, 100)]
    public int speedingZone;
    [Range(0, 100)]
    public int stoppingZone;
    [Range(0, 100)]
    public int chanceZone;
    [Range(0,100)]
    public int chanceBonus;
}
