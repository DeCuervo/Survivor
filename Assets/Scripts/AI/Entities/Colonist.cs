using UnityEngine;
using WorldAPI.Tasks.Generic;

public partial class Colonist : ResourceGatherer<Colonist>
{
    public new void Start()
    {
        base.Start();

        Health = 10 + Random.Range(0, 5);
        MaxHealth = Health;

        Damage = 1 + Random.Range(0, 3);

        QueueTask(new IdleTask<Colonist>());
    }

    public new void Update()
    {
        base.Update();
    }
}

public partial class Colonist { 
    private static GameObject _prefab = null;

    public static Colonist New(string name = "Colonist", Vector3? location = null, Faction faction = null)
    {
        if (_prefab == null)
            _prefab = Resources.Load("Prefabs/Colonist") as GameObject;

        Colonist colonist = (location == null ? Instantiate(_prefab) : Instantiate(_prefab, (Vector3)location, Quaternion.identity)).GetComponent<Colonist>();

        colonist.gameObject.name = name;
        colonist.Faction = faction;
        colonist.QueueTask(new GatherResourceTask<Colonist>(Material.Stone));

        return colonist;
    }
}
