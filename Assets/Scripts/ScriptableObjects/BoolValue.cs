using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue :  ScriptableObject, ISerializationCallbackReceiver
{

    [SerializeField] private bool initialValue;
    public bool runtimeValue;

    public void OnAfterDeserialize(){
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}
}
