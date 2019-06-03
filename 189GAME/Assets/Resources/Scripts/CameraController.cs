using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private float LerpDuration;
    private float currentLerpTime;
    private float startLerpTime;
    private Vector3 startPos;
    private Vector3 endPos;
    private float startRot;
    private float endRot;
    private float shakeDuration;
    private float shakeAmount;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        LerpDuration = 2f;
        startLerpTime = Time.time;
        startPos = transform.localPosition;
        endPos = startPos + new Vector3(0, 4.5f, 0);
        startRot = 90;
        endRot = 360;
        shakeDuration = 0.4f;
        shakeAmount = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Lerping camera position and rotation for boot up
        if (instance.currState == GameManager.gameState.bootUp)
        {
            currentLerpTime = Time.time - startLerpTime;
            float perc = currentLerpTime / LerpDuration;
            if (perc <= 1f)
            {
                transform.localPosition = Vector3.Lerp(startPos, endPos, perc);
                float rot = Mathf.Lerp(startRot, endRot, perc);
                transform.parent.localRotation = Quaternion.Euler(rot, 0, 0);
            }
            else
            {
                player.SetActive(true);
            }
        }


        if (instance.Health == 0)
        {
            shakeAmount = 1.0f;
            shakeDuration = 1.0f;
            instance.Health--;
        }

        // Shake camera when player is hit
        if (instance.hit)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = endPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime;
            }
            else
            {
                shakeDuration = 0.5f;
                instance.hit = false;
                transform.localPosition = endPos;
            }

        }

    }
}
