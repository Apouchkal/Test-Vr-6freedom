using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cook
{
    [Serializable]
    public class Recipe
    {
        public bool doesFry;
        public bool doesCook;
        public bool doesCut;
        public bool doesChopCut;
        public List<TransformRaw> Foods = new List<TransformRaw>();
        public float timer;

        public int NumberOfTransformFood()
        {
            int number = 0;

            Foods.ForEach((food) => number += food.NumberOfProcessFood);

            return number;
        }
    }
}
