using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakTerrain : MonoBehaviour
{
    Tilemap tilemap; // 타일맵을 연결할 변수
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touched");

            // 충돌한 지점의 첫 번째 접촉점 가져오기
            ContactPoint2D contactPoint = collision.GetContact(0);

            // 충돌한 지점의 월드 좌표 가져오기
            Vector3 hitPosition = contactPoint.point;

            // 타일맵 좌표로 변환
            Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);

            Debug.Log("Cell Position: " + cellPosition);

            // 해당 좌표의 타일 삭제
            if (tilemap.HasTile(cellPosition))
            {
                Debug.Log("Tile found, deleting...");
                tilemap.SetTile(cellPosition, null);
            }
            else
            {
                Debug.Log("No tile found at position: " + cellPosition);
            }
        }
    }
}
