using UnityEngine;

namespace GameComponents
{
    [ExecuteInEditMode]
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        int rowCount = 6;

        [SerializeField]
        int columnCount = 6;

        [SerializeField]
        Vector3 spacing = new Vector3(1.0f, 0.0f, 1.0f);

        [SerializeField]
        BoxCollider boundsTrigger = null;

        void Update()
        {
            var cellSize = new Vector3(boundsTrigger.size.x / rowCount, boundsTrigger.size.y, boundsTrigger.size.z / columnCount);
            var cellExtent = cellSize * 0.5f;
            var startPosition = transform.position + new Vector3(-boundsTrigger.size.x, 0.0f, boundsTrigger.size.z) * 0.5f;
            int i = 0;

            for (int c = 0; c < columnCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (TryGetNextChild(ref i, out Transform child))
                    {
                        child.localScale = cellSize;

                        child.position = startPosition + new Vector3(cellExtent.x + spacing.x * r + cellSize.x * r, 0.0f, -(cellExtent.z + spacing.z * c + cellSize.z * c));
                    }
                }
            }
        }

        bool TryGetNextChild(ref int i, out Transform child)
        {
            if (i < transform.childCount)
            {
                child = transform.GetChild(i++);
                return true;
            }

            child = null;
            return false;
        }
    }
}