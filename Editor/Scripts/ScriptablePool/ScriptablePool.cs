using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace Nicklaj.Butter
{
    [CreateAssetMenu(fileName = "ScriptablePool", menuName = "Butter/Object Pool")]
    public class ScriptablePool : ScriptableObject
    {
        public enum PoolType
        {
            Stack,
            LinkedList
        }
        
        public PoolType poolType;
        
        // Collection checks will throw errors if we try to release an item that is already in the pool.
        public bool collectionChecks = true;
        public int maxPoolSize = 10;

        public GameObject PooledObject;
        
        IObjectPool<GameObject> m_Pool;
        
        public IObjectPool<GameObject> Pool
        {
            get
            {
                if (m_Pool == null)
                {
                    if (poolType == PoolType.Stack)
                        m_Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        m_Pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return m_Pool;
            }
        }

        public GameObjectRuntimeSet ActiveObjects;

        public UnityAction<GameObject> Action_OnReturnedToPool;
        public UnityAction<GameObject> Action_OnTakeFromPool;
        public UnityAction<GameObject> Action_OnBeforeDestroyPoolObject;

        GameObject CreatePooledItem()
        {
            var go = Instantiate(PooledObject);

            // This is used to return ParticleSystems to the pool when they have stopped.
            var returnToPool = go.AddComponent<ReturnToPool>();
            returnToPool.pool = Pool;

            return go;
        }
        
        // Called when an item is returned to the pool using Release
        void OnReturnedToPool(GameObject item)
        {
            ActiveObjects?.Remove(item);
            Action_OnReturnedToPool?.Invoke(item);
            item.SetActive(false);
        }
        
        // Called when an item is returned to the pool using Release
        void OnTakeFromPool(GameObject item)
        {
            ActiveObjects?.Add(item);
            Action_OnTakeFromPool?.Invoke(item);
            item.SetActive(true);
        }
        
        
        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        void OnDestroyPoolObject(GameObject item)
        {
            Action_OnBeforeDestroyPoolObject?.Invoke(item);
            Destroy(item);
        }
    }
    
    public class ReturnToPool : MonoBehaviour
    {
        public IObjectPool<GameObject> pool;

        public void Release()
        {
            pool.Release(this.gameObject);
        }
    }
}