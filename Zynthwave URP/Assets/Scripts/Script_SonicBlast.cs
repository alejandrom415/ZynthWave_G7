using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SonicBlast : MonoBehaviour
{
    SphereCollider collider;
    public float blastRadius;
    public float lerpDuration;
    public GameObject blastVisual;

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
            blastVisual.transform.localScale = new Vector3(collider.radius*2,collider.radius*2,collider.radius*2);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        collider.radius = 0;
        //blastVisual.transform.localScale = Vector3.zero;
        LeanTween.scale(blastVisual, new Vector3(0f, 0f, 0f), 1.2f).setEase(LeanTweenType.easeOutElastic);
        yield return null;
        gameObject.SetActive(false);
    }
}