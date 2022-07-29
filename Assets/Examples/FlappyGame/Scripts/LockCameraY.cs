using Cinemachine;

public class LockCameraY : CinemachineExtension {
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime) {
        // Lock cinemachine camera on the Y axis
        if(stage == CinemachineCore.Stage.Body) {
            var pos = state.RawPosition;
            pos.y = 0;
            state.RawPosition = pos;
        }
    }
}
