using System;
using TMPro;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private float spinTimer;
    [SerializeField] private TextMeshProUGUI buttonText;
    
    public event Action startSpin;
    public event Action finishtSpin;

    private void Awake()
    {
        isActive = true;
    }

    public void StartSpin()
    {
        if (isActive)
        {
            startSpin?.Invoke();
            isActive = false;
            buttonText.text = "WAIT!!!";
            Invoke(nameof(StopTimer), spinTimer);
        }
    }

    private void StopTimer()
    {
        if (!isActive)
        {
            finishtSpin?.Invoke();
            buttonText.text = "SPIN";
            isActive = true;
        }
    }


}
