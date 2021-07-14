using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cook
{
    public class Recipe : ScriptableObject
    {
        public bool doesFry;
        public bool doesCook;
        public bool doesCut;
        public bool doesChopCut;
        public List<GameObject> Foods = new List<GameObject>();
        public float timer;
    }
}
