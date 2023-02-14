using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private GameSetter _gameSetter;
    [SerializeField] private CheckpointTracker _tracker;

    private BoxCollider _trigger;

    private void Awake()
    {
        _trigger = GetComponent<BoxCollider>();
        StartCoroutine(EnableFinishTrigger());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCar>() && _tracker.AllCheckpointsReached == true)
            _gameSetter.ShowFinish();
        else if (other.GetComponent<EnemyCar>())
            _gameSetter.ShowFail();
    }

    private IEnumerator EnableFinishTrigger()
    {
        yield return new WaitForSeconds(10f);
        _trigger.enabled = true;
        StopCoroutine(EnableFinishTrigger());
    }
}
