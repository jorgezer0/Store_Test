using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [YarnCommand("open_store")]
    public static void OpenStore()
    {
        Debug.Log("Open Store");
    }
}
