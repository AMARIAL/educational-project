using System.Collections;
using UnityEngine;

public class SpinStarter : MonoBehaviour
{
    public static SpinStarter ST {get; private set;}
    
    public int[,] arCell = new int[7,7];
    [SerializeField] public Color[] collors;

    [SerializeField] public float speed;
    private Spin spin;
    private Column[] _columns;
    public int currentR = 0;
    public int currentC = 0;
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
        GenerateNewArray();

        for (var i = 0; i <_columns.Length; i++)
        {
            yield return new WaitForSeconds(0.7f);
            _columns[i].StartSpin();
        }
        yield return null;
    }

    public void GenerateNewArray()
    {
        currentR = currentC = 0;
        for (int i = 0; i < arCell.GetLength(0); i++) {  
            for (int j = 0; j < arCell.GetLength(1); j++)
            {
                arCell[i,j] = Random.RandomRange(0, collors.Length);
            }
        } 
    }
}
