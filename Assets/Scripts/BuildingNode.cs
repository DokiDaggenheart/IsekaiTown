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

    // ����� ��� ��������� ���� ������ � ������
    public void SetBuildingType(string type)
    {
        buildingType = type;
    }

    // ����� ��� ��������, ������ �� ������
    public bool IsOccupied()
    {
        return isOccupied;
    }

    // ����� ��� ������� ������
    public void Occupy()
    {
        isOccupied = true;
    }

    // ����� ��� ������������ ������
    public void Release()
    {
        isOccupied = false;
        buildingType = null;
    }
}
