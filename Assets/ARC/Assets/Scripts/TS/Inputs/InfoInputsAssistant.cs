// Description: InfoInputsAssistant. Useful method to use in association with InfoInputs
using UnityEngine;

namespace TS.Generics
{
    public class InfoInputsAssistant : MonoBehaviour
    {
        public float MobileInputExample()
        {
            if (ControlFreak2.CF2Input.GetKey(KeyCode.E))
                return 1;
            else
                return 0;
        }

        public float OtherInputExample()
        {
            if (ControlFreak2.CF2Input.GetKey(KeyCode.F))
                return 1;
            else
                return 0;
        }
    }

}
