public class BuildingNode
{
    public int x;
    public int y;
    public bool isOccupied;
    public string buildingType;

    public BuildingNode(int x, int y)
    {
        this.x = x;
        this.y = y;
        isOccupied = false;
        buildingType = null;
    }

    // Метод для установки типа здания в ячейке
    public void SetBuildingType(string type)
    {
        buildingType = type;
    }

    // Метод для проверки, занята ли ячейка
    public bool IsOccupied()
    {
        return isOccupied;
    }

    // Метод для занятия ячейки
    public void Occupy()
    {
        isOccupied = true;
    }

    // Метод для освобождения ячейки
    public void Release()
    {
        isOccupied = false;
        buildingType = null;
    }
}
