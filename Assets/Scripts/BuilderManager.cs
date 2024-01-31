using UnityEngine;
using CodeMonkey.Utils;

public class BuildingManager : MonoBehaviour
{
    public NavMeshPlus.Components.NavMeshSurface navMeshSurface;

    public BuildingData buildingData;
    public Color validPlacementColor = Color.green;
    public Color invalidPlacementColor = Color.red;

    private GameObject previewBuilding;
    private SpriteRenderer previewRenderer;
    private bool isBuilding;

    private void Build()
    {
        if (isBuilding) {
            UpdatePreviewBuildingPosition();
            UpdatePreviewBuildingColor();
            if (Input.GetMouseButtonDown(0) && CanBuildAtPosition())
            {
                Instantiate(buildingData.buildingPrefab, previewBuilding.transform.position, Quaternion.identity);
                isBuilding = false;
                Destroy(previewBuilding.gameObject);
                BakeNavMesh();
            }
        }
        
    }

    private void Update()
    {
        Build();
    }

    public void CreatePreviewBuilding()
    {
        if(buildingData.cost <= UIController.GetMoney())
        {
            UIController.TakeMoney(buildingData.cost);
            isBuilding = true;
            previewBuilding = Instantiate(buildingData.buildingPrefab);
            previewRenderer = previewBuilding.GetComponent<SpriteRenderer>();
            previewRenderer.color = validPlacementColor;
        }
        
    }

    private void UpdatePreviewBuildingPosition()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        mousePosition.z = 0f;
        previewBuilding.transform.position = mousePosition;
    }

    private void UpdatePreviewBuildingColor()
    {
        previewRenderer.color = CanBuildAtPosition() ? validPlacementColor : invalidPlacementColor;
    }

    private bool CanBuildAtPosition()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(previewBuilding.transform.position, previewBuilding.GetComponent<BoxCollider2D>().size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != previewBuilding)
            {
                return false;
            }
        }

        return true;
    }
    void BakeNavMesh()
    {
        if (navMeshSurface != null)
        {
            // Вызываем Bake асинхронно
            StartCoroutine(BakeAsync());
        }
        else
        {
            Debug.LogError("NavMeshSurface не установлен!");
        }
    }

    System.Collections.IEnumerator BakeAsync()
    {
        AsyncOperation operation = navMeshSurface.BuildNavMeshAsync();
        yield return operation;

        Debug.Log("Bake завершен");
    }

}