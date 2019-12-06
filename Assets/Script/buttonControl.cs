using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonControl : MonoBehaviour
{
    public GameObject[] models;

    private int which;
    // Start is called before the first frame update
    void Start()
    {
        which = models.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowModels(int val)
    {
        for(int i = 0; i < models.Length; i++)
        {
            if (i == val)
                models[i].SetActive(true);
            else
                models[i].SetActive(false);
        }

        which = val;
    }

    public void turnModels(bool isR)
    {
        if(which < models.Length)
        {
            for(int i= 0;i < models[which].transform.childCount; i++)
            {
                GameObject model = models[which].transform.GetChild(i).gameObject;
                //Vector3 position = model.transform.position;
                Vector3 rotation = model.transform.eulerAngles;
                if (isR)
                    rotation.y -= 15;
                else
                    rotation.y += 15;
                model.transform.eulerAngles = rotation;
                //model.transform.position = position;
            }
        }
    }
}
