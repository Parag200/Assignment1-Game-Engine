**Final Project ICG 100782088**

**Intergrations**





**Texturing**


**LUT**




**Visual Effect: Particle System and Decals**

Using the particle system in Unity, I modified it so that it would be a small burst with the material being a png image of dust. This 
indicates the player that their player has jump. With a colored outline of the dust, the speed , duration and amount of particles were changed.
Since the system would play once the player jump by pressing space, I did not want to have the particles flaring up the screen. Instead the 
particle system that was the final product is more gentle and smooth to the players, even if they jump alot the visual effect of the particle
system will not disturb the overall environment of Lava Run. Finally after the script was added on to the player, the particle system was then 
made into a child while having the MainPlayer the parent. This allows the particle system to move with the players movement.

I wanted to add this blood decal onto the starting wood cages because it would give my game an evil vibe to it paired with the lava.
To add Decals we want to have a image overlaying a texture but not actually be apart of the main texture itself. We start off with a shader that 
has 2 properties one for holding the main texture and the other for holding the decal. Inside the void surf function we have 2 differnt float4 equal 
to the main and decal texture. Finally we add the code to choose when the texture would be displayed, if the red channel of the b texture is above 0.9, 
the other texture will be displayed. Overall the final result is the blood decal being shown onto the wooden cages at the starting platforms.


**Additional Effects**
**Toon Shading**

For toon shading I used it on the end skulls and have them change to it once the player jumps and lands inside its collider. The reason I did this was because 
the toon shader on the skull looked gold and I wanted the player to feel some kind of accomplishment when they reached the final platform. With our texture going
from white to black, we create a material with a shader attached called ToonShader. Here we will be having a input for our rampTex while using the toonRamp lighting 
model. Inside the LightingToonRamp we will be getting the diffuse lighting by using the dot product on the surface normals and lightdirection.  After that we times it by 0.5
and add 0.5 so that it can be set to 1D so that it can be mapped, however we set it to a float2 called rh so that it can be sampled because if it were 1D it coulded be sampled.
Next we have the float3 ramp representing the toon shading appiled per current pixel and this is done by getting the tex2D(ramptexture we use and rh).rgb. Finally we get the color
by multiplying surface Albedo, Lightcolor and ramp. Set the c to the Albedo then return the c. In return shows toon lighting of a object based on the ramp texture. 


**Lava Wave & Texture Overlaying**

Firstly going over the Lava wave we have 4 set properties being the Freq, Amp, Speed and ColorTint. Using Lambert vertex:vert as we will be changing vertices. 
After declaring them and having the inputs have the MainTex and vertColor we get the position, normal and texcoords inside appdata. Inside the void vert function,
we will be having a float t equal _Time and the speed since the sine function will be using it. Now we find the waveHeight by using the sin function, multiplying
t, v.vertex.x ,freq * amp then doing it again by adding the same thing but this time have t and freq*2. What this does is maniuplate the vertices in the x axis.
After we update the vertices in the x axis making sure the current height is the current height we do this by having v.vertex.y = v.vertex.y + waveHeight.
Next we update the noramls by having normalx, y, z and wave height normalized then equalled to the normal. Finally the vertColor will change base on the height of wave, 
we do this by having the sum of the waveHeight and 2.

Secondly when talking about the texture overlaying, since it has nothing to do with vertices it can be in the same shader as the wave and all the work is done in the
void surf. We have the Main and OvermainTex as well as 2 ranges ScrollX and ScrollY. Here we have ScrollX and ScrollY multiplied by _Time as the textures will be moving 
during the game time duration. Next we set a fixed4 value for a and b, each value holding the main and overmaintex. Same code when applying the maintex but this time we are
adding a float2 with ScrollX and ScrollY, this will have the maintex moving with the time. We do the same for the overmaintex but this time we multiply the ScrollX and ScrollY
by 2 so that it has a different rate than the maintex. We does this because if they were both the same rate it would be hard to see both textures moving inside the game. 
Finally we get the average of the 2 rates by adding them together then dividing by 2.

**Outlining**

