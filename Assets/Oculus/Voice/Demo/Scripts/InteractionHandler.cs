/**************************************************************************************************
 * Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.
 *
 * Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
 * under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 **************************************************************************************************/

using Facebook.WitAi;
using Facebook.WitAi.Lib;
using UnityEngine;
using UnityEngine.UI;

namespace Oculus.Voice.Demo.UIShapesDemo
{
    public class InteractionHandler : MonoBehaviour
    {
        [Header("Default States"), Multiline]
        [SerializeField] private string freshStateText = "Try pressing the Activate button and saying \"Make the cube red\"";

        [Header("UI")]
        [SerializeField] private Text Status;
        //[SerializeField] private Text InputField;
        [SerializeField] private Text TextUp;
        [SerializeField] private bool showJson;

        [Header("Voice")]
        [SerializeField] private AppVoiceExperience appVoiceExperience;

        private string pendingText;

        public InputField InputField;

        private void OnEnable()
        {
            appVoiceExperience.events.OnRequestCreated.AddListener(OnRequestStarted);
            Debug.Log("OnRequestStarted: inicia la escucha");
            appVoiceExperience.Activate();
            //appVoiceExperience.events.OnRequestCreated.AddListener(StartMicrophone);
            //Debug.Log("StartRecording: inicia la grabacion");
        }

        private void OnDisable()
        {
            appVoiceExperience.events.OnRequestCreated.RemoveListener(OnRequestStarted);
            Debug.Log("OnDisable: la escucha");
        }

        private void OnRequestStarted(WitRequest r)
        {
            Debug.Log("OnRequestStarted: start recording");
            // The raw response comes back on a different thread. We store the
            // message received for display on the next frame.
            if (showJson) r.onRawResponse = (response) => pendingText = response;
        }

        private void Update()
        {
            if (null != pendingText)
            {
                Status.text = pendingText;
                pendingText = null;
            }
        }

        public void OnResponse(WitResponseNode response)
        {
            if (!string.IsNullOrEmpty(response["text"]))
            {
                Status.text = "I heard: " + response["text"];
                TextUp.text = response["text"];
                InputField.text = response["text"];
            }
            else
            {
                Status.text = freshStateText;
            }
        }

        public void OnError(string error, string message)
        {
            Status.text = $"<color=\"red\">Error: {error}\n\n{message}</color>";
        }

        public void ToggleActivation()
        {
            if (appVoiceExperience.Active) appVoiceExperience.Deactivate();
            else
            {
                appVoiceExperience.Activate();
            }
        }
    }
}
