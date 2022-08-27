using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyLoad : MonoBehaviour
{
    public Text LoadingText;
    private void Start()
    {
        StartCoroutine(LoadLobby());
    }

    IEnumerator LoadLobby()
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync("Lobby");

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            LoadingText.text = "Loading...";
            yield return new WaitForSeconds(0.3f);
            LoadingText.text = "Loading";
            yield return new WaitForSeconds(0.3f);
            LoadingText.text = "Loading.";
            yield return new WaitForSeconds(0.3f);
            LoadingText.text = "Loading..";
            yield return new WaitForSeconds(0.3f);
            if(operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
