using System;
using Manager;
using UnityEngine;

namespace Moduler.Road
{
    public class RoadRepeatMesh : MonoBehaviour
    {
        private Material material;
        private const string DEFAULT_TEXTURE = "_MainTex";

        private void Awake() => material = GetComponent<MeshRenderer>().material;
        
        private void Update()
        {
            float offset = Time.time * GameManager.Instance.GetRoadScrollSpeed();
            material.SetTextureOffset(DEFAULT_TEXTURE, Vector2.up * offset);
        }
    }
}