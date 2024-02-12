using UnityEngine;
using UnityEngine.UI;

namespace Assets.Dev2.sacip
{
    public class SoundSetButton : MonoBehaviour
    {
        [SerializeField] GameObject setpanel;

        public void CheckActive()
        {
            if(setpanel.activeInHierarchy == false)
            {
                setpanel.SetActive(true);
            } else if (setpanel.activeInHierarchy == true)
            {
                setpanel.SetActive(false);
            }
        }
    }
}
