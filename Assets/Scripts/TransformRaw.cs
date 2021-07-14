using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cook
{
    public class TransformRaw : MonoBehaviour
    {
        [SerializeField]
        private string actionName;
        [SerializeField]
        private List<GameObject> results = new List<GameObject>();

        public int NumberOfProcessFood { get => results.Count; }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(actionName))
            {
                InstantiateResult();
                Destroy(this.gameObject);
            }
        }

        private void InstantiateResult()
        {
            results.ForEach((result) => Instantiate(result, this.transform.position, Quaternion.identity));
        }
    }
}
