using System;
using UnityEngine;

namespace Moduler.Road
{
    public class RoadRepeatMesh : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 1f;
        private Material material;
        private const string DEFAULT_TEXTURE = "_MainTex";

        private void Awake() => material = GetComponent<MeshRenderer>().material;

        private void Update()
        {
            float offset = Time.time * scrollSpeed;
            material.SetTextureOffset(DEFAULT_TEXTURE, Vector2.up * offset);
        }
    }
}