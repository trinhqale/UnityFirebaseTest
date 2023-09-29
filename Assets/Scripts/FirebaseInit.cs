using System.Collections;
using System.Collections.Generic;
using Firebase.Platform;
using UnityEngine;
using UnityEngine.Events;
using Firebase;

public class FirebaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnFirebaseLoaded = new UnityEvent();
    public UnityEvent OnFirebaseFailed = new UnityEvent();
    async void Start()
    {
        var dependencyStatus = await Firebase.FirebaseApp.CheckDependenciesAsync();
        if (dependencyStatus == DependencyStatus.Available)
        {
            OnFirebaseLoaded.Invoke();
        }
        else
        {
            OnFirebaseFailed.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
