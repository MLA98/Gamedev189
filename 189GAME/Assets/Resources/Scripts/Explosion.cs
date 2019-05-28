using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float LerpDuration;
    private float currentLerpTime;
    private float startLerpTime;
    private Vector3 startScale;
    private Vector3 endScale;

    // Start is called before the first frame update
    void Start()
    {
        LerpDuration = 2f;
        startLerpTime = Time.time;
        startScale = transform.localScale;
        endScale = transform.localScale * 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentLerpTime = Time.time - startLerpTime;
        float perc = currentLerpTime / LerpDuration;
        Debug.Log(perc);
        transform.localScale = Vector3.Lerp(startScale, endScale, perc);
        if (perc >= 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
