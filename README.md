**Group Assignment ICG 100782088**

Using Lava Run prototype from assignment 1 and implementing a vertex/fragment shader, a visual effect and a post-processing effect.
Reusing the base component, illumnation, color grading, optional shader, pre-recorded demos.

Will be using the same clips from video report assignment 1, adding new clips explaining the new effects for the criteria. Thus in the video
I will be showing a time stamp to skip to as the first 9-10 minutes will be the same from assignment 1 with. This time stamp will forward
the report to the where I explain the newly implemented effects. 

(Wasn't unable to find a group, worked solo)

**LowRes PostProcessing Effect**

By creating a new render texture, I set the size of the dimensions to what I want my game to look like. Aiming for a retro-pixelated style,
I chose to make the dimensions of the render texutre 135. To make the new pixelated look not distorted, the Filter Mode for the render Texture
was set to Point. A Raw image was then made using the render texture with low re as its texture, Making the sure the raw image was set
properly to scale as it will be what the camera is seeing. The final step was creating a script and attaching it to the main camera. 
This script is able to turn on the low res render texture by changing the camera target texture via Input.GetKeyDown. Now when the player 
presses the button "T" the game will go into the low res style.

**Vertex Fragment Shader Shadows**

Making a simple inspired gates from Japan called Torii, I think this is a good way to show off the shadows each object has with the 
vertex fragment shader. The reason why I put these gates at the start and end of the level is to have the player sense progression, while 
also indicating the length of a level. As the player moves onwards the shadows from the gates hit the player and the floor. This was done 
by using a shader that had 2 passes, ignoring sources of light and using Unity's shadow functions. After finding the position coordinates
of the object, we mulitply them using the diffuse lighitng. In return allows us to have a object have its own shadow as it ignores all other 
light sources in Unity. Bump mapping code was added into the vertex fragment shader, allowing the Torii gate's to have a detailed wood material 
from 3Dtextures.me 

**Visual Effect**

Using the particle system in Unity, I modified it so that it would be a small burst with the material being a png image of dust. This 
indicates the player that their player has jump. With a colored outline of the dust, the speed , duration and amount of particles were changed.
Since the system would play once the player jump by pressing space, I did not want to have the particles flaring up the screen. Instead the 
particle system that was the final product is more gentle and smooth to the players, even if they jump alot the visual effect of the particle
system will not disturb the overall environment of Lava Run. Finally after the script was added on to the player, the particle system was then 
made into a child while having the MainPlayer the parent. This allows the particle system to move with the players movement.

**Platforms, Walls, End Door**

The platforms in the low-fidelity game uses a bump shader effect to give the pop to the bricks on the texture. This was done by using the in class Shader code for from the lecture 3 (Bump Mapping) and applying the texture's normal map and height map. This gave us the bumping effect but my platforms didn't look visually pleasing relative to the light source from the bottom of the game level. To fix this I increased the slider to the max value being 10. This allowed the heightMap to show more of the vertex offset within the shader. This method was also used on the walls surrounding the platforms. My scene benefits from this shader beacuse of the directional and point lighting in my scene. With the main light sources coming from the lava, the bottom portion of the platform is well lit while the top has some lighting due to teh huge lava floor. This allows the heightMap to be used effectively as the partial light hitting the top platform can show the differences of vertex offset to the player clearly.

**Skulls**

For the skulls placed on the starting and end platforms, the main shader they have is rim Lighitng. Using the code from Lecture 3, the skulls shown highlights on the edge of their model. I changed the color and strength of the rimlighting to satisfy the red/lava environment. This was done by going on the inspector and changing the color from blue to red, while also lowering the slider to around 1.5 so the whole skull wouldn't be indulge in the rim color. This is important for its use showing off the Ambient, Specular, Ambient+Specular, and ToonRamp lighting because if the rim color was too strong, it would be harder to see the model change as its material changes. The shader code for the Ambient, Specular and Diffuse were used from the in class lecture 3 and Unity Scriping API, each of these shaders were placed in separated materials as it will be used for toggling each one on the skull objects.

The Specular shininess was increased in value because then it would only allow light that is shining on it to show back. Since the light was coming from the lava below, I didnt want the skulls in specular lighitng to have a large amonut of reflection since the light below cant reach them beacuse in between is a platform. This helps my scene look more realistic when specular lighting material is shown on the items relative to the lighting.

For the Toon Ramp Ligthing matieral, I used my own drawing of white to black for the shader to pick up and use when the light reflects off the object. This end results show the skull looking golden with the behind of the skull lit very nicely from the lava lighting. This helps my scene look better as it gives me the freedom to choose the amount of lighting displayed on the skull based off the texture given, allowing the skulls to catch the players eyes as visually pleasing.


**Slide Deck Link:** https://docs.google.com/presentation/d/1YXP5EyvWLPdmMngdt-yb-HTUtmF8Y_R9x3TgRF-LtyE/edit?usp=sharing


**Resources (APA7)**

Font used for Win/Loss Screen Endgame. (n.d.). Dafont.com. Retrieved February 5, 2023, from https://www.dafont.com/endgame.font?text=Victory

3D Asset Used, Skulls (N.d.). Free3d.com. Retrieved February 5, 2023, from https://free3d.com/3d-model/skull-v3--785914.html

Lava Texture Store, M. (2016, May 5). Lava 002. 3D TEXTURES. https://3dtextures.me/2016/05/05/lava-002/

Lava Foam Texture https://www.filterforge.com/filters/1316.html

Wall Texture Store, M. (2022, January 4). Stone Path 007. 3D TEXTURES. https://3dtextures.me/2022/01/04/stone-path-007/

Door Texture Store, M. (2020, January 2). Wood Door 002. 3D TEXTURES. https://3dtextures.me/2020/01/02/wood-door-002/

Platform Texture Store, M. (2022b, May 21). Stylized Stone Floor 005. 3D TEXTURES. https://3dtextures.me/2022/05/21/stylized-stone-floor-005/

Unity API Scripting Unity Technologies. (n.d.). Unity - scripting API: Unity3d.com. Retrieved February 5, 2023, from https://docs.unity3d.com/ScriptReference/

YouTube. (2023). YouTube. Retrieved February 24, 2023, from https://www.youtube.com/watch?v=WKTZgf7ZDGs. 

Katsukagi. (2022, January 22). Wood 025. 3D TEXTURES. Retrieved February 24, 2023, from https://3dtextures.me/2022/01/22/wood-025/ 

White powder, white powder, linear powder, Powder Png. PNGWing. (n.d.). Retrieved February 24, 2023, from https://www.pngwing.com/en/free-png-ddgib 

Technologies, U. (n.d.). Camera.targettexture. Unity - Scripting API: Retrieved February 24, 2023, from https://dev.rbcafe.com/unity/unity-5.3.3/en/ScriptReference/Camera-targetTexture.html 

ICG Class Lectures 1 through 10
