using UnityEngine;

public class SwitchGun : MonoBehaviour
{
    public GameObject[] Guns = new GameObject[3];
    public GameObject ActualGun;
    [SerializeField] private Transform Hands;
    [SerializeField] private Transform GunsFolder;
    private int i = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ActualGun.transform.SetParent(GunsFolder);
            ActualGun.active = false;

            if(i == Guns.Length)
            {
                i = 0;
            }

            ActualGun = Guns[i];
            ActualGun.transform.SetParent(Hands);
            ActualGun.active = true;
            ActualGun.transform.position = Hands.transform.position;

            i++;
        }
    }
}
