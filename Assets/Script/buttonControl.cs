using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    public GameObject[] models;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseModel(int i)
    {
        leftHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
        leftHand.GetComponent<Valve.VR.InteractionSystem.Sample.Putting>().prefabToPut = models[i];
    }
}
