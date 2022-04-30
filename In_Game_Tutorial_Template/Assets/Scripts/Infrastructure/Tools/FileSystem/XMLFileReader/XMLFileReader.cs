using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TutorialProject.Infrastructure.TutorialSystem.Data.Models;
using UnityEngine;

namespace TutorialProject.Infrastructure.Tools.FileSystem.XMLFileReader
{
    public class XMLFileReader
    {
        private const string TUTORIAL_SCENARIO_PATH = "/TutorialScenario.xml";
        
        private XmlDocument m_xmlDocument = null;
        private TextAsset m_xmlAsset = null;
        private string m_xmlText = string.Empty;

        public XMLFileReader()
        {
            m_xmlDocument = new XmlDocument();
        }

        public List<TutorialDataModel> ReadXMLTutorialModels()
        {
            List<TutorialDataModel> result = new List<TutorialDataModel>();
            string scenarioPath = $"{Application.streamingAssetsPath}{TUTORIAL_SCENARIO_PATH}";
            
            if(string.IsNullOrEmpty(m_xmlText))
            {
                m_xmlText = File.ReadAllText(scenarioPath);
            }
            
            m_xmlDocument.LoadXml(m_xmlText);
            m_xmlText = string.Empty;
            
            XmlNode mainNode = m_xmlDocument.SelectSingleNode("tutorialPresets");
            XmlNode tutorialNodes = mainNode?.SelectSingleNode("tutorials");

            foreach (XmlNode tutorialNode in tutorialNodes.ChildNodes)
            {
                TutorialDataModel tempModel = ParseTutorialData(tutorialNode);
                result.Add(tempModel);
            }

            return result;
        }

        private TutorialDataModel ParseTutorialData(XmlNode tutorialNode)
        {
            XmlNodeList tutorialSteps = tutorialNode.ChildNodes;
            List<TutorialStepData> tutorialStepDataList = ParseTutorialStepData(tutorialSteps);

            var tutorialIDAttribute = ReturnNodeAttribute(tutorialNode,"tutorialID");
            var tutorialNameAttribute = ReturnNodeAttribute(tutorialNode,"tutorialName");
            var canSkipAttribute = ReturnNodeAttribute(tutorialNode,"canSkip");

            int tutorialID = -1;
            string tutorialName = string.Empty;
            bool canSkip = false;

            if (tutorialIDAttribute != null)
                int.TryParse(tutorialIDAttribute.Value, out tutorialID);
            if (tutorialNameAttribute != null)
                tutorialName = tutorialNameAttribute.Value;
            if (canSkipAttribute != null)
                bool.TryParse(canSkipAttribute.Value, out canSkip);

            TutorialDataModel tempModel = new TutorialDataModel(tutorialID, tutorialName, canSkip, tutorialStepDataList);
            return tempModel;
        }

        private List<TutorialStepData> ParseTutorialStepData(XmlNodeList tutorialSteps)
        {
            List<TutorialStepData> tutorialStepDataList = new List<TutorialStepData>();

            for (int i = 0; i < tutorialSteps.Count; i++)
            {
                var stepIndexAttribute = ReturnNodeAttribute(tutorialSteps[i],"stepIndex");
                var textKeyAttribute = ReturnNodeAttribute(tutorialSteps[i],"textKey");
                var textPositionAttribute = ReturnNodeAttribute(tutorialSteps[i],"textPosition");
                var arrowIndexAttribute = ReturnNodeAttribute(tutorialSteps[i],"arrowIndex");
                var speakerAvatarNameAttribute = ReturnNodeAttribute(tutorialSteps[i],"speakerAvatarName");
                var hasFadePanelAttribute = ReturnNodeAttribute(tutorialSteps[i],"hasFadePanel");
                var hasOkButtonAttribute = ReturnNodeAttribute(tutorialSteps[i],"hasOkButton");

                int stepIndex = -1;
                string textKey = string.Empty;
                TutorialTextPosition textPosition = TutorialTextPosition.None;
                int arrowIndex = -1;
                string speakerAvatarName = string.Empty;
                bool hasFadePanel = false;
                bool hasOkButton = false;

                if (stepIndexAttribute != null)
                    int.TryParse(stepIndexAttribute.Value, out stepIndex);
                if (textKeyAttribute != null)
                    textKey = textKeyAttribute.Value;
                if (textPositionAttribute != null)
                    Enum.TryParse(textPositionAttribute.Value, out textPosition);
                if (arrowIndexAttribute != null)
                    int.TryParse(arrowIndexAttribute.Value, out arrowIndex);
                if (speakerAvatarNameAttribute != null)
                    speakerAvatarName = speakerAvatarNameAttribute.Value;
                if (hasFadePanelAttribute != null)
                    bool.TryParse(hasFadePanelAttribute.Value, out hasFadePanel);
                if (hasOkButtonAttribute != null)
                    bool.TryParse(hasOkButtonAttribute.Value, out hasOkButton);

                var stepData = new TutorialStepData(stepIndex, textKey, textPosition, arrowIndex, speakerAvatarName,
                    hasFadePanel, hasOkButton);
                tutorialStepDataList.Add(stepData);
            }

            return tutorialStepDataList;
        }

        private XmlNode ReturnNodeAttribute(XmlNode parentNode, string attributeName)
        {
            if (parentNode != null)
                return parentNode.Attributes.GetNamedItem(attributeName);

            Debug.Log($"While returning {attributeName} null Exception was caught");
            return null;
        }
    }
}