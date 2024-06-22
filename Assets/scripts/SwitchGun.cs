using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{
    public List<GameObject> Guns = new List<GameObject>();

    [SerializeField] private Transform Hands;
    [SerializeField] private Transform GunsFolder;

    private int i = 0;

    public GameObject SwitchingGun(GameObject ActualGun)
    {
        if (Guns.Count == 1)
            return ActualGun;

        ActualGun.transform.parent = GunsFolder;
        ActualGun.SetActive(false);

        ActualGun = Guns[i];
        ActualGun.transform.SetParent(Hands);
        ActualGun.transform.position = Hands.transform.position;

        ActualGun.SetActive(true);

        if (i == Guns.Count - 1)
            i = 0;
        else
            i++;

        return ActualGun;
    }
}