Outlining is used in the final project by having the final door have an outline of white. The reason why I added this into the game was to make 
the door pop out more to the player since white is a distinct color in my game. A material was made and attached to it is the outline shader, in this shader 
we are making 2 CGPROGRAM's where the first program is drawing and showing the outline and the second program is getting and showing the main texture as the 
albedo. 1 OutlineColor and 1 Outline Width declaring in the properties. In the first CGPROGRAM, we have ZWrite off so we can avoid drawing in the depth buffer. 
Using Lambert vertex:ver since we will be modifying vertices, inside void vert(appdata_full v), we are setting the offest of the vertices normal by the amount of the 
outline width. Next inside the void surf we set the o.Emission to the OutColor so that the outline can be see and has its own color that can be seen in the game.

**Post-Processing Effect: Pixelation**

I implemented a pixelation effect into my game because I wanted my game to have a retro style to it like back in the 90s. And after seeing what the pixelating effect
can do, I am satisfied with the job it has done. We start off making a C# script and attach it to the main camera. Inside the script we will be using OnRenderTexture
with source and destination in its parameters. Here the source indicates the current frame being buffered while the destination outputs where the effect will be drawn. 
Next we downscale the image by dividing its height and width by 5, creating RenderTextureFormat to make sure source is using the proper format. Create a RenderTexture
called r that has its set value on the downsize image with RenderTexture r = RenderTexture.GetTemporary(width, height, 0, format). Temporary as its more space efficent and 
will release render texture when done, 0 for the depth buffer. Finally we draw the downscaled image set to r then upscaling it to proper size into destination.


**Vertex Fragment Shader Shadows**

Making a simple inspired gates from Japan called Torii, I think this is a good way to show off the shadows each object has with the 
vertex fragment shader. The reason why I put these gates at the start and end of the level is to have the player sense progression, while 
also indicating the length of a level. As the player moves onwards the shadows from the gates hit the player and the floor. This was done 
by using a shader that had 2 passes, ignoring sources of light and using Unity's shadow functions. After finding the position coordinates
of the object, we mulitply them using the diffuse lighitng. In return allows us to have a object have its own shadow as it ignores all other 
light sources in Unity. Bump mapping code was added into the vertex fragment shader, allowing the Torii gate's to have a detailed wood material 
from 3Dtextures.me 

**Platforms, Walls**

The platforms in the low-fidelity game uses a bump shader effect to give the pop to the bricks on the texture. This was done by using the in class Shader code for from the lecture 3 (Bump Mapping) and applying the texture's normal map and height map. This gave us the bumping effect but my platforms didn't look visually pleasing relative to the light source from the bottom of the game level. To fix this I increased the slider to the max value being 10. This allowed the heightMap to show more of the vertex offset within the shader. This method was also used on the walls surrounding the platforms. My scene benefits from this shader beacuse of the directional and point lighting in my scene. With the main light sources coming from the lava, the bottom portion of the platform is well lit while the top has some lighting due to teh huge lava floor. This allows the heightMap to be used effectively as the partial light hitting the top platform can show the differences of vertex offset to the player clearly.

**Skulls**

For the skulls placed on the starting and end platforms, the main shader they have is rim Lighitng. Using the code from Lecture 3, the skulls shown highlights on the edge of their model. I changed the color and strength of the rimlighting to satisfy the red/lava environment. This was done by going on the inspector and changing the color from blue to red, while also lowering the slider to around 1.5 so the whole skull wouldn't be indulge in the rim color. This is important for its use showing off the Ambient, Specular, Ambient+Specular, and ToonRamp lighting because if the rim color was too strong, it would be harder to see the model change as its material changes. The shader code for the Ambient, Specular and Diffuse were used from the in class lecture 3 and Unity Scriping API, each of these shaders were placed in separated materials as it will be used for toggling each one on the skull objects.

The Specular shininess was increased in value because then it would only allow light that is shining on it to show back. Since the light was coming from the lava below, I didnt want the skulls in specular lighitng to have a large amonut of reflection since the light below cant reach them beacuse in between is a platform. This helps my scene look more realistic when specular lighting material is shown on the items relative to the lighting.

For the Toon Ramp Ligthing matieral, I used my own drawing of white to black for the shader to pick up and use when the light reflects off the object. This end results show the skull looking golden with the behind of the skull lit very nicely from the lava lighting. This helps my scene look better as it gives me the freedom to choose the amount of lighting displayed on the skull based off the texture given, allowing the skulls to catch the players eyes as visually pleasing.


**Slide Deck Link:** https://docs.google.com/presentation/d/1YXP5EyvWLPdmMngdt-yb-HTUtmF8Y_R9x3TgRF-LtyE/edit?usp=sharing

**Video Report:** 


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
