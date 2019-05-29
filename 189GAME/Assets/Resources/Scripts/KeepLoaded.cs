using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLoaded : MonoBehaviour
{
    private static KeepLoaded instance = null;
    public static KeepLoaded Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
