using UnityEngine;

public class SwitchGun : MonoBehaviour
{
    public GameObject[] Guns = new GameObject[3];

    [SerializeField] private Transform Hands;
    [SerializeField] private Transform GunsFolder;

    private int i = 0;

    public GameObject SwitchingGun(GameObject ActualGun)
    {
        ActualGun.transform.parent = GunsFolder;
        ActualGun.SetActive(false);

        ActualGun = Guns[i];
        ActualGun.transform.SetParent(Hands);
        ActualGun.transform.position = Hands.transform.position;

        ActualGun.SetActive(true);

        if (i == Guns.Length - 1)
            i = 0;
        else
            i++;

        return ActualGun;
    }
}
