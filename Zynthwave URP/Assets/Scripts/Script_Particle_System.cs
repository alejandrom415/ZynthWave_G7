//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ParticleSystem))]

public class Script_Particle_System : MonoBehaviour
{
    //public ParticleSystemShapeType shapeType = ParticleSystemShapeType.Circle;

    public int arc;

    public int rateOverTime;

    private ParticleSystem sys;

    private ParticleSystem.EmissionModule emission;

    private ParticleSystem.ShapeModule shape;

    // Start is called before the first frame update
    void Start()
    {
        sys = GetComponent<ParticleSystem>();

        //shape.arc = 45;

        //emission.rateOverTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = sys.emission;

        var shape = sys.shape;

        //emission.rateOverTime = rateOverTime;

        //shape.arc = arc;
    }

    public void SetROF()
    {
        emission.rateOverTime = rateOverTime * 2f;
    }

    public void SetAccuracy()
    {
        shape.arc = arc * 0.5f;
    }
}
