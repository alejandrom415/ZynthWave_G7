using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SonicBlast : MonoBehaviour
{
    SphereCollider collider;
    public float blastRadius;
    public float lerpDuration;

    void Start() {
        collider = GetComponent<SphereCollider>();
    }

    void Awake() {
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
        collider.radius = blastRadius;
        gameObject.SetActive(false);
        yield return null;
    }
}
