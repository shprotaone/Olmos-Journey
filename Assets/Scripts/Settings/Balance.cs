using UnityEngine;

[CreateAssetMenu(fileName = "BalanceSettings", menuName = "CreateNewBalanceFile", order = 53)]
public class Balance : ScriptableObject
{
    [Range(0f,50f)]
    public float speed;
    [Range(0f,10)]
    public float increaseSpeed;
    [Range(-500,500)]
    public float distanceToUpDifficult;
    [Range(5,15)]
    public float movement;
    [Range(10,50)]
    public float jumpForce;
    [Range(10,50)]
    public float gravity;
    [Range(20,100)]
    public float gravityToDrop;
    public float divideFirstLayerBackground;
    public float divideSecondLayerBackground;
    public float divideThirdLayerBackground;
    public float divideFourLayerBackground;
    public float scoreMultiplyBonus;
    public float coinMultiplyBonus;
    [Range(0,500)]
    public int chanceEmpty;
    [Range(0,100)]
    public int chanceGiftType1;
    [Range(0, 100)]
    public int chanceGiftType2;
    [Range(0, 100)]
    public int chanceGiftType3;
    [Range(0, 100)]
    public int chanceBonusType1;
    [Range(0, 100)]
    public int chanceBonusType2;
    [Range(0, 100)]
    public int chanceBonusType3;
    [Range(0, 100)]
    public int chanceCoinOrBonus;
}
