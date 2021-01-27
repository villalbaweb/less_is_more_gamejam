using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerDieBloodStainHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject bloodStain = null;

        // state
        GameObject _bloodObjectsParent;

        // consts
        const string OBJECT_BLOOD_PARENT_NAME = "Blood Objects";

        private void Awake() 
        {
            _bloodObjectsParent = CreateCustomObjectPoolParent(OBJECT_BLOOD_PARENT_NAME);    
        }

        public void AddBloddStain()
        {
            GameObject instance = Instantiate(bloodStain, transform.position, Quaternion.identity);
            instance.transform.parent = _bloodObjectsParent.transform;
        }

        private GameObject CreateCustomObjectPoolParent(string parentName)
        {
            GameObject parent = GameObject.Find(parentName);

            if (!parent)
            {
                parent = new GameObject(parentName);
            }

            return parent;
        }
    }
}
