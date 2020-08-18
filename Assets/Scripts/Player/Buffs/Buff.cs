using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Stats/Buff")]
public class Buff : ScriptableObject
{
    public bool isDebuff = false;
    public float amount;
    public float duration;
    public StatusType type;
}
