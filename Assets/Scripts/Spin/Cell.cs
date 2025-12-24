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
        startPosition = pos.anchoredPosition;
        _image.color = SpinStarter.ST.collors[Random.RandomRange(0, SpinStarter.ST.collors.Length)];
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
        ColorsAdd();
        transform.position = new Vector2(transform.position.x, 30);
        isTeleported = true;
    }

    private void ColorsAdd()
    {
        _image.color = SpinStarter.ST.collors[SpinStarter.ST.arCell[SpinStarter.ST.currentR,SpinStarter.ST.currentC]];
        SpinStarter.ST.currentC++;
        if (SpinStarter.ST.currentC >= SpinStarter.ST.arCell.GetLength(0))
        {
            SpinStarter.ST.currentC = 0;
            SpinStarter.ST.currentR++;
        }
    }
}
