using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] GameObject obj;        //������ ������Ʈ ����


    public void DestroyObj()
    {
        Destroy(obj);
    }
}
