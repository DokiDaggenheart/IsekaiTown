// BuildingData.cs
using UnityEngine;

[CreateAssetMenu(fileName = "New Building Data", menuName = "Building Data")]
public class BuildingData : ScriptableObject
{
    public string buildingType;
    public int cost;
    public Vector2 size;
    public GameObject buildingPrefab;
}
