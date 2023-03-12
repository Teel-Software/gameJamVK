using UnityEngine;
using UnityEngine.Serialization;

public class TableVariant : MonoBehaviour
{
    public GameObject StartSpawnPoint;
    public GameObject EndSpawnPoint;

    public AnimationCurve ChanceFromDistance;

    [FormerlySerializedAs("_visual")] public GameObject Visual;
}