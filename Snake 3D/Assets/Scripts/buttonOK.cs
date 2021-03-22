using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOK : MonoBehaviour
{
    public GameObject pan;
    public void OkClick()
    {
        pan.SetActive(false);
    }
}
