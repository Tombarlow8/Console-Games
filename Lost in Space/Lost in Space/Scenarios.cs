using System;
using System.Collections.Generic;

namespace Lost_in_Space
{
    public class Scenarios
    {
        public string userOptionSelected;
        public string userResult = null;
        Dictionary<string, string> optionResultList = new Dictionary<string, string>();
        Dictionary<string, string> optionList = new Dictionary<string, string>();

        public void scenario1()
        {
            Console.WriteLine("TEST"); //write scenario setting here
            optionSelect("test1", "test2", "test3");
            optionResult("gravitySystemStatus 10", "test2", "test3");
            // option result i.e. take ## damage needs to be in the scenario as string which gets converted 
            getUserResult();
 
        }

        public void scenario2()
        {
            Console.WriteLine("TEST"); //write scenario setting here
            optionSelect("test1", "test2", "test3");
            optionResult("gravitySystemStatus -10", "test2", "test3");
            // option result i.e. take ## damage needs to be in the scenario as string which gets converted 
            getUserResult();

        }

        public void scenario3()
        {
            Console.WriteLine("TEST"); //write scenario setting here
            optionSelect("test1", "test2", "test3");
            optionResult("gravitySystemStatus 10", "test2", "test3");
            // option result i.e. take ## damage needs to be in the scenario as string which gets converted 
            getUserResult();

        }

        public void scenario4()
        {
            Console.WriteLine("TEST"); //write scenario setting here
            optionSelect("test1", "test2", "test3");
            optionResult("gravitySystemStatus 10", "test2", "test3");
            // option result i.e. take ## damage needs to be in the scenario as string which gets converted 
            getUserResult();

        }

        public void optionSelect(string option1, string option2, string option3)
        {
            optionList.Clear();

            optionList.Add("1", option1);
            optionList.Add("2", option2);
            optionList.Add("3", option3);

            foreach (KeyValuePair<string, string> keyValuePair in optionList)
            {
                Console.WriteLine("[" + keyValuePair.Key.ToString() + "] " + keyValuePair.Value);
            }
        }

        public void optionResult(string optionResult1, string optionResult2, string optionResult3)
        {
            optionResultList.Clear();

            optionResultList.Add("1", optionResult1);
            optionResultList.Add("2", optionResult2);
            optionResultList.Add("3", optionResult3);
        }

        public void getUserResult()
        {
            userOptionSelected = Console.ReadLine();// put in seperate method with try catch

            foreach (KeyValuePair<string, string> keyValuePair in optionResultList)
            {
                if (userOptionSelected == keyValuePair.Key.ToString())
                {
                    //Console.WriteLine(keyValuePair.Value);
                    userResult = keyValuePair.Value.ToString();
                }
            }
        }

    }
}
