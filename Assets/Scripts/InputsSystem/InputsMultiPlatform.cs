using UnityEngine;

public class InputsMultiPlatform : InputsSystem
{
   public bool DownClick()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) return true;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            // Use touches...
            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                    return true;
            }
        }
        return false;
    }
}
