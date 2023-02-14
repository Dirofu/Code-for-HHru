using System.Collections;
using UnityEngine;

public class TimeStopper : MonoBehaviour
{
    private void Start()
    {
        StartTimeScale();
    }

    private IEnumerator SlowdownTimeScale()
    {
        while (Time.timeScale > .1f)
        {
            Time.timeScale -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(SlowdownTimeScale());
    }

    public void StopTimeScale() => Time.timeScale = 0;
    public void StartTimeScale() => Time.timeScale = 1;
    public void SlowdownToStopTimeScale() => StartCoroutine(SlowdownTimeScale());
}
