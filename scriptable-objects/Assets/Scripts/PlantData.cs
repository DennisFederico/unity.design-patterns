using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "PlantData", order = 51)]
public class PlantData : ScriptableObject {

    public enum THREAT { None, Low, Moderate, High }

    [field: SerializeField]
    public string plantName { private set; get; }

    [field: SerializeField]
    public THREAT plantThreat { private set; get; }

    [field: SerializeField]
    public Texture icon { private set; get; }

}