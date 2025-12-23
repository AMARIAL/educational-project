using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletCount;

    private void Awake()
    {
        for (int i=0; i<bulletCount; i++)
        {
            Instantiate(bullet, transform);
        }
    }

}
