using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;
    RaycastHit hit;
    Ray ray;
    void Start()
    {
        SpawnApple();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnApple();
        }
    }
    
    public void SpawnApple()
    {
        bool checkplace = false;
        Vector3 finalpos = Vector3.zero;
        do
        {
            Vector3 position = new Vector3(Random.Range(21f, 79f), 10, Random.Range(-79f, -21f));
            ray = new Ray(position, Vector3.down);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Floor")
                {
                    checkplace = Physics.CheckSphere(hit.point, 1f);
                    finalpos = hit.point;
                    //Debug.Log(checkplace.ToString());
                }
            }
        }
        while (checkplace == false);
        finalpos.y += 0.05f;
        Instantiate(apple, finalpos,Quaternion.identity);
    }
}
