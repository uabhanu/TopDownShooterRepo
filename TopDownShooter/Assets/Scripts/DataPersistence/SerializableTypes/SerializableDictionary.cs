using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence.SerializableTypes
{
    [System.Serializable]
    public class SerializableDictionary<TKey , TValue> : Dictionary<TKey , TValue> , ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> keysList = new List<TKey>();
        [SerializeField] private List<TValue> valuesList = new List<TValue>();
        
        public void OnBeforeSerialize()
        {
            keysList.Clear();
            valuesList.Clear();

            foreach(KeyValuePair<TKey , TValue> pair in this) //this meaning this dictionary
            {
                keysList.Add(pair.Key);
                valuesList.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear(); //This dictionary is clear first before adding to the list to make sure we are adding the current ones.

            if(keysList.Count != valuesList.Count)
            {
                Debug.LogError("Sir Bhanu, something went horribly wrong as Keys count and Values count are not equal");
            }

            for(int i = 0; i < keysList.Count; i++)
            {
                Add(keysList[i] , valuesList[i]);
            }
        }
    }
}
