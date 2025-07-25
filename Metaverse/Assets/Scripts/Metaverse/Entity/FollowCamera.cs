using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            Debug.LogError("Target Transform is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 pos = target.position;
        pos.z = -10;
        transform.position = pos;
    }
}
