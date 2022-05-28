using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    public string var;
 
    public void SceneChange()
    {
        SceneManager.LoadScene(var);
    }

}
