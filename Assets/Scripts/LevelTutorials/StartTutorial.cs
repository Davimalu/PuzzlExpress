using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (TriggerTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TriggerTutorial()
    {
        yield return new WaitForSeconds(4.5f);
        foreach (Transform child in transform)
        {
            if (!child.name.Contains("Arrow") /*|| child.name == "teacher" || child.name == "SpeechBox" || child.name == "BackgroundDarkener"*/) {
                if (child.name == "teacher" || child.name == "SpeechBox") {
                    yield return new WaitForSeconds(0.5f);
                }
                child.gameObject.SetActive(true);
                yield return StartCoroutine(FadeInImage(child.gameObject, 0.5f));
            }
        }
    }

    public static IEnumerator FadeInImage(GameObject gameObject, float duration)
    {
        Image image = gameObject.GetComponent<Image>();
        float elapsedTime = 0f;
        Color initialColor = image.color;
        initialColor.a = 0f;
        image.color = initialColor;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            if (image.name.Contains("BackgroundDarkener") && alpha > 0.78) break;
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (image.name.Contains("BackgroundDarkener")) image.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.78f);
        else image.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
    }

    /*public static IEnumerator FadeInMesh(GameObject gameObject, float duration)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        // Set the material to use transparency
        material.SetFloat("_Mode", 2); // Transparent mode
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000;

        Mesh mesh = meshRenderer.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        // Initialize colors to fully transparent
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(1, 1, 1, 0);
        }
        mesh.colors = colors;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float progress = Mathf.Clamp01(elapsedTime / duration);

            // Update vertex colors based on their z position and progress
            for (int i = 0; i < vertices.Length; i++)
            {
                float alpha = Mathf.Lerp(0, 1, (vertices[i].z + 1) / 2 * progress); // Adjust based on z position
                colors[i] = new Color(1, 1, 1, alpha);
            }
            mesh.colors = colors;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final state is fully opaque
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(1, 1, 1, 1);
        }
        mesh.colors = colors;
    }*/
}