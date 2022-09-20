using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour {
    [SerializeField]
    private PlantData plantData;

    SetPlantInfo setPlantInfo;

    void Start() {
        setPlantInfo = GameObject.FindGameObjectWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    void OnMouseDown() {
        setPlantInfo.OpenPlantPanel();
        setPlantInfo.planeName.text = plantData.plantName;
        setPlantInfo.phreatLevel.text = plantData.plantThreat.ToString();
        setPlantInfo.plantIcon.GetComponent<RawImage>().texture = plantData.icon;
    }
}
