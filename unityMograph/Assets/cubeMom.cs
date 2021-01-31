using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class cubeMom : MonoBehaviour
{
    public int num = 20;
    public GameObject[] cubeA;
    public GameObject cube;
    public GameObject empty;
    GameObject clone;
    public float rateA,rateB,rateC, offset, n, n2, n3;
    Quaternion rots;

    float knobA,knobB;
    // Start is called before the first frame update
    void Start()
    {
       
        cubeA = new GameObject[num];
        for (int i = 1; i < num; i++)
        {
            clone = Instantiate(cube, new Vector3(0f, 0f, 0f), empty.transform.rotation);
            
            
            cubeA[i] = clone;
            
        }
    } 


    void Update()
    {
        knobA = MidiMaster.GetKnob(1);
        knobB = MidiMaster.GetKnob(2);
        float scaled = map_Values(0, 1, -50, 50, knobA);
        rateB= map_Values(0, 1, -50, 50, knobB);

        print(knobA);
        n = Mathf.PerlinNoise(Mathf.Sin(Time.time * .2f) * 2, Mathf.Cos(Time.time * .2f ) * 3);
        n2 = Mathf.PerlinNoise(Mathf.Sin(Time.time * .3f) * 2, Mathf.Sin(Time.time * .3f) * 3);
        n3 =Mathf.Cos(Time.time * .4f) * 2 * Mathf.Cos(Time.time * .4f ) * 3;
        
        for (int i = 1; i < cubeA.Length; i++)
        {
            cubeA[i].transform.position = new Vector3(Mathf.Sin(Time.time * rateB+i) * scaled, Mathf.Cos(Time.time*rateA+i)*scaled,Mathf.Cos(Time.time * rateA+i) * 3) + empty.transform.position;
            cubeA[i].transform.localScale = new Vector3(Mathf.Cos(Time.time * rateA + i) * rateB, Mathf.Cos(Time.time * rateA + i) * rateB, Mathf.Cos(Time.time * rateA + i) * rateB);

        }
    

    }


   public float map_Values(float fromA, float toA, float fromB,float toB , float value)
    {
        float rangeO = toA - fromA;
        float rangeN = toB - fromB;
        float newValue = ((value - fromA) * rangeN / rangeO) +fromB;
        return (newValue);
    }
}
