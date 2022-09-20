using Unity.Jobs;
using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using System.Collections.Generic;

public class SpawnerAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity {
    
    public GameObject prefab;
    public int countX;
    public int countY;
    
    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs) {
        referencedPrefabs.Add(prefab);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        
        var data = new SpawnerData {
            Prefab = conversionSystem.GetPrimaryEntity(prefab),
            Ecols = countX,
            Erows = countY
        };

        dstManager.AddComponentData<SpawnerData>(entity, data);
    }
}
