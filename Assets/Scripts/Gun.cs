using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 24;
    public int currentAmmo;
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }
    void RotateGun()
    {
        if(Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y <0 || Input.mousePosition.y > Screen.height) return;

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // tinh huong xoay tu gun -> con tro chuot(toa do trong game)
        float angle= Mathf.Atan2 (displacement.y,displacement.x) * Mathf.Rad2Deg; // tinh goc xoay
        transform.rotation = Quaternion.Euler(0,0,angle + rotateOffset); // thuc hien xoay

        // lat gun cho phu hop khi xoay
        if(angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1,1,1);
        }else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time * shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmo--;
        }
    }
     void Reload()
    {
        if(Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
}
