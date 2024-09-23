using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void Run(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void Stop(IEnumerator coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}