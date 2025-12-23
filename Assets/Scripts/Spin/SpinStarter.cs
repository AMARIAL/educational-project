using System;
using System.Collections;
using UnityEngine;

public class SpinStarter : MonoBehaviour
{
    public static SpinStarter ST {get; private set;}
    
    [SerializeField] public float speed;
    private Spin spin;
    private Column[] _columns;

    private void Awake()
    {
        ST = this;
    }

    void Start()
    {
        spin = GameObject.Find("SpinButton").GetComponent<Spin>();
        spin.startSpin += StartColumns;
        
        _columns = GetComponentsInChildren<Column>();
    }

    private void StartColumns()
    {
        StartCoroutine(SpinStarted());
    }
     
    IEnumerator SpinStarted() 
    {
        for (var i = 0; i <_columns.Length; i++)
        {
            yield return new WaitForSeconds(0.7f);
            _columns[i].StartSpin();
        }
        yield return null;
    }
}
