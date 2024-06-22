using UnityEngine;

public class DropGun : MonoBehaviour
{
    [SerializeField] private static Player _player;
    private static SwitchGun _switchGun;

    private void Start()
    {
        _switchGun = GetComponent<SwitchGun>();
        _player = GetComponent<Player>();
    }
    public static void Drop(GameObject gun)
    {
        _player.Switching();
        gun.transform.parent = null;

        gun.SetActive(true);
        gun.GetComponent<HandsDirection>().enabled = false;
        gun.GetComponent<Collider2D>().enabled = true;
        gun.GetComponent<Pick>().enabled = true;

        _switchGun.Guns.Remove(gun);
    }
}
