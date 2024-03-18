using UnityEngine;

[System.Serializable]
public struct ItemInfo
{
    public string name;
    public int id;
    public int count;
    public bool isUniq;
    public string description;
    public GameObject prefab;
    public bool slotted;
    public float timeUsingS;

    public ItemInfo(string _name, int _id, int _count, bool _isUniq,
        string _description, GameObject _prefab, bool _slotted, float _timeUsingS)
    {
        name = _name;
        id = _id;
        count = _count;
        isUniq = _isUniq;
        description = _description;
        prefab = _prefab;
        slotted = _slotted;
        timeUsingS = _timeUsingS;
    }
}
