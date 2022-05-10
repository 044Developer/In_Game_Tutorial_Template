using System.Collections.Generic;
using TMPro;
using TutorialProject.ApplicationBase;
using TutorialProject.Infrastructure.TutorialSystem.Controller;
using TutorialProject.Infrastructure.TutorialSystem.Data.HighlightedData;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialProject.UI.MainTestPanel
{
    public class MainTestPanel : MonoBehaviour
    {
        private const string TUTORIAL_REGULAR_TEXT = "Start tutorial with index - ";
        private const string TUTORIAL_NO_DATA_TEXT = "Missing tutorial with index - ";
        
        [Header("Buttons")]
        [SerializeField] private Button m_leftBottomButton = null;
        [SerializeField] private Button m_rightBottomButton = null;
        [SerializeField] private Button m_leftTopButton = null;
        [SerializeField] private Button m_rightTopButton = null;
        [SerializeField] private Button m_startTutorialButton = null;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI m_currentTutorialText = null;

        private int m_currentTutorialIndex = 0;
        private TutorialSystemController m_tutorialSystemController = null;

        private void Start()
        {
            InitializeEvents();
            InitializeButtons();
            Construct();
        }

        private void OnDestroy()
        {
            DisposeEvents();
            DisposeButtons();
        }

        private void Construct()
        {
            m_tutorialSystemController = ApplicationController.Instance.TutorialSystemController;
        }

        private void InitializeEvents()
        {
            ApplicationController.Instance.EventHolder.OnExecuteTutorialStepEvent += OnExecuteTutorialStep;
        }

        private void InitializeButtons()
        {
            m_leftBottomButton.onClick.AddListener(OnLeftBottomButtonClick);
            m_rightBottomButton.onClick.AddListener(OnRightBottomButtonClick);
            m_leftTopButton.onClick.AddListener(OnLeftTopButtonClick);
            m_rightTopButton.onClick.AddListener(OnRightTopButtonClick);
            m_startTutorialButton.onClick.AddListener(OnStartTutorialButtonClick);
        }

        private void DisposeEvents()
        {
            ApplicationController.Instance.EventHolder.OnExecuteTutorialStepEvent -= OnExecuteTutorialStep;
        }

        private void DisposeButtons()
        {
            m_leftBottomButton.onClick.RemoveListener(OnLeftBottomButtonClick);
            m_rightBottomButton.onClick.RemoveListener(OnRightBottomButtonClick);
            m_leftTopButton.onClick.RemoveListener(OnLeftTopButtonClick);
            m_rightTopButton.onClick.RemoveListener(OnRightTopButtonClick);
            m_startTutorialButton.onClick.RemoveListener(OnStartTutorialButtonClick);
        }

        private void OnLeftBottomButtonClick() => 
            ApplicationController.Instance.TutorialSystemController.ProceedWithNextTutorialStep();

        private void OnRightBottomButtonClick() => 
            ApplicationController.Instance.TutorialSystemController.ProceedWithNextTutorialStep();

        private void OnLeftTopButtonClick() => 
            ApplicationController.Instance.TutorialSystemController.ProceedWithNextTutorialStep();

        private void OnRightTopButtonClick() => 
            ApplicationController.Instance.TutorialSystemController.ProceedWithNextTutorialStep();

        private void OnStartTutorialButtonClick()
        {
            bool canStartTutorial = m_tutorialSystemController.StartTutorial(m_currentTutorialIndex);

            m_currentTutorialText.text = canStartTutorial
                ? $"{TUTORIAL_REGULAR_TEXT}{m_currentTutorialIndex}"
                : $"{TUTORIAL_NO_DATA_TEXT}{m_currentTutorialIndex}";

            m_currentTutorialIndex++;
        }

        private void OnExecuteTutorialStep()
        {
            int currentTutorialID = m_tutorialSystemController.TutorialModel.CurrentTutorialID;
            int currentTutorialStepIndex = m_tutorialSystemController.TutorialModel.CurrentStepIndex;

            if (currentTutorialID == 0)
            {
                if (currentTutorialStepIndex == 1)
                {
                    UIHighlightedElement element = new UIHighlightedElement(m_leftBottomButton.gameObject);
                    m_tutorialSystemController.HighlightTutorialElements(new List<IHighlightedTutorialElement> { element });
                }
                else if (currentTutorialStepIndex == 2)
                {
                    UIHighlightedElement element = new UIHighlightedElement(m_rightBottomButton.gameObject);
                    m_tutorialSystemController.HighlightTutorialElements(new List<IHighlightedTutorialElement> { element });
                }
            }
        }
    }
}
