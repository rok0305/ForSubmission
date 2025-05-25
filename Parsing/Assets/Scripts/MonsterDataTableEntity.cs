using UnityEngine;
[System.Serializable]
public class MonsterDataTableEntity
{
    public int ID;
    public string NameString;
    public Status status = new Status();

    [System.Serializable]
    public class Status
    {
        public float ATK;
        public float DEF;
        public int MaxHP;
    }
}
/*public class Status
{
    public float ATK;
    public float DEF;
    public int MaxHP;
}*/