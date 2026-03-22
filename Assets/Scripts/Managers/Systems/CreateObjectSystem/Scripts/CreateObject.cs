using Systems.PoolSystem.Enum;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.CreateObjectSystem.Scripts
{
    public class CreateObject : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public Camera mainCamera;

        [SerializeField] private ObjectType _objectType;
        [SerializeField] private ObjectPool _objectPool;
        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    _objectPool.Spawn(_objectType, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
