using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TMP_Text _procent;

    private void ShowLoadProcent(float value) => _procent.text = $"{Mathf.RoundToInt(value)}%";

    private IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation loadingAsync = SceneManager.LoadSceneAsync(sceneName);

        while (loadingAsync.isDone == false)
        {
            ShowLoadProcent(loadingAsync.progress * 100);
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(LoadAsync(sceneName));
    }

    public void LoadLevel(string sceneName) 
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneName));
    }
}
