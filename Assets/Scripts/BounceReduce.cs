using UnityEngine;

namespace DefaultNamespace
{
    public class BounceReduce : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Color color;
        
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            color = spriteRenderer.color;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Tạo màu mới với các giá trị màu được điều chỉnh sau mỗi va chạm.
            color = new Color(GetNormalized(color.r + 0.1f), GetNormalized(color.g + 0.1f), GetNormalized(color.b + 0.1f));
            
            // Gán màu mới vào spriteRenderer.
            spriteRenderer.color = color;
        }

        private float GetNormalized(float colorValue)
        {
            if (colorValue > 1)return 1 - colorValue;
            return colorValue;
        }
    }
}