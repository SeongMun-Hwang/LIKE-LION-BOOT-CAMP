using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakTerrain : MonoBehaviour
{
    Tilemap tilemap; // Ÿ�ϸ��� ������ ����
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touched");

            // �浹�� ������ ù ��° ������ ��������
            ContactPoint2D contactPoint = collision.GetContact(0);

            // �浹�� ������ ���� ��ǥ ��������
            Vector3 hitPosition = contactPoint.point;

            // Ÿ�ϸ� ��ǥ�� ��ȯ
            Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);

            Debug.Log("Cell Position: " + cellPosition);

            // �ش� ��ǥ�� Ÿ�� ����
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
