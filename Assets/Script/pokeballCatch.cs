using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeballCatch : MonoBehaviour
{
    int count = 0;
    GameObject pokemon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "pokemon")
        {
            pokemon = other.gameObject;
            pokemon.SetActive(false);
            this.GetComponent<Animator>().Play("pokeballShake");
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void isCatch()
    {
        count++;
        int rand = Random.Range(0, 10);
        if (rand > 7)
        {

        }
        else
        {
            if(count == 2)
            {
                pokemon.SetActive(true);
                Destroy(this.gameObject);
            }
            else
                this.GetComponent<Animator>().Play("pokeballShake");
        }
    }
}
