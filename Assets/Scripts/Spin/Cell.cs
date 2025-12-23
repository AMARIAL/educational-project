using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isMoving;
    private bool isTeleported;
    private RectTransform pos;
    private Image _image;
    void Start()
    {
        pos = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _image.color = new Color(Random.Range(0,1.0f),Random.Range(0,1.0f),Random.Range(0,1.0f));
        startPosition = pos.anchoredPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.down * SpinStarter.ST.speed * Time.deltaTime);
            
            if (isTeleported && pos.anchoredPosition.y < startPosition.y)
            {
                pos.anchoredPosition = startPosition;
                isMoving = false;
                isTeleported = false;
            }
        }
    }

    public void StartSpin()
    {
        isMoving = true;
        Invoke(nameof(StopSpin),5.0f);
    }

    public void StopSpin()
    {
        transform.position = new Vector2(transform.position.x, 30);
        isTeleported = true;
    }
}
