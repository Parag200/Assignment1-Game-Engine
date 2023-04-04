using UnityEngine;
using System;

//allows edit to be seen during edit and scene view
[ExecuteInEditMode , ImageEffectAllowedInSceneView]
public class Blur : MonoBehaviour
{
	//source is current frame rendered
	//destination is output where effect will be written
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		//downscale by dividin width and height by 5
		int width = source.width / 5;
		int height = source.height / 5;

		RenderTextureFormat format = source.format;

		//creates a new RenderTexture object in memory and returns 
		//0 for depth buffer is only for 3D objects
		RenderTexture r = RenderTexture.GetTemporary(width, height, 0, format);

		//downscaled image set as r
		Graphics.Blit(source, r);
		//upscaling to be outputted to orginal size
		Graphics.Blit(r, destination);
		//release to free up memory 
		RenderTexture.ReleaseTemporary(r);
	}
}