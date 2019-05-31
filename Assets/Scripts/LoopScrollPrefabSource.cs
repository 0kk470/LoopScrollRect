using UnityEngine;
using System.Collections;
using System;

namespace UnityEngine.UI
{
    [System.Serializable]
    public class LoopScrollPrefabSource 
    {
        public string prefabName;
        public int poolSize = 5;

        private bool inited = false;

        public Action<Transform> onObjectReturn;

        public virtual GameObject GetObject()
        {
            if(!inited)
            {
                SG.ResourceManager.Instance.InitPool(prefabName, poolSize);
                inited = true;
            }
            return SG.ResourceManager.Instance.GetObjectFromPool(prefabName);
        }

        public virtual void ReturnObject(Transform go)
        {
            if (onObjectReturn != null)
                onObjectReturn(go);
            go.SendMessage("ScrollCellReturn", SendMessageOptions.DontRequireReceiver);
            SG.ResourceManager.Instance.ReturnObjectToPool(go.gameObject);
        }
    }
}
