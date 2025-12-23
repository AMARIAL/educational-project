using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    private void Update()
    {
        if (Player.ST)
        {
            Vector3 playerPosition = Player.ST.transform.position;
            transform.position = new Vector3(playerPosition.x,playerPosition.y, transform.position.z);   
        }
    }
}
