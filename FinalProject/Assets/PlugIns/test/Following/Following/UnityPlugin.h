#include "IUnityInterface.h"
#include "IUnityGraphics.h"

extern "C"
{
    UNITY_INTERFACE_EXPORT void InitializeFollower(void* followerObject);
    UNITY_INTERFACE_EXPORT void FollowPlayer();
}
