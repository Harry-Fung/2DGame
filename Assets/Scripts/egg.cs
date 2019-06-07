using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    //BowlingBall
    public GameObject eggs;
    private float time =2;
    private GameObject newegg;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        time -= Time.deltaTime;
        if (time < 0)
        {
            Vector3 player_postion = GameObject.Find("screamingChicken").transform.position;
            float eggx = player_postion.x;
            time = 2;
            
            Debug.Log(eggx);
            Vector3 spawnPosition = new Vector3(eggx, 3, 0);
            newegg = (GameObject)Instantiate(eggs, spawnPosition, Quaternion.identity);
            newegg.name = "newegg";
            (gameObject.GetComponent("egg") as MonoBehaviour).enabled = false;
            //Destroy(newegg, 3);
        }
    }
}
