namespace TutorialProject.Infrastructure.TutorialSystem.Data.Models
{
    public struct TutorialStepData
    {
        public int StepIndex { get; }
        public string DialogueTextKey { get; }
        public TutorialTextPosition TextPosition { get; }
        public int ArrowIndexID { get; }
        public int SpeakerAvatarID { get; }
        public bool HasFadePanel { get; }
        public bool HasOkButton { get; }

        public TutorialStepData
        (
            int stepIndex = 0, string dialogueTextKey = "",
            TutorialTextPosition textPosition = TutorialTextPosition.None,
            int arrowIndexID = -1, int speakerAvatarID = 0,
            bool hasFadePanel = true, bool hasOkButton = false)
        {
            StepIndex = stepIndex;
            DialogueTextKey = dialogueTextKey;
            TextPosition = textPosition;
            ArrowIndexID = arrowIndexID;
            SpeakerAvatarID = speakerAvatarID;
            HasFadePanel = hasFadePanel;
            HasOkButton = hasOkButton;
        }
    }
}