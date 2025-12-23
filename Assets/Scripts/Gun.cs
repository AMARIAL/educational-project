using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform stvol;
    [SerializeField] private Transform bulletPool;
    [SerializeField] private Bullet[] bullets;
    [SerializeField] private int bulletSpeed = 10;

    private bool isCanShoot = true;
    private int currentBulletId = 0;
    private void Awake()
    {
        bullets = bulletPool.GetComponentsInChildren<Bullet>();

        foreach (var bullet in bullets)
            bullet.gameObject.SetActive(false);
    }

    private void Update()
    {
        Rotate();

        if (Input.GetKey(KeyCode.Mouse0))
            Fire();
    }

    private void Rotate()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - stvol.position;
        stvol.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg);
    }

    private void Fire()
    {
        if(!isCanShoot) return;
        
        bullets[currentBulletId].Fire(stvol.right, bulletSpeed);
            
        if (currentBulletId < bullets.Length-1)
            currentBulletId++;
        else
            currentBulletId = 0;

        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown ()
    {
        isCanShoot = false;
        yield return new WaitForSeconds(0.5f); 
        isCanShoot = true;
        yield return null;
    }

}
