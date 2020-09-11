using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBounds : MonoBehaviour
{
    private int xmin;
    private int xmax;
    private int zmin;
    private int zmax;

    // Start is called before the first frame update
    void Start()
    {
        xmin = -9;
        xmax = 9;
        zmin=-9;
        zmax=9;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xmin ) {
            transform.position = new Vector3(xmin,transform.position.y, transform.position.z);
        } else if (transform.position.x > xmax) {
            transform.position = new Vector3(xmax,transform.position.y, transform.position.z);
        }

        if (transform.position.z < zmin ) {
            transform.position = new Vector3(transform.position.x,transform.position.y,zmin);
        } else if (transform.position.z > zmax) {
            transform.position = new Vector3(transform.position.x,transform.position.y,zmax);
        }
    }
}
