using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//tr
public class change : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("FirstScene");
    }

}
