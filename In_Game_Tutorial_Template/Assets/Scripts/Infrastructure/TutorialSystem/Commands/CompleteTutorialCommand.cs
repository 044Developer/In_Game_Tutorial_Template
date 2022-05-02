using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using TutorialProject.UI.TutorialPanel.Model;
using UnityEngine;

namespace TutorialProject.Infrastructure.TutorialSystem.Commands
{
    public class CompleteTutorialCommand : ITutorialCommand
    {
        private const string TUTORIAL_SAVE_KEY = "Game_Tutorial_";
        
        private readonly TutorialDataModel m_tutorialDataModel;
        private readonly TutorialPanelModel m_tutorialPanelModel;
        private readonly TutorialSystemModel m_tutorialSystemModel;

        public CompleteTutorialCommand(TutorialDataModel tutorialDataModel, TutorialPanelModel tutorialPanelModel, TutorialSystemModel tutorialSystemModel)
        {
            m_tutorialDataModel = tutorialDataModel;
            m_tutorialPanelModel = tutorialPanelModel;
            m_tutorialSystemModel = tutorialSystemModel;
        }
        
        public void Execute()
        {
            DisposeCurrentEvent();

            DisposePanelView();
            
            SaveTutorial();
        }

        public void Exit()
        {
        }

        private void DisposeCurrentEvent()
        {
            m_tutorialSystemModel.IsTutorialActive = false;
            m_tutorialSystemModel.CurrentTutorialID = 0;
        }

        private void DisposePanelView()
        {
            m_tutorialPanelModel.ExecuteStepButton.gameObject.SetActive(false);
            m_tutorialPanelModel.FadeImage.gameObject.SetActive(false);
        }

        private void SaveTutorial()
        {
            if (HasCurrentTutorialSave())
                return;
            
            PlayerPrefs.SetInt($"{TUTORIAL_SAVE_KEY}{m_tutorialDataModel.TutorialID}", 1);
        }

        private bool HasCurrentTutorialSave()
        {
            bool hasSave = PlayerPrefs.HasKey($"{TUTORIAL_SAVE_KEY}{m_tutorialDataModel.TutorialID}");
            
            if (!hasSave) 
                return false;
            
            Debug.Log($"Tutorial - {m_tutorialDataModel.TutorialName} with ID:{m_tutorialDataModel.TutorialID} is already saved");
            return true;
        }
    }
}