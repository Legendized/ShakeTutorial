using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    float currentMag;
    float trueMag;
    public float decay = 2.4f;
    public float positionMultiplier = 0.9f;
    public float maxShake = 0.3f;

    public void UpdateShake()
    {
        float f = Mathf.Clamp01(1f - (decay * Time.fixedDeltaTime));
        currentMag *= f;

        trueMag = currentMag;
        trueMag = Mathf.Clamp(trueMag, -maxShake, maxShake);
    }
    public void Shake(float mag)
    {
        currentMag += mag;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B)) Shake(0.2f);

        transform.localPosition = Vector3.zero + Random.insideUnitSphere * trueMag * positionMultiplier;
    }

    private void FixedUpdate()
    {
        UpdateShake();
    }
}
