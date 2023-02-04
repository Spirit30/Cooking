using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public static class CommonExtensions
{
    #region INT

    public static int ToInt(this bool flag)
    {
        return flag ? 1 : 0;
    }

    public static bool ToBool(this int i)
    {
        return i > 0;
    }

    public static int IncrementLoopIndex(this ref int i, int collectionLength)
    {
        ++i;
        if(i >= collectionLength)
        {
            i = 0;
        }
        return i;
    }

    public static int IncrementLoopIndex(this ref int i, int collectionLength, int offset = 0)
    {
        ++i;
        if(i >= collectionLength)
        {
            i = offset;
        }
        return i;
    }

    public static int DecrementLoopIndex(this ref int i, int collectionLength)
    {
        --i;
        if (i < 0)
        {
            i = collectionLength - 1;
        }
        return i;
    }

    #endregion

    #region FLOAT

    public static float ToFloat(this bool flag)
    {
        return flag.ToInt();
    }

    public static bool ToBool(this float f)
    {
        return ((int)f).ToBool();
    }

    #endregion

    #region STRING

    public static string FirstCharToUpper(this string s)
    {
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    #endregion

    #region TRANSFORM

    public static void ResetLocal(this Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    public static void SetScaleX(this Transform t, float x)
    {
        Vector3 scale = t.localScale;
        scale.x = x;
        t.localScale = scale;
    }

    public static void SetScaleY(this Transform t, float y)
    {
        Vector3 scale = t.localScale;
        scale.y = y;
        t.localScale = scale;
    }

    public static void SetScaleZ(this Transform t, float z)
    {
        Vector3 scale = t.localScale;
        scale.z = z;
        t.localScale = scale;
    }

    public static void DestroyAllChildren(this Transform t)
    {
        while(t.childCount > 0)
        {
            UnityEngine.Object.DestroyImmediate(t.GetChild(0).gameObject);
        }
    }

    public static IEnumerable<Transform> GetChildren(this Transform t)
    {
        for(int i = 0; i < t.childCount; ++i)
        {
            yield return t.GetChild(i);
        }
    }

    public static float Distance(this Transform t, Vector3 point)
    {
        return Vector3.Distance(t.position, point);
    }

    public static Vector3 Direction(this Transform t, Vector3 point)
    {
        return point - t.position;
    }

    #endregion

    #region MONOBEHAVIOUR

    public static void AddComponent<T>(this MonoBehaviour monoBehaviour) where T : MonoBehaviour
    {
        monoBehaviour.gameObject.AddComponent<T>();
    }

    public static void AddComponent(this MonoBehaviour monoBehaviour, Type type)
    {
        monoBehaviour.gameObject.AddComponent(type);
    }

    #endregion

    #region PLATFORM

    public static bool IsMobile(this RuntimePlatform platform)
    {
        return platform == RuntimePlatform.IPhonePlayer
            || platform == RuntimePlatform.Android;
    }

    public static bool IsEditor(this RuntimePlatform platform)
    {
        return platform == RuntimePlatform.WindowsEditor
            || platform == RuntimePlatform.OSXEditor
            || platform == RuntimePlatform.LinuxEditor;
    }

    #endregion

    #region COLLECTIONS

    public static T GetRandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    public static T GetRandomItem<T>(this Array array)
    {
        return (T)array.GetValue(Random.Range(0, array.Length));
    }

    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T[] AddToNew<T>(this T[] array, T item)
    {
        T[] @new = new T[array.Length + 1];
        Array.Copy(array, @new, array.Length);
        @new[array.Length] = item;
        return @new;
    }

    public static T First<T>(this T[] array)
    {
        return array[0];
    }

    public static T First<T>(this List<T> list)
    {
        return list[0];
    }

    public static T Last<T>(this T[] array)
    {
        return array[array.Length - 1];
    }

    public static T Last<T>(this List<T> list)
    {
        return list[list.Count - 1];
    }

    public static T GetOrAllocate<T>(this List<T> list, int index) where T : new()
    {
        if(index < list.Count)
        {
            return list[index];
        }

        T @new =  new T();
        list.Add(@new);
        return @new;
    }

    public static T Next<T>(this T[] array, ref int currentIndex)
    {
        if (currentIndex >= array.Length)
        {
            currentIndex = 0;
        }

        return array[currentIndex++];
    }

    public static int IndexOf<T>(this T[] array, T item)
    {
        return Array.IndexOf(array, item);
    }

    public static int FindIndex<T>(this T[] array, Predicate<T> predicate)
    {
        var item = array.Single(i => predicate(i));
        return array.IndexOf(item);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> array)
    {
        return array.OrderBy(a => Guid.NewGuid());
    }

    public static T[] Shuffle<T>(this T[] array)
    {
        return array.Shuffle().ToArray();
    }

    public static List<T> Shuffle<T>(this List<T> array)
    {
        return array.Shuffle().ToList();
    }
    
    /// <summary>
    /// Performs centering the list, based on center index and count of elements surrounding it. It allows to trim the
    /// list by including only elements that are in range of center element.
    /// </summary>
    /// <param name="list">Source list</param>
    /// <param name="centerIndex">Index of element by which centering is performing</param>
    /// <param name="prev">Count of elements that should be before center element</param>
    /// <param name="next">Count of elements that should be after center element</param>
    /// <returns>List that is centered</returns>
    public static IEnumerable<T> CenterList<T>(this IEnumerable<T> list, int centerIndex, int prev, int next)
    {
        var skipCount = Mathf.Max(centerIndex - prev, 0);
        var takePrevCount = Mathf.Max(centerIndex - skipCount, 0);
        return list.Skip(skipCount).Take(takePrevCount + 1 + next);
    }

    public static int LastIndex<T>(this T[] array)
    {
        return array.Length - 1;
    }

    public static int LastIndex<T>(this List<T> list)
    {
        return list.Count - 1;
    }

    #endregion

    #region ENUM

    public static T GetRandomEnumValue<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).GetRandomItem<T>();
    }

    #endregion

    #region LAYER MASK

    public static bool IsLayer(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    #endregion

    #region RENDER

    public static void AddMaterial(this MeshRenderer meshRenderer, Material material)
    {
        List<Material> materials = new List<Material>();
        meshRenderer.GetMaterials(materials);
        materials.Add(material);
        meshRenderer.materials = materials.ToArray();
    }

    public static void AddSharedMaterial(this MeshRenderer meshRenderer, Material sharedMaterial)
    {
        List<Material> sharedMaterials = new List<Material>();
        meshRenderer.GetSharedMaterials(sharedMaterials);
        sharedMaterials.Add(sharedMaterial);
        meshRenderer.sharedMaterials = sharedMaterials.ToArray();
    }

    #endregion

    #region UI

    public static void Activate(this UIBehaviour uiBehaviour, bool flag)
    {
        uiBehaviour.gameObject.SetActive(flag);
    }

    public static Vector3 GetWorldCenter(this RectTransform rectTransform)
    {
        const int CORNERS_COUNT = 4;

        var corners = new Vector3[CORNERS_COUNT];
        rectTransform.GetWorldCorners(corners);

        var cummulative = Vector3.zero;

        foreach(var corner in corners)
        {
            cummulative += corner;
        }

        return cummulative / CORNERS_COUNT;
    }

    #endregion

    #region VECTOR

    public static string Print(this Vector3 v)
    {
        return $"x: {v.x}, y: {v.y}, z: {v.z}";
    }

    public static string Print(this Vector2 v)
    {
        return $"x: {v.x}, y: {v.y}";
    }

    #endregion

    #region STRING

    public static string Bold(this string text)
    {
        return $"<b>{text}</b>";
    }

    public static string Italic(this string text)
    {
        return $"<i>{text}</i>";
    }

    public static string Color(this string text, string color)
    {
        return $"<color={color}>{text}</color>";
    }

    #endregion

    #region COROUTINES

    public static void WaitSecondsAction(this MonoBehaviour behaviour, Action action, float wait)
    {
        behaviour.StartCoroutine(WaitSecondsCoroutine(action, wait));
    }

    public static void WaitFrameAction(this MonoBehaviour behaviour, Action action)
    {
        behaviour.StartCoroutine(WaitFrameCoroutine(action));
    }

    public static void StopWaitActions(this MonoBehaviour behaviour)
    {
        behaviour.StopAllCoroutines();
    }

    static IEnumerator WaitSecondsCoroutine(Action action, float wait)
    {
        yield return new WaitForSeconds(wait);
        action();
    }

    static IEnumerator WaitFrameCoroutine(Action action)
    {
        yield return null;
        action();
    }

    #endregion

    #region AUDIO

    public static void Is3D(this AudioSource audioSource, bool value)
    {
        audioSource.spatialBlend = value.ToFloat();
    }

    public static bool Is3D(this AudioSource audioSource)
    {
        return audioSource.spatialBlend.ToBool();
    }

    #endregion

    #region TEXTURE

    public static void Cut(this Texture2D texture, RectInt pixelRect)
    {
        Color[] pixels =
            texture.GetPixels(
                pixelRect.x,
                pixelRect.y,
                pixelRect.width,
                pixelRect.height);

        texture.Resize(pixelRect.width, pixelRect.height);
        texture.SetPixels(pixels);
        texture.Apply();
    }

    public static bool IsSupported(this Texture2D texture, string extention)
    {
        switch (extention.ToLower())
        {
            case ".png":
            case ".jpg":
            case ".jpeg":
            case ".tga":
            case ".exr":
                return true;
        }
        return false;
    }

    public static byte[] Encode(this Texture2D texture, string extention)
    {
        switch (extention.ToLower())
        {
            case ".png":
                return texture.EncodeToPNG();
            case ".jpg":
            case ".jpeg":
                return texture.EncodeToJPG();
            case ".tga":
                return texture.EncodeToTGA();
            case ".exr":
                return texture.EncodeToEXR();
        }
        throw new TextureExtensionNotSupportedException(texture, extention);
    }

    public static void ThrowNotSupportedException(this Texture2D texture, string extention)
    {
        throw new TextureExtensionNotSupportedException(texture, extention);
    }

    class TextureExtensionNotSupportedException : Exception
    {
        public TextureExtensionNotSupportedException(Texture2D texture, string extention)
            : base($"Can't encode {texture.name} to {extention} because it is not supported.") { }
    }

    #endregion
}
