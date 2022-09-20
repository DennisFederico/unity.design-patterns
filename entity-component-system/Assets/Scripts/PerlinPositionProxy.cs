using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PerlinPositionProxy : MonoBehaviour, IConvertGameObjectToEntity {

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        
        var data = new PerlinPosition {};
        dstManager.AddComponentData<PerlinPosition>(entity, data);
    }
}
