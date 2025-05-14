using System;
using System.Collections;
using System.Collections.Generic;

namespace PoePart1
{
    public class userInterface
    {
        //Global variable decleration
        private string userName = string.Empty;
        private string userQuestion = string.Empty;

        private Dictionary<string, List<string>> topicResponses;

        //Random object for selecting responses
        private Random rand = new Random();
        private Check_writeFile fileHandler; // file handler
        //Constructor
        //What the user will see
        public userInterface()
        {

            topicResponses = new Dictionary<string, List<string>>();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("////////////////////////");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the ChatbotAI");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("////////////////////////");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Chatbot:-> ");
            //Prompt user for their name
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please enter your name.");


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("You:-> ");
            Console.ResetColor();

            //The name will be read and stored in this string
            userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Chatbot:-> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hello " + userName + ", how can I assist you today?");

            

            //This do while loop outputs the user's name after every response and allows the user to ask another question 
            do
            {


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(userName + ":-> ");
                Console.ResetColor();
                userQuestion = Console.ReadLine();

                // Check for empty input
                if (string.IsNullOrWhiteSpace(userQuestion))
                {
                    Console.WriteLine("Chatbot:-> Please enter a question. The field cannot be empty.");
                }
                else
                {
                    response(userQuestion);

                }
            } while (userQuestion != "exit");

}           
        

            
        //End of constructor


        //Response method
        private void response(string asked)
        {
            Boolean responded = false; // Declare at the start of the method

            //If user didn't type exit, these responses will be displayed
            if (asked != "exit")
            {

                //Array list decleration to store the responses
                ArrayList question = new ArrayList();

                //Array list decleration to store common words that will be ignored
                ArrayList ignore = new ArrayList();

                topicResponses["passwords"] = new List<string>
            {
                "Use strong passwords with a mix of letters, numbers, and symbols.",
                "Avoid using the same password across multiple sites.",
                "Change your passwords regularly.",
                "Enable two-factor authentication where possible.",
                "Always keep your software and security tools up to date.",
                "Use unique and different passwords for every login.",
                "A strong password should include a mix of uppercase and lowercase letters, numbers, and symbols."
               
               
            };

                topicResponses["safe browsing"] = new List<string>
            {
                "Using a VPN encrypts your internet traffic, enhancing privacy.",
                "Always choose a reputable VPN service.",
                "A VPN can help you access geo-restricted content securely.",
                "Installing antivirus software and keeping it updated helps with miniizing cyber-attacks.",
                "It's best to use a VPN when browsing so hackers may not track you",
                "Watch out for 'Allow Notifications' pop-ups when browsing",
                "Never click on suspicious links or download attachments",
                "Use different email addresses for different kinds of accounts",
                "Avoid browsing websites that spam you with ads"
            };

                topicResponses["phishing"] = new List<string>
            {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                "Always check the sender's email address to verify authenticity.",
                "Don't click on suspicious links or download attachments from unknown sources.",
                "Look for grammatical errors or urgent language in suspicious emails.",
                "You can protect your accounts from phishing by using multi-factor authentication",
                "Phishing attacks almost always have some type of grammar error,so be on the lookout for that",
                "If something seems too good to be true (like winning a lottery you didn't enter), it's likely a phishing attempt.",
                "Look for unusual spellings or domains that don't match the legitimate organization in emails."
                
            };

                topicResponses["curious"] = new List<string>
            {
                "Learning about cybersecurity is the first step to staying protected. What specifically are you curious in exploring further?",
                
            };
                topicResponses["worried"] = new List<string>
            {
                "It's completely understandable to feel that way, What specific concerns do you have?",
                "Cybersecurity can seem overwhelming but I'm here to help you understand and stay safe."
            };
                topicResponses["frustrated"] = new List<string>
            {
                "I understand it can be frustrating.  I'll try to explain it more clearly or provide a different perspective.",
                "Let's take it one step at a time. What part are you finding difficult?."
            };
            

                //These words will be ignored,they're not needed
                ignore.Add("tell");
                ignore.Add("what");
                ignore.Add("who");
                ignore.Add("are");
                ignore.Add("you");
                ignore.Add("is");
                ignore.Add("me");
                ignore.Add("about");
                ignore.Add("the");






                //The split questions are stored in the 1D array
                string[] filteredQuestion = asked.Split(' ');//make sure there is 1 space

                //This array list will hold the words that are not ignored
                ArrayList correctFiltered = new ArrayList();
                Boolean found = false;
                //then display the answer using the for loop
                //This will check if each word is not contained in the ignore list
                for (int count = 0; count < filteredQuestion.Length; count++)
                {

                    //then final filter
                    if (!ignore.Contains(filteredQuestion[count]))
                    {

                        //then assign to true
                        found = true;

                        //If the non-ignored word is found then the word is added to correct_filtered
                        correctFiltered.Add(filteredQuestion[count]);
                    }

                }

                foreach (var topic in topicResponses.Keys)
                {
                    foreach (string word in correctFiltered)
                    {
                        if (topic.Contains(word))
                        {
                            List<string> responses = topicResponses[topic];
                            if (responses.Count > 0)
                            {
                                int index = rand.Next(responses.Count);
                                Console.WriteLine("Chatbot:-> " + responses[index]);
                                responded = true;
                            }
                            else
                            {
                                // Handle case where list might be empty
                                Console.WriteLine("Chatbot:-> Sorry, I don't have information on that right now.");
                                responded = true;
                            }
                            break; // Exit inner loop after response
                        }
                    }
                    if (responded)
                        break; // Exit outer loop if responded
                }

                

               

                Boolean found_final = true;
                string message = "";
                //then check if it is found
                if (found)
                {


                    //then loop to show the asnwer
                    for (int counting = 0; counting < correctFiltered.Count; counting++)
                    {
                        //then display the answer
                        for (int count = 0; count < question.Count; count++)
                        {
                            //then finally display the found one
                            if (question[count].ToString().Contains(correctFiltered[counting].ToString()))
                            {
                                found_final = true;
                                //Output
                                message += question[count].ToString() + "\n";
                            }


                        }

                    }
                }


                if (found_final)
                {
                    Console.WriteLine(message);
                }

                else
                {
                    //This will be displayed if no relevant words about cyber-security are found
                    Console.WriteLine("Chatbot:-> Please search something related to cyber-security");
                }


            }

           
            else
            {
                //The displayed message when the user exits
                Console.WriteLine("Chatbot:-> Thank you for using the ChatbotAI, Goodbye");
                System.Environment.Exit(0);

            }//End of else

        }//End of response method

    }//End of class
    
}//End of namespace
