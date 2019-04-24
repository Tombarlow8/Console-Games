using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Lost_in_Space
{
    public class Ship
    {
       
        public Dictionary<string, int> importantSystems = new Dictionary<string, int>();
        public Dictionary<string, int> lessImportantSystems = new Dictionary<string, int>();


        public int computerAIstatus, lifeSupportStatus, enginesStatus; //Important systems 
        public int gravitySystemStatus, weaponsSystemStatus, hullIntegrity, chanceOfSurvival; //Less important 
        ConsoleColor computerAIstatusColour, lifeSupportStatusColour, gravitySystemStatusColour;
        ConsoleColor weaponsSystemStatusColour, hullIntegrityColour, enginesStatusColour;
        Random rand = new Random();

        Scenarios scenarios = new Scenarios();

        int scenarioCount;
        List<Action> scenarioList = new List<Action>();

        public void generateScenarioList()
        {
            //find a way  to do this dynamicaly REFLECTION!!!!!!!!!!
            #region Scenarios added to the list
            scenarioList.Add(scenarios.scenario1);
            scenarioList.Add(scenarios.scenario2);
            scenarioList.Add(scenarios.scenario3);
            scenarioList.Add(scenarios.scenario4);
            #endregion

            scenarioCount = scenarioList.Count();
        }

        public void invokeScenario()
        {    
            int scenarioNumber = rand.Next(0, scenarioCount-1);
            scenarioList[scenarioNumber].Invoke();
            string[] resultStringSplit = scenarios.userResult.Split(null);
            int systemValueModifier = Convert.ToInt16(resultStringSplit[1]);

           
            //damage = Convert.ToInt16(resultStringSplit[1]);
            if (importantSystems.ContainsKey(resultStringSplit[0]))
            {
                importantSystems[resultStringSplit[0]] += systemValueModifier;
            }
            else
            {
                lessImportantSystems[resultStringSplit[0]] += systemValueModifier;
            }
           
            scenarioList.Remove(scenarioList[scenarioNumber]);

            takeDamage();
        }

        void takeDamage()
        {

            computerAIstatus = importantSystems["computerAIstatus"];
            lifeSupportStatus = importantSystems["lifeSupportStatus"];
            enginesStatus = importantSystems["enginesStatus"];
            gravitySystemStatus = lessImportantSystems["gravitySystemStatus"];
            weaponsSystemStatus = lessImportantSystems["weaponsSystemStatus"];
            hullIntegrity = lessImportantSystems["hullIntegrity"];
        }

        public void Introduction()
        {
            ComputerOutput(SlowType("As you know captain, our journey has been interrupted by a spacial anomaly\n", ConsoleColor.DarkGreen));
            ComputerOutput(SlowType("Manual control has been returned. Would you like to see a status report?\n", ConsoleColor.DarkGreen));
            SlowType("Y/N?\n", ConsoleColor.DarkGreen);

            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y" || answer == "Yes" || answer == "yes")
            {
                SystemStatusReport();
            }
        }

        public void SystemStartUp()
        {
            Random rand = new Random();

            //difficulty system determining min set in a variable?
            // like this computerAIstatus = rand.Next(min, 75);
            // public int minStatus = easy 35 medium 25 hard 15

            computerAIstatus = rand.Next(15, 75);
            //computerAIstatus = 100;
            lifeSupportStatus = rand.Next(15, 75);
            enginesStatus = rand.Next(15, 75);
            gravitySystemStatus = rand.Next(15, 75);
            weaponsSystemStatus = rand.Next(15, 75);
            hullIntegrity = rand.Next(15, 75);

            importantSystems.Add("computerAIstatus", computerAIstatus);
            importantSystems.Add("lifeSupportStatus", lifeSupportStatus);
            importantSystems.Add("enginesStatus", enginesStatus);
            lessImportantSystems.Add("gravitySystemStatus", gravitySystemStatus);
            lessImportantSystems.Add("weaponsSystemStatus", weaponsSystemStatus);
            lessImportantSystems.Add("hullIntegrity", hullIntegrity);

        }

        public void SystemStatusReport()
        {
            SetStatusColour();
            Console.Beep();
            SlowType("Ship AI status is at " + computerAIstatus  + "%\n", computerAIstatusColour);
            SlowType("Life Support status is at " + lifeSupportStatus + "%\n", lifeSupportStatusColour);
            SlowType("Engines Status is at " + enginesStatus + "%\n", enginesStatusColour);
            SlowType("Gravity System Status is at " + gravitySystemStatus + "%\n", gravitySystemStatusColour);
            SlowType("Weapons System status is at " + weaponsSystemStatus + "%\n", weaponsSystemStatusColour);
            SlowType("Hull Integrity is at " + hullIntegrity + "%\n", hullIntegrityColour);
            
        }

        public bool SystemHealthCheck()
        {
            int[] importantSystems = new int[] {computerAIstatus, lifeSupportStatus, enginesStatus};
            int[] lessImportantSystems = new int[] {gravitySystemStatus, weaponsSystemStatus, hullIntegrity};

            bool tempHealthCheck = true;

            foreach (int system in importantSystems)
            {
                if (system > 0 )
                {
                    tempHealthCheck = true;
                }
                else
                {
                    tempHealthCheck = false;
                    break;
                }
            }

            return (!tempHealthCheck) ? false :true;
        }

        public void SystemScenarioResult(string resultInput)
        {          
            Console.WriteLine(gravitySystemStatus.ToString());   
        }

        private void SetStatusColour()
        {

            if (computerAIstatus >= 75)
            {
                computerAIstatusColour = ConsoleColor.Green;
            }
            else if (computerAIstatus >= 26 && computerAIstatus <= 74)
            {
                computerAIstatusColour = ConsoleColor.Yellow;
            }
            else
            {
                computerAIstatusColour = ConsoleColor.Red;
            }

            if (lifeSupportStatus >= 75)
            {
                lifeSupportStatusColour = ConsoleColor.Green;
            }
            else if (lifeSupportStatus >= 26 && lifeSupportStatus <= 74)
            {
                lifeSupportStatusColour = ConsoleColor.Yellow;
            }
            else
            {
                lifeSupportStatusColour = ConsoleColor.Red;
            }

            if (enginesStatus >= 75)
            {
                enginesStatusColour = ConsoleColor.Green;
            }
            else if (enginesStatus >= 26 && enginesStatus <= 74)
            {
                enginesStatusColour = ConsoleColor.Yellow;
            }
            else
            {
                enginesStatusColour = ConsoleColor.Red;
            }

            if (gravitySystemStatus >= 75)
            {
                gravitySystemStatusColour = ConsoleColor.Green;
            }
            else if (gravitySystemStatus >= 26 && gravitySystemStatus <= 74)
            {
                gravitySystemStatusColour = ConsoleColor.Yellow;
            }
            else
            {
                gravitySystemStatusColour = ConsoleColor.Red;
            }

            if (weaponsSystemStatus >= 75)
            {
                weaponsSystemStatusColour = ConsoleColor.Green;
            }
            else if (weaponsSystemStatus >= 26 && weaponsSystemStatus <= 74)
            {
                weaponsSystemStatusColour = ConsoleColor.Yellow;
            }
            else
            {
                weaponsSystemStatusColour = ConsoleColor.Red;
            }

            if (hullIntegrity >= 75)
            {
                hullIntegrityColour = ConsoleColor.Green;
            }
            else if (hullIntegrity >= 26 && hullIntegrity <= 74)
            {
                hullIntegrityColour = ConsoleColor.Yellow;
            }
            else
            {
                hullIntegrityColour = ConsoleColor.Red;
            }
        }

        private string SlowType(string slowInput, ConsoleColor consoleColor)
        {
            char[] slowtypeLetters = slowInput.ToArray();

            foreach (char slowTypeletter in slowtypeLetters)
            {
                Console.ForegroundColor = consoleColor;
                Console.Write(slowTypeletter);
                Thread.Sleep(25);
            }

            return slowInput;
        }

        private void ComputerOutput(string computerOutputString)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Female); 
            
            if (computerAIstatus > 70)
            {
                synth.Speak(computerOutputString);
            }
        }

        public void SpeechRecognitionApp()
        {
            ManualResetEvent completed = null;
            completed = new ManualResetEvent(false);
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Choices choiceList = new Choices(new string[] { "test", "Yes", "No", "one", "Two", "Three", "Four", "Confirm" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder(choiceList)));
            recognizer.SpeechRecognized += recognizerSpeechRecognized;
            recognizer.SpeechRecognitionRejected += recognizerSpeechRecognitionRejected;
            recognizer.SetInputToDefaultAudioDevice(); // set the input of the speech recognizer to the default audio device
            recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous
            completed.WaitOne(); // wait until speech recognition is completed
            recognizer.Dispose(); // dispose the speech recognition engine

            void recognizerSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                switch (e.Result.Text)
                {
                    case "test":
                        Console.WriteLine("The test was successful!");//insert booleans to determine answer yes = true next function looks at 
                        break;
                    case "Yes":
                        Console.WriteLine("you said yes");
                        break;
                    case "No":
                        Console.WriteLine("you said no");
                        break;
                    case "Confirm":
                        completed.Set();// when this is turned into a normal function it shold return to the program not exit
                        break;//insert boolean so confirm can be answerd cancel? repeat options
                    default:
                        break;
                }
            }

            void recognizerSpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            {
                if (e.Result.Alternates.Count == 0)
                {
                    Console.WriteLine("Speech rejected. No candidate phrases found.");
                    return;
                }
                Console.WriteLine("Speech rejected. Did you mean:");
                foreach (RecognizedPhrase r in e.Result.Alternates)
                {
                    Console.WriteLine("    " + r.Text);
                }
            }
        }
   
    }
}
