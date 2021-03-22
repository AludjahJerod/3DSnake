using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();
    public List<Vector3> DataParts = new List<Vector3>();
    public List<Quaternion> DataRot = new List<Quaternion>();
    public Vector3 newpos;
    public Vector3 headdd;
    public Vector3 headrefff;

    public Transform head;
    public Transform headref;

    public int sizeExpand=5;
    public int distance = 5;
    public float speed = 5f;
    public float rotationSpeed = 50f;
    public int beginSize = 2;

    public GameObject bodyPrefab;
    public GameObject tail;
    public Vector3 vector3;

    int leftright=0;
    void Start()
    {
        for (int i = 0; i < beginSize ; i++)
            AddBodyPart();
        AddTail();
    }

    void FixedUpdate()
    {
        headdd = head.position;
        headrefff = headref.position;
        DataUpdate();
        Move();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpgradeSnake();
        }
    }

    public void DataUpdate()
    {
        DataParts.Add(headref.position);
        DataRot.Add(headref.rotation);
        while (DataParts.Count > (BodyParts.Count-1) * (distance+1)+1)
        {
            DataParts.RemoveAt(0);
        }
        while (DataRot.Count > (BodyParts.Count-1) * (distance+1)+1)
        {
            DataRot.RemoveAt(0);
        }
    }
    public void Move()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    BodyParts[0].Translate();
        //    transform.Translate(BodyParts[0].forward * speed * Time.smoothDeltaTime, Space.World);
        //}
        Vector3 prpos = headref.position;
        Quaternion prrot = headref.rotation;
        Vector3 cupos=BodyParts[1].position;
        Quaternion curot = BodyParts[1].rotation;
        head.Translate(head.forward * speed * Time.smoothDeltaTime, Space.World);
                
        head.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * leftright);

        BodyParts[1].position = prpos;
        BodyParts[1].rotation = prrot;

        for (int i = 1; i<BodyParts.Count; i++)
        {
            //DataParts.Reverse();
            try
            {
                
                //newpos = DataParts[i * (distance + 1)];
                //newpos.y = head.position.y;
                BodyParts[i].position = DataParts[(BodyParts.Count-1-i) * (distance + 1)];
                //BodyParts[i].position = newpos;

                //if (i != BodyParts.Count - 1)
                //    BodyParts[i].rotation = DataRot[i * (distance + 1)];
                //else
                //    BodyParts[i].rotation = DataRot[i * (distance + 1)];

                //if (i != 1)
                //{
                //    prrot = BodyParts[i].rotation;
                //    BodyParts[i].rotation = curot;
                //    curot = prrot;
                //}

                BodyParts[i].rotation = Quaternion.Slerp(BodyParts[i].rotation, BodyParts[i-1].rotation, 0.2f);
            }
            catch
            {
                prpos = BodyParts[i].position;
                prrot = BodyParts[i].rotation;
                BodyParts[i].position = cupos;
                BodyParts[i].rotation = curot;
                cupos = prpos;
                curot = prrot;
                //Debug.Log("Fi chi ghalat");
            }
            //DataParts.Reverse();


            //prevBodyPart = BodyParts[i - 1];

            //distance = Vector3.Distance(prevBodyPart.position, curBodyPart.position);
            //Vector3 newPos = prevBodyPart.position;
            //newPos.y = BodyParts[0].position.y;
            //float T = Time.deltaTime * distance / mindistance ;
            //if (T > 0.5f)
            //    T = 0.5f;
            //vector3 = Vector3.Slerp(curBodyPart.position, newPos, T);
            //curBodyPart.position = vector3;
            //curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        for (int i = 0; i <sizeExpand; i++) 
        {
            Transform newpart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation)
                as GameObject).transform;

            newpart.SetParent(transform);
            BodyParts.Add(newpart); 
        }
    }
    public void RemoveLast()
    {
        Destroy(BodyParts[BodyParts.Count - 1].gameObject);
        BodyParts.RemoveAt(BodyParts.Count - 1);
    }

    public void AddTail()
    {
        Transform tailpart = (Instantiate(tail, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation)
            as GameObject).transform;

        tailpart.SetParent(transform);

        BodyParts.Add(tailpart);
    }
    public void UpgradeSnake()
    {
        RemoveLast();
        AddBodyPart();
        AddTail();
    }

    public void RotateSnake(int lr)
    {
        if(  (leftright>lr && lr<0) || (leftright<lr && lr>0))
            leftright += lr;
    }

    public void StopRotate( int s)
    {
        leftright -= s;
    }
}
