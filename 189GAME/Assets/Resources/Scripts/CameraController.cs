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

        if (instance.currState == GameManager.gameState.title)
        {
            startLerpTime = Time.time;
        }
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

        if (instance.Health <= 0 && instance.Health >= -9)
        {
            shakeAmount = 1.0f;
            shakeDuration = 1.0f;
            instance.Health -= 10;
        }

        // Shake camera when player is hit
        if (instance.hit || instance.melee)
        {
            if (shakeDuration > 0)
            {
                if (instance.hit)
                {
                    instance.hitIndicator.gameObject.SetActive(true);
                }
                transform.localPosition = endPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime;
            }
            else
            {
                shakeDuration = 0.5f;
                instance.hit = false;
                transform.localPosition = endPos;
                instance.hitIndicator.gameObject.SetActive(false);
                instance.melee = false;
            }

        }

    }
    
    // Follow player rotation (might change to be option instead)
    private void LateUpdate()
    {
        if ((instance.currState == GameManager.gameState.playing || instance.currState == GameManager.gameState.pause) && instance.followCam)
        {
            var endPosition = new Vector3(90, player.transform.localEulerAngles.y - 90, 0);
            Quaternion endQr = Quaternion.Euler(endPosition);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endQr, Time.deltaTime * 2.5f);
            startLerpTime = Time.time;
        }
        if ((instance.currState == GameManager.gameState.playing || instance.currState == GameManager.gameState.pause) && !instance.followCam)
        {
            currentLerpTime = Time.time - startLerpTime;
            float perc = currentLerpTime / LerpDuration;
            if (perc <= 1f)
            {
                var endPosition = new Vector3(90, 90, 0);
                Quaternion endQr = Quaternion.Euler(endPosition);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endQr, perc);
            }
        }
    }
    
}
