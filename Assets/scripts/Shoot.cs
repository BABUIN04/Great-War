using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    public void shoot(float direction, Vector3 position)
    {
        Instantiate(bullet, position, Quaternion.Euler(0, 0, direction));
    }
}
