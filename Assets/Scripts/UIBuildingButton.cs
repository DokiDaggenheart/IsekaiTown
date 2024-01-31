// UIBuildingButton.cs
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingButton : MonoBehaviour
{
    public BuildingManager buildingManager;
    public BuildingData buildingData;

    public void BuildBuilding()
    {
        if (buildingManager != null)
        {
            buildingManager.buildingData = this.buildingData;
            buildingManager.CreatePreviewBuilding();
        }
    }
}
