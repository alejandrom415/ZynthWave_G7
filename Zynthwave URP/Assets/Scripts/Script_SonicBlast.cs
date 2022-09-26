using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SonicBlast : MonoBehaviour
{
    SphereCollider collider;
    public float blastRadius;
    public float lerpDuration;

    void OnEnable() {
        collider = GetComponent<SphereCollider>();
        Debug.Log("starting blast...");
        StartCoroutine(blast());
    }

    IEnumerator blast() {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            collider.radius = Mathf.Lerp(0f, blastRadius, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        collider.radius = 0;
        yield return null;
        gameObject.SetActive(false);
    }
}
