using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PoolItem {
    public GameObject prefab;
    public int amount;
    public bool expandable;
}

public class Pool : MonoBehaviour {

    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    void Awake() {
        singleton = this;

        pooledItems = new List<GameObject>();

        foreach (PoolItem item in items) {
            for (int i = 0; i < item.amount; i++) {
                var obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    public GameObject Get(string tag) {
        foreach (GameObject item in pooledItems) {
            if (!item.activeInHierarchy && item.CompareTag(tag)) {
                return item;
            }
        }
        foreach (PoolItem item in items) {
            if (item.prefab.CompareTag(tag)) {
                if (item.expandable) {
                    var obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    pooledItems.Add(obj);
                    return obj;
                } else {
                    break;
                }
            }
        }
        return null;
    }

    public void PutBack(GameObject item) {
        item.SetActive(false);
    }
}
