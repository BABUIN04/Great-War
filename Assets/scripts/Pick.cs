using UnityEngine;

public class Pick : MonoBehaviour,Interactable
{
    [SerializeField] private Transform GunFolder;
    [SerializeField] private SwitchGun _switchGun;
    public void Interact()
    {
        transform.SetParent(GunFolder);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<HandsDirection>().enabled = true;

        gameObject.SetActive(false);
        _switchGun.Guns.Add(gameObject);
    }
}
