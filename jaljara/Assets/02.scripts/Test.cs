using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Test : MonoBehaviour
{

    [SerializeField] GameObject obj;        //������ ������Ʈ ����

    public void DestroyObj()
    {
        Destroy(obj);
    }

}