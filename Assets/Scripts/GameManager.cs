using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ST {get; private set;}

    public Dictionary<GameObject, Health> healthContainer;

    public int levelNum;
    
    private void Awake()
    {
        ST = this;
        healthContainer = new Dictionary<GameObject, Health>();

        if(SceneManager.GetActiveScene().name.Contains("-"))
            levelNum =  int.Parse(SceneManager.GetActiveScene().name.Split("-")[1]);

    }

    public void LoadLevel(int num = -1)
    {
        if (num == -1) // Не указываем, будет гузиться след. уовень
        {
            SceneManager.LoadScene("Level-" + (levelNum+1));
        }
        else if (num == 0) // Указали 0, будет грузится меню
        {
            SceneManager.LoadScene("Menu");
        }
        else if (num > 0) // Указали число, будет груззится именно тот уровень
        {
            if(SceneManager.GetSceneByName("Level-" + num.ToString()).IsValid())
                SceneManager.LoadScene("Level-" + num.ToString());
            else
                SceneManager.LoadScene("Menu");
        }
    }

}
