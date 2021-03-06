/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
https://developer.oculus.com/licenses/oculussdk/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using UnityEngine;

namespace Oculus.Interaction.Input
{
    public class FixedScaleDataModifier : Hand
    {
        [SerializeField]
        private float _scale = 1f;

        #region DataModifier Implementation
        protected override void Apply(HandDataAsset data)
        {
            Pose rootToPointer = PoseUtils.RelativeOffset(data.PointerPose, data.Root);
            rootToPointer.position = (rootToPointer.position / data.HandScale) * _scale;
            PoseUtils.Multiply(data.Root, rootToPointer, ref data.PointerPose);

            data.HandScale = _scale;
        }
        #endregion

        #region Inject
        public void InjectAllFixedScaleDataModifier(UpdateModeFlags updateMode, IDataSource updateAfter,
            DataModifier<HandDataAsset, HandDataSourceConfig> modifyDataFromSource, bool applyModifier,
            Component[] aspects, float scale)
        {
            base.InjectAllHand(updateMode, updateAfter, modifyDataFromSource, applyModifier, aspects);
            InjectScale(scale);
        }

        public void InjectScale(float scale)
        {
            _scale = scale;
        }
        #endregion
    }
}
