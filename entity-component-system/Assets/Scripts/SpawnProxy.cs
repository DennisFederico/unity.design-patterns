using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity {

    public GameObject ECSObject;
    public int rows;
    public int cols;


    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs) {
        referencedPrefabs.Add(ECSObject);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        
        var spawnerData = new SpawnerData {
            Prefab = conversionSystem.GetPrimaryEntity(ECSObject),
            Erows = rows,
            Ecols = cols
        };
        dstManager.AddComponentData(entity, spawnerData);
    }

}
