
using System.Collections;
using UnityEngine;

public class Column : MonoBehaviour
{
    private Cell[] _cells;
    void Start()
    {
        _cells = GetComponentsInChildren<Cell>();
    }

    public void StartSpin()
    {
        StartCoroutine(SpinStarted());
    }
    
    
    IEnumerator SpinStarted() 
    {
        for (var i = _cells.Length-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            _cells[i].StartSpin();
        }
        yield return null;
    }
}
