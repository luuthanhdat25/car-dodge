using UnityEngine;

public class RoadRepeatTransform : MonoBehaviour
{
    [SerializeField] private Transform roadTransform;
    [SerializeField] private float scrollSpeed = 1f;
    private Transform secondRoad;
    private const float HEIGHT = 10.75f;
    private Vector3 repeatPosition;

    private void Awake()
    {
        roadTransform = transform.Find("Road"); 
        if(roadTransform == null) Debug.LogError("Road transform not found");

        CreatedSecondRoad();
    }

    private void CreatedSecondRoad()
    {
        secondRoad = Instantiate(roadTransform);
        secondRoad.SetParent(this.transform);
        Vector2 secondRoadPosition = (Vector2)secondRoad.position + Vector2.up * HEIGHT;
        secondRoad.position = secondRoadPosition;
        
        repeatPosition = secondRoadPosition;
    }

    private void FixedUpdate() => Move();

    private void Move()
    {
        Vector3 newPosition = Vector3.down * scrollSpeed * Time.fixedDeltaTime;
        this.roadTransform.Translate(newPosition);
        this.secondRoad.Translate(newPosition);
        if (roadTransform.localPosition.y < -HEIGHT)
            roadTransform.position = repeatPosition;

        if (secondRoad.localPosition.y < -HEIGHT)
            secondRoad.position = repeatPosition;
    }
}
