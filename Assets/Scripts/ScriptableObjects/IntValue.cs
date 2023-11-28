using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private int initialValue;
    public int runtimeValue;

    public void OnAfterDeserialize(){
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}
}
