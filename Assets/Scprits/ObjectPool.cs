using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public static ObjectPool _instance;

    Stack<GameObject> pool;
    private void Awake()
    {
        _instance = this;
        pool = new Stack<GameObject>();
    }
    void Start () {
	}
	
	public void Delete(GameObject go)
    {
        go.SetActive(false);
        pool.Push(go);
    }

    //从对象池中取出对象
    public GameObject Creat(GameObject prefab,Vector3 pos,Quaternion qua )
    {
        GameObject go = null;
        if (pool.Count>0)
        {
          go=  pool.Pop();
            go.SetActive(true);
            go.transform.position = pos;
            go.transform.rotation = qua;
        } else
        {
          go=  Instantiate(prefab, pos, qua);
           // go.SetActive(true);
        }
        return go;
    }
	
}
