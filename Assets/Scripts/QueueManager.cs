using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExecuteCommand());
    }

    IEnumerator ExecuteCommand()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CommandQueue.Instance.ExecuteNext();
        }
    }
}
