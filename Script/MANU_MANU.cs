using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MANU_MANU : MonoBehaviour
{
    // decleration of variables

    // loading image variable
    public GameObject loadin_img;

    // load function
    public void LOAD(int n)
    {
        SceneManager.LoadScene(n);

    }
    
    // game quit function
    public void Quit()
    {
        Application.Quit();
    }

    // load scene function to activat loading image
    public void Loadscene(int n)
    {
        StartCoroutine(LoadAsc(n));
        loadin_img.SetActive(false);

    }

    // this function will activate the loading image until the loading process
   IEnumerator LoadAsc(int n)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(n);
        while(!op.isDone)
        {
            if(!loadin_img.activeSelf) 
              loadin_img.SetActive(true);

            yield return null;
        }
    }
}
