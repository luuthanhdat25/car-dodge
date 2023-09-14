using System;
using System.Collections.Generic;
using UnityEngine;

namespace Moduler
{
    public class SpawnerPointManager : MonoBehaviour
    {
        [SerializeField] private Transform leftOutPointTransform;
        [SerializeField] private Transform leftMidPointTransform;
        [SerializeField] private Transform rightMidPointTransform;
        [SerializeField] private Transform rightOutPointTransform;

        private List<Transform> spawnerPointTransformList;

        private void Awake()
        {
            spawnerPointTransformList.Add(leftOutPointTransform);
            spawnerPointTransformList.Add(leftMidPointTransform);
            spawnerPointTransformList.Add(rightMidPointTransform);
            spawnerPointTransformList.Add(rightOutPointTransform);
        }
    }
}