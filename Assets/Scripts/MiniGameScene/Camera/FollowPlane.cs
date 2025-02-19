using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private float offsetX = 0;

    private void Start()
    {
        if (target == null)
        {
            return ;
        }

        offsetX = transform.position.x - target.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 cameraPosition = new Vector3(target.transform.position.x + offsetX, 0, transform.position.z);
        transform.position = cameraPosition;
    }
}
