namespace TutorialProject.Infrastructure.TutorialSystem.Data.Models
{
    public struct TutorialStepData
    {
        public int StepIndex { get; }
        public string DialogueTextKey { get; }
        public TutorialTextPosition TextPosition { get; }
        public int ArrowIndexID { get; }
        public string SpeakerAvatarName { get; }
        public bool HasFadePanel { get; }
        public bool HasOkButton { get; }

        public TutorialStepData
        (
            int stepIndex = 0, string dialogueTextKey = "",
            TutorialTextPosition textPosition = TutorialTextPosition.None,
            int arrowIndexID = -1, string speakerAvatarName = "",
            bool hasFadePanel = true, bool hasOkButton = false)
        {
            StepIndex = stepIndex;
            DialogueTextKey = dialogueTextKey;
            TextPosition = textPosition;
            ArrowIndexID = arrowIndexID;
            SpeakerAvatarName = speakerAvatarName;
            HasFadePanel = hasFadePanel;
            HasOkButton = hasOkButton;
        }
    }
}